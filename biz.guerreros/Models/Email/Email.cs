﻿using System;
using System.Collections.Generic;
using System.Text;

namespace biz.guerreros.Models.Email
{
    public class Email
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
