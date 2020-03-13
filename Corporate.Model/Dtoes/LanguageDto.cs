using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Corporate.Model.Dtoes
{
    public class LanguageDto : BaseDto
    {
        [MaxLength(6)]
        public string Culture { get; set; }
        public bool Rtl { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public bool Default { get; set; }
        [MaxLength(8)]
        public string SEOName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
