
namespace Atay.MVC4Samples.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Page
    {
        [Key]
        public int PageId { get; set; }

        public string Content { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public override string ToString()
        {
            return this.Content;
        }
    }
}