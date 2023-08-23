using l05_assignment.Models;

namespace l05_assignment.Repositories;

public interface IBookmarkRepository
{
    IEnumerable<Bookmark> GetAllBookmarks();
    Bookmark GetBookmarkById(int bookmarkId);
    Bookmark CreateBookmark(Bookmark newBookmark);
    Bookmark UpdateBookmark(Bookmark newBookmark);
    void DeleteBookmarkById(int bookmarkId);
}