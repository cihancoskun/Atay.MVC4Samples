
namespace Atay.MVC4Samples.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface ICommentRepository
    {
        IQueryable<Comment> All { get; }

        IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties);

        Comment Find(int id);

        void InsertOrUpdate(Comment comment);

        void Delete(int id);

        void Save();
    }
}