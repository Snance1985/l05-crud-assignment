namespace l05_assignment.Models;
using System.ComponentModel.DataAnnotations;


public class Bookmark {
    public int BookmarkId { get; set; }

    [Required (ErrorMessage = "Bookmark name is required."), StringLength(50, ErrorMessage = "Bookmark name cannot be more than 50 characters.")]
    public string? Name { get; set; }

    [Required (ErrorMessage = "Bookmark description is required."), StringLength(500, ErrorMessage = "Bookmark description length cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Required (ErrorMessage = "Bookmark Url is required."), Url(ErrorMessage = "Enter a valid Url.")]
    public string? URL { get; set; }
}