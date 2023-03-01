using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required, StringLength(20, ErrorMessage = "Please be Adam")]

        public string Url { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsPublished { get; set; } = false;
    }
}
