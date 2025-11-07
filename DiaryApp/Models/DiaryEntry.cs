using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title for your diary entry")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write your thoughts and feelings")]
        [StringLength(10000, MinimumLength = 10, ErrorMessage = "Description must be at least 10 characters")]
        public string Description { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Please select how you're feeling")]
        public Mood Mood { get; set; }
    }
}