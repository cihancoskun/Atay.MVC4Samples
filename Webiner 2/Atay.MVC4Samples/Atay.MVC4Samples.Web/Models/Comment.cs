
namespace Atay.MVC4Samples.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentContent { get; set; }

        public int PageId { get; set; }

        public virtual Page Page { get; set; }
    }
}