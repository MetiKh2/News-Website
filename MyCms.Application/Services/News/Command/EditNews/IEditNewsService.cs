using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MyCms.Domain.Entities.News;

namespace MyCms.Application.Services.News.Command.EditNews
{
   public interface IEditNewsService
    {
        ResultDto Execute(RequestEditNewsDto request);
    }

    public class EditNewsService : IEditNewsService
    {
        private readonly IHostingEnvironment env;
        private readonly IDatabaseContext _context;
        public EditNewsService(IDatabaseContext context,IHostingEnvironment hostingEnvironment)
        {
            env = hostingEnvironment;
            _context = context;
        }
        public ResultDto Execute(RequestEditNewsDto request)
        {
            var news = _context.News.Include(p=>p.NewsImages).Where(p=>p.ID==request.NewsID).FirstOrDefault();
            
            var Primarycategory = _context.Categories.Find(news.CategoryID);
            Primarycategory.NewsCount--;

            if (news==null)
            {
                return new ResultDto { 
                IsSuccess=false,
                Message="خبر یافت نشد"};
            }

            news.DisPlayed = request.DisPlayed;
            news.CategoryID = request.CatID;
            news.ShortDescription = request.ShortDescription;
            news.Text = request.Text;
            news.Title = request.Title;
            news.UpdateTime = DateTime.Now;

            var newCategory = _context.Categories.Find(request.CatID);
            newCategory.NewsCount++;

            List<NewsImage> newsImages = new List<NewsImage>();
            foreach (var item in request.Images)
            {
                var uploadedResult = UploadFile(item);
                newsImages.Add(new NewsImage
                {
                    News = news,
                    Src = uploadedResult.FileNameAddress,
                });
            }

            news.NewsImages=newsImages;
            _context.SaveChanges();

            return new ResultDto {  IsSuccess=true,Message="ویرایش انجام شد"};

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

    public class RequestEditNewsDto
    {
        public long NewsID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool DisPlayed { get; set; }
     //   public long ViewCount { get; set; }
        
        public long CatID { get; set; }

        public List<IFormFile> Images { get; set; }

    }
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}
