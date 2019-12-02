using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces.Repositories
{
    public interface ITagRepository
    {
        void CreateTag(Tag newTag);
        List<Tag> GetTagsById(int NewsId);
        Tag GetTag(int Id);
        void UpdateTag(Tag newTag);
        void DeleteTag(int TagId);
    }
}
