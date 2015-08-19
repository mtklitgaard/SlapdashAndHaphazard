using System.Collections.Generic;

namespace SlapdashAndHaphazard.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SlapdashAndHaphazard.Domain.SlapdashAndHaphazardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SlapdashAndHaphazard.Domain.SlapdashAndHaphazardContext context)
        {
            //  This method will be called after migrating to the latest version.

            var category = new Category
            {
                Id = 1,
                Name = "Test",
                UrlSlug = "Test"
            };

            var tag = new Tag
            {
                Id = 1,
                Name = "Test",
                UrlSlug = "Test"
            };

            var post = new Post
            {
                Id = 1,
                Description = "test",
                Meta = "test",
                Modified = null,
                PostedOn = DateTime.Now,
                Published = true,
                ShortDescription = "Test",
                Title = "Title",
                Category = category,
                Tags = new List<Tag> {tag}
            };

            context.Categories.Add(category);
            context.Tags.Add(tag);
            context.Posts.Add(post);

            context.SaveChanges();
        }
    }
}
