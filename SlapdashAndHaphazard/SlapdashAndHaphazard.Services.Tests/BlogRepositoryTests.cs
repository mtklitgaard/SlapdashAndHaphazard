using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SlapdashAndHaphazard.Domain;
using SlapdashAndHaphazard.Domain.Interfaces;
using SlaphdashAndHaphazard.Services;
using Xunit;

namespace SlapdashAndHaphazard.Services.Tests
{
    public class BlogRepositoryTests
    {
        private BlogRepository _classUnderTest;
        private Mock<ISlapdashAndHaphazardContext> _slapdashContext;

        public BlogRepositoryTests()
        {
            _slapdashContext = new Mock<ISlapdashAndHaphazardContext>();
            _classUnderTest = new BlogRepository(_slapdashContext.Object);
        }

        public class Posts : BlogRepositoryTests
        {
            [Fact]
            public void ReturnsPostsThatHavePublishedSetToTrue_AndPostedDateDesc()
            {
                var posts = new List<Post>
                {
                    new Post {Id = 1, PostedOn = DateTime.Now.AddDays(-2), Published = true},
                    new Post {Id = 2, PostedOn = DateTime.Now.AddDays(-1), Published = false},
                    new Post {Id = 3, PostedOn = DateTime.Now, Published = true},
                }.AsQueryable();

                var mockPosts = new Mock<DbSet<Post>>();
                mockPosts.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(posts.Provider);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(posts.Expression);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(posts.ElementType);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(posts.GetEnumerator());

                var expected = mockPosts.Object.Where(x => x.Published).OrderByDescending(x => x.PostedOn).ToList();

                _slapdashContext
                    .Setup(x => x.Posts)
                    .Returns(mockPosts.Object);

                var actual = _classUnderTest.Posts(1, 1);

                Assert.Equal(expected, actual);
            }
        }

        public class TotalPosts : BlogRepositoryTests
        {
            [Fact]
            public void ReturnsTotalPosts()
            {
                var posts = new List<Post>
                {
                    new Post {Id = 1 },
                    new Post {Id = 2 },
                    new Post {Id = 3 },
                }.AsQueryable();

                var mockPosts = new Mock<DbSet<Post>>();
                mockPosts.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(posts.Provider);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(posts.Expression);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(posts.ElementType);
                mockPosts.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(posts.GetEnumerator());
                
                var expected = mockPosts.Object.Count();

                _slapdashContext
                    .Setup(x => x.Posts)
                    .Returns(mockPosts.Object);

                var actual = _classUnderTest.TotalPosts();

                _slapdashContext
                    .Verify(x => x.Posts);

                Assert.Equal(expected, actual);
            }
        }
    }
}
