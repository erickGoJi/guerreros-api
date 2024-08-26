using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.StudyCategory
{
    public class studyCategoryService
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PathImage { get; set; }
        public string PathImageAvatar { get; set; }
        public bool IsActiveStudy {  get; set; }
        public bool IsActiveProgram {  get; set; }
    }
}
