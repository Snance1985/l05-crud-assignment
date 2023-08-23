using l05_assignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using l05_assignment.Models;
namespace l05_assignment.Controllers;

public class BookmarkController : Controller
{
    private readonly ILogger<BookmarkController> _logger;
    private readonly IBookmarkRepository _bookmarkRepository;

    public BookmarkController(ILogger<BookmarkController> logger, IBookmarkRepository repository)
    {
        _logger = logger;
        _bookmarkRepository = repository;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View(_bookmarkRepository.GetAllBookmarks());
    }

    public IActionResult Edit(int id)
    {
        var bookmark = _bookmarkRepository.GetBookmarkById(id);

        if (bookmark == null)
        {
            return RedirectToAction("List");
        }

        return View(bookmark);
    }

    [HttpPost]
    public IActionResult Edit(Bookmark bookmark)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        return View(_bookmarkRepository.UpdateBookmark(bookmark));
    }

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(Bookmark bookmark)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _bookmarkRepository.CreateBookmark(bookmark);
        
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _bookmarkRepository.DeleteBookmarkById(id);

        return RedirectToAction("List");
    }

}