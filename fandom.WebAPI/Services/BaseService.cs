using AutoMapper;
using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase: class
    {
        private readonly AppCtx _ctx;
        private readonly IMapper _mapper;

        public BaseService(AppCtx context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public List<TModel> Get(TSearch search)
        {
            var list = _ctx.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(list);
        }

        public TModel GetById(int id)
        {
            var result = _ctx.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(result);

        }
    }
}
