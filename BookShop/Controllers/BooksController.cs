using BookShop.Data;
using BookShop.Data.Services;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
	public class BooksController : Controller
	{
		private readonly IBooksService _service;

		public BooksController(IBooksService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var allBooks = await _service.GetAllAsync(n => n.Author);
			return View(allBooks);
		}

        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Author);

			if (!string.IsNullOrEmpty(searchString))
			{
				var filteredResult = allBooks.Where(n => n.Title.Contains(searchString)).ToList();
				return View("Index", filteredResult);
			}

            return View("Index", allBooks);
        }

        public async Task<IActionResult> Details(int id)
		{
			var bookDetail = await _service.GetBookByIdAsync(id);
			return View(bookDetail);
		}

		public async Task<IActionResult> Create()
		{
			var bookDropodownsData = await _service.GetNewBookDropdownsValues();
			ViewBag.Authors = new SelectList(bookDropodownsData.Authors, "Id", "LastName");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(NewBookVM book)
		{
			if (!ModelState.IsValid)
			{
				return View(book);
			}
			await _service.AddNewBookAsync(book);
			return RedirectToAction(nameof(Index));
		}

        public async Task<IActionResult> Edit(int id)
        {
			var bookDetails = await _service.GetBookByIdAsync(id);
			if (bookDetails == null) return View("NotFound");

			var response = new NewBookVM()
			{
				Id = bookDetails.Id,
				PictureURL = bookDetails.PictureURL,
				Title = bookDetails.Title,
				Description = bookDetails.Description,
				PublicationDate = bookDetails.PublicationDate,
				Price = bookDetails.Price,
				ISBN = bookDetails.ISBN,
				BookCategory = bookDetails.BookCategory,
				AuthorId = bookDetails.AuthorId,
			};
            var bookDropodownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Authors = new SelectList(bookDropodownsData.Authors, "Id", "LastName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
			if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(book);
            }
            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
