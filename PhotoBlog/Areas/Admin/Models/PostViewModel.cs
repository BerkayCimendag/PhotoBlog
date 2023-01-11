using System.ComponentModel.DataAnnotations;

namespace PhotoBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [MaxLength(140)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        public IFormFile Photo { get; set; } = null!;
    }
}
