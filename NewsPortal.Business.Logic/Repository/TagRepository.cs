using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class TagRepository: ITagRepository
    {
        IPortalContext context { get; set; }
        public TagRepository(IPortalContext portalContext)
        {
            context = portalContext;
        }

        public void CreateTag(Tag newTag)
        {
            this.context.Tags.Add(newTag);
            this.context.SaveChanges();
        }

        public List<Tag> GetTagsById(int NewsId)
        {
            return this.context.Tags.Where(x=>x.NewsId == NewsId).ToList();
        }

        public Tag GetTag(int Id)
        {
            return this.context.Tags.ToList().Find(x => x.Id == Id);
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
