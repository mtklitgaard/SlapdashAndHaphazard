using System.Collections.Generic;
using System.Linq;
using SlapdashAndHaphazard.Domain;
using SlapdashAndHaphazard.Domain.Interfaces;
using SlaphdashAndHaphazard.Services.Interfaces;

namespace SlaphdashAndHaphazard.Services
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ISlapdashAndHaphazardContext _slapdashAndHaphazardContext;

        public BlogRepository(ISlapdashAndHaphazardContext slapdashAndHaphazardContext)
        {
            _slapdashAndHaphazardContext = slapdashAndHaphazardContext;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _slapdashAndHaphazardContext
                            .Posts
                            .Where(x => x.Published)
                            .OrderByDescending(x => x.PostedOn)
                            .Skip(pageNo*pageSize)
                            .Take(pageSize);

            return posts.ToList();
        }

        public int TotalPosts()
        {
            return _slapdashAndHaphazardContext.Posts.Count();
        }
    }
}