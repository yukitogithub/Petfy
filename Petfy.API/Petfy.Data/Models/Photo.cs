﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public bool IsMain { get; set; }
    }
}
