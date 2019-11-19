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
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public News()
        {
            Tags = new List<Tag>();
        }
    }
}
