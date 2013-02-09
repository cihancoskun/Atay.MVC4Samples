
namespace Atay.MVC4Samples.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IPageRepository
    {
        IQueryable<Page> All { get; }

        IQueryable<Page> AllIncluding(params Expression<Func<Page, object>>[] includeProperties);

        Page Find(int id);

        void InsertOrUpdate(Page page);

        void Delete(int id);

        void Save();
    }
}