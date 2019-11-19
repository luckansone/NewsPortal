using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.ViewModel
{
    public class NewsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Enter content.")]
        public string Content { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishTime { get; set; }

    }
}