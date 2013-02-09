namespace Atay.MVC4Samples.Web.Models
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class PageRepository : IPageRepository
    {
        private readonly AtayMvc4SamplesWebContext context = new AtayMvc4SamplesWebContext();

        public IQueryable<Page> All
        {
            get { return this.context.Pages; }
        }

        public IQueryable<Page> AllIncluding(params Expression<Func<Page, object>>[] includeProperties)
        {
            IQueryable<Page> query = this.context.Pages;

            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public Page Find(int id)
        {
            return this.context.Pages.Find(id);
        }

        public void InsertOrUpdate(Page page)
        {
            if (page.PageId == default(int))
            {
                // New entity
                this.context.Pages.Add(page);
            }
            else
            {
                // Existing entity
                this.context.Entry(page).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var page = this.context.Pages.Find(id);
            this.context.Pages.Remove(page);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}