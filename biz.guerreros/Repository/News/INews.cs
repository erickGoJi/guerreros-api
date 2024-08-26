using biz.guerreros.Models.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Repository.News
{
    public interface INews:IGenericRepository<biz.guerreros.Entities.News>
    {
        List<NewsService> GetAllNews();

        NewsService GetNewsById(int IdNews);

        
    }
}
