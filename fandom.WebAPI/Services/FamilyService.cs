using AutoMapper;
using fandom.Model;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly AppCtx _ctx;
        private readonly IMapper _mapper;

        public FamilyService(AppCtx ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public List<MFamily> GetAll()
        {
            var family = _ctx.Families.Include(x => x.MediaFile).Include(x => x.Members).ToList();
            return _mapper.Map<List<MFamily>>(family);
        }

        public MFamily GetById(int id)
        {
            var family = _ctx.Families.Include(x => x.Members).Include("Members.CharacterMediaFile").Include(x => x.MediaFile).Where(x => x.Id == id).FirstOrDefault();

            return _mapper.Map<MFamily>(family);
        }

        public MFamily Insert(FamilyInsertRequest request)
        {
            var family = _mapper.Map<Family>(request);
            
            _ctx.Families.Add(family);
            _ctx.SaveChanges();
            return _mapper.Map<MFamily>(family);
            
        }
    }
}
