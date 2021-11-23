using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Models
{
    public class BookmarkViewModel
    {
        public int ID { get; set; }
        [StringLength(maximumLength: 500)]
        public string URL { get; set; }
        public string Description { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
