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
            throw new System.NotImplementedException();
        }

        public int TotalPosts()
        {
            return _slapdashAndHaphazardContext.Posts.Count();
        }
    }
}