using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Interfaces.Repositories;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Services
{
    public class TagService: ITagService
    {
        IUnitRepository unitRepository;
        public TagService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public void CreateTag(Tag newTag)
        {
            this.unitRepository.tagRepository.CreateTag(newTag);
        }

        public List<Tag> GetTagsById(int NewsId)
        {
            return this.unitRepository.tagRepository.GetTagsById(NewsId);
        }

        public Tag GetTag(int Id)
        {
            return this.unitRepository.tagRepository.GetTag(Id);
        }

        public void UpdateTag(Tag newTag)
        {
            this.unitRepository.tagRepository.UpdateTag(newTag);
        }

        public void DeleteTag(int TagId)
        {
            this.unitRepository.tagRepository.DeleteTag(TagId);
        }
    }
}
