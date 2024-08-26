using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.News
{
    public class NewsService
    {
        public int Id { get; set; }
        public int? StudyCategoryId { get; set; }
        public string Title { get; set; }
        public string ContentNews { get; set; }
        public string PathImage { get; set; }
        public DateTime DateNews { get; set; }

        public string studyName { get; set; }

    }
}
