
namespace Atay.MVC4Samples.Web.Models
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class CommentRepository : ICommentRepository
    {
        private readonly AtayMvc4SamplesWebContext context = new AtayMvc4SamplesWebContext();

        public IQueryable<Comment> All
        {
            get
            {
                return this.context.Comments;
            }
        }

        public IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = this.context.Comments;

            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public Comment Find(int id)
        {
            return this.context.Comments.Find(id);
        }

        public void InsertOrUpdate(Comment comment)
        {
            if (comment.CommentId == default(int))
            {
                // New entity
                this.context.Comments.Add(comment);
            }
            else
            {
                // Existing entity
                this.context.Entry(comment).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var comment = this.context.Comments.Find(id);
            this.context.Comments.Remove(comment);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}