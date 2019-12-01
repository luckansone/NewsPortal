using System;
using System.Collections.Generic;

namespace NewsPortal.Business.Logic.Models
{ 
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime PublishTime { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public News()
        {
            Tags = new List<Tag>();
        }
    }
}
