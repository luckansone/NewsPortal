using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.ViewModel
{
    public class TagModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter tag name.")]
        public int Name { get; set; }
    }
}