using Microsoft.AspNetCore.Http;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Microsoft.AspNetCore.Hosting;
using MyCms.Domain.Entities.News;

namespace MyCms.Application.Services.News.Command.AddNews
{
  public  interface IAddNewsService
    {
        ResultDto Execute(RequestAddNews request);
    }

    public class AddNewsService:IAddNewsService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment env;
        public AddNewsService(IDatabaseContext context, IHostingEnvironment  hostingEnvironment)
        {
            env = hostingEnvironment;
            _context = context;
        }

        public ResultDto Execute(RequestAddNews request)
        {
           var category = _context.Categories.Where(p => p.ID==request.CatID).FirstOrDefault();
            
            if (string.IsNullOrEmpty(request.Title))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام خبر را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.ShortDescription))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "توضیح خبر را وارد نمایید",
                };
            }
            if (string.IsNullOrEmpty(request.Text))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "متن خبر را وارد نمایید",
                };
            }
           
            var news = new MyCms.Domain.Entities.News.News() { 
           CategoryID=request.CatID,
           Category=request.Category,
           ShortDescription=request.ShortDescription,
            Text=request.Text,
            Title=request.Title,
            DisPlayed=request.Displayed,
            
            };
            _context.News.Add(news);

            List<NewsImage> newsImages = new List<NewsImage>();
            foreach (var item in request.Images)
            {
                var uploadedResult = UploadFile(item);
                newsImages.Add(new NewsImage
                {
                    News=news,
                    Src = uploadedResult.FileNameAddress,
                });
            }

            _context.NewsImage.AddRange(newsImages);
            category.NewsCount++;
            _context.SaveChanges();


            return new ResultDto
            {
                IsSuccess = true,
                Message = "خبر با موفقیت اضافه شد",
            };









             UploadDto UploadFile(IFormFile file)
            {
                if (file != null)
                {
                    string folder = $@"images\NewsImages\";
                    var uploadsRootFolder = Path.Combine(env.WebRootPath, folder);
                    if (!Directory.Exists(uploadsRootFolder))
                    {
                        Directory.CreateDirectory(uploadsRootFolder);
                    }


                    if (file == null || file.Length == 0)
                    {
                        return new UploadDto()
                        {
                            Status = false,
                            FileNameAddress = "",
                        };
                    }

                    string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    return new UploadDto()
                    {
                        FileNameAddress = folder + fileName,
                        Status = true,
                    };
                }
                return null;
            }
        }
    }

    public class RequestAddNews
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public List<IFormFile> Images { get; set; }
        public long CatID { get; set; }
        public MyCms.Domain.Entities.Categories.Category Category { get; set; }
        public bool Displayed { get; set; }
    }
  
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}

