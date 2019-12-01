using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Business.Logic.Models
{
    public class Tag
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int NewsId { get; set; }
        public virtual News News { get; set; }

    }
}
