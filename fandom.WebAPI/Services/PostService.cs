using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly AppCtx ctx;
        private readonly IMapper _mapper;

        public PostService(AppCtx context, IMapper mapper)
        {
            ctx = context;
            _mapper = mapper;
        }

        public List<MPost> GetAll()
        {
            var query = ctx.Posts.Include(x => x.Category).Include(x => x.User).Select(x => new MPost
            {
                Id = x.Id,
                Category = _mapper.Map<MCategory>(x.Category),
                CreationDate = x.CreationDate,
                Summary = x.Summary,
                Title = x.Title,
                User = _mapper.Map<MUser>(x.User),
                Tags = x.PostsTags.Where(y => y.PostId==x.Id).Select(y => new MTag
                {
                    Id = y.TagId,
                    Title=y.Tag.Title
                }).ToList()
            }).ToList();

            return query;
        }

        public MPost GetById(int id)
        {
            var query = ctx.Posts.Include(x => x.User).Include(x => x.Category).Include(x => x.PostsTags).Where(x => x.Id == id).FirstOrDefault();

            var result = _mapper.Map<MPost>(query);
            result.Tags = query.PostsTags.Select(x => new MTag { Id = x.PostId, Title = x.Post.Title }).ToList();

            return result;
        }

        public MPost Insert(PostInsertRequest request)
        {
            Post newPost = new Post
            {
                CategoryId = request.Category.Id,
                CreationDate = request.CreationDate,
                Summary = request.Summary,
                Title = request.Title,
                UserId = request.PostOwner.Id,
            };

            ctx.Posts.Add(newPost);
            ctx.SaveChanges();

            foreach(var item in request.Tags)
            {
                PostTag pt = new PostTag { PostId = newPost.Id, TagId = item.Id };
                ctx.PostTags.Add(pt);
            }

            ctx.SaveChanges();

            return _mapper.Map<MPost>(newPost);
        }

        public MPost Update(int id, PostUpdateRequest request)
        {
            var post = ctx.Posts.Include(x => x.Category).Include(x => x.PostsTags).Where(x => x.Id == id).FirstOrDefault();
            if(request.Tags.Count > 0)
            {
                var tags = ctx.PostTags.Where(x => x.PostId == id).ToList();
                ctx.PostTags.RemoveRange(tags);
                ctx.SaveChanges();

                foreach(var tag in request.Tags)
                {
                    ctx.PostTags.Add(new PostTag
                    {
                        PostId = id,
                        TagId = tag.Id
                    });
                }

                ctx.SaveChanges();
            }


            post.Title = request.Title;
            post.Summary = request.Summary;
            post.CreationDate = request.UpdatedDate;
            post.CategoryId = request.Category.Id;

            ctx.SaveChanges();

            return _mapper.Map<MPost>(post);

        }
    }
}
