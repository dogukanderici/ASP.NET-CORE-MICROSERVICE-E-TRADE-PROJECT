using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Comment.Entities.Concrete
{
    public class UserComment
    {
        [Key]
        public int UserCommentId { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public int CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
