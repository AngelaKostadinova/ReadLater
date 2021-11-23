using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        [StringLength(maximumLength: 50)]

        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
