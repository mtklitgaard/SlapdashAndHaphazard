using System.Collections;
using System.Collections.Generic;
using SlapdashAndHaphazard.Domain;

namespace SlaphdashAndHaphazard.Services.Interfaces
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
    }
}
