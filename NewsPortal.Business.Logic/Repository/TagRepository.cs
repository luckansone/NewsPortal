using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class TagRepository
    {
        public static TagRepository instance = new TagRepository();
        PortalContext context { get; set; }
        public TagRepository()
        {
            context = new PortalContext(); 
        }

        public void CreateTag(string name)
        {
            Tag newTag = new Tag()
            {
                Name = name
            };
            this.context.Tags.Add(newTag);
            this.context.SaveChanges();
        }

        public List<Tag> GetTagsById(int NewsId)
        {
            return this.context.Tags.Where(x=>x.News.Id==NewsId).ToList();
        }

        public void UpdateTag(Tag newTag)
        {
            var oldmodel = context.Tags.ToList().Find(x=>x.Id == newTag.Id);
            
            if(oldmodel==null)
            {
                return;
            }

            this.context.Tags.Remove(oldmodel);
            this.context.Tags.Add(newTag);
            this.context.SaveChanges();
        }

        public void DeleteTag(int TagId)
        {
            var model = context.Tags.ToList().Find(x => x.Id == TagId);

            if(model==null)
            {
                return;
            }

            this.context.Tags.Remove(model);
            this.context.SaveChanges();
        }
    }
}
