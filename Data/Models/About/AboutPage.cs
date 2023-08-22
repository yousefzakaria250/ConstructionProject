﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class AboutPage :EntityBase
    {
        public string header { set; get; } = String.Empty;
        public string bg { set; get; } = String.Empty; /// Image
        public string headerAR { set; get;} = String.Empty;
        //[ForeignKey("Section")]
        //public int SectionId { set; get; }
        public Section? Section { set; get; } = null!;

    }
}
