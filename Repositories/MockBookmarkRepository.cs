using l05_assignment.Models;

namespace l05_assignment.Repositories;
public class MockBookmarkRepository : IBookmarkRepository
{     
    private List<Bookmark> bookmarkList;

    public MockBookmarkRepository() {
        bookmarkList = new List<Bookmark>();

        bookmarkList.Add(new Bookmark {
            BookmarkId = 1,
            Name = "Form Tag Helpers",
            Description = "Documentation for form Tag Helpers in .NET",
            URL = "https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-6.0#the-form-tag-helper"
        });
        bookmarkList.Add(new Bookmark {
            BookmarkId = 2,
            Name = "Razor Syntax",
            Description = "Documentation and various examples for Razor syntax in ASP.NET web apps.",
            URL = "https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-6.0"
        });
        bookmarkList.Add(new Bookmark {
            BookmarkId = 3,
            Name = "Partial Views",
            Description = "Descriptions and examples of how to use partial views in .NET MVC apps.",
            URL = "https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-6.0"
        });
    }

    public Bookmark CreateBookmark(Bookmark newBookmark)
    {
        // Find current max BookmardId
        var maxId = bookmarkList.Select(c => c.BookmarkId)
            .DefaultIfEmpty()
            .Max();

        // Increment BookmarkId for new bookmark
        newBookmark.BookmarkId = maxId + 1;

        bookmarkList.Add(newBookmark);
        return newBookmark;
    }

    public void DeleteBookmarkById(int bookmarkId)
    {
        var bookmarkToRemove = bookmarkList.Find(c => c.BookmarkId == bookmarkId);
        if (bookmarkToRemove != null) {
            bookmarkList.Remove(bookmarkToRemove);
        }
    }

    public IEnumerable<Bookmark> GetAllBookmarks()
    {
        return bookmarkList;
    }

    public Bookmark GetBookmarkById(int bookmarkId)
    {
        return bookmarkList.Find(c => c.BookmarkId == bookmarkId);
    }

    public Bookmark UpdateBookmark(Bookmark newBookmark)
    {
        var existingBookmark = bookmarkList.Find(c => c.BookmarkId == newBookmark.BookmarkId);

        // If bookmark exists, update properties
        if (existingBookmark != null) {
            existingBookmark.Name = newBookmark.Name;
            existingBookmark.Description = newBookmark.Description;
            existingBookmark.URL = newBookmark.URL;
        }
        
        return existingBookmark;
    }
}