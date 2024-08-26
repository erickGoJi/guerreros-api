using biz.guerreros.Models.News;
using biz.guerreros.Repository.News;
using dal.guerreros.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.guerreros.Repository.News
{
    public class NewsRepository : GenericRepository<biz.guerreros.Entities.News>, INews
    {
        public NewsRepository(Db_GuerrerosContext context) : base(context) { }

        public List<NewsService> GetAllNews()
        {
            var service = _context.News
                .Select(i => new NewsService
                {
                    Id = i.Id,
                    Title = i.Title,
                    ContentNews = i.ContentNews,
                    StudyCategoryId = i.StudyCategoryId,
                    PathImage = i.PathImage,
                    DateNews = i.DateNews,
                    studyName = i.StudyCategory.Name

                }).ToList();

            return service;
        }

        public NewsService GetNewsById(int IdNews)
        {
            var service = _context.News
                .Where(i => i.Id == IdNews)
                .Select(j => new NewsService
                {
                    Id = j.Id,
                    ContentNews = j.ContentNews,
                    PathImage = j.PathImage,
                    StudyCategoryId = j.StudyCategoryId,
                    Title = j.Title,
                    DateNews = j.DateNews
                         


                }).FirstOrDefault();

            return service;
        }
    }
}
