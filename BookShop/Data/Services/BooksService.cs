using BookShop.Data.Base;
using BookShop.Data.ViewModels;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Services
{
    public class BooksService:EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context): base(context) { 
            _context= context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                PictureURL = data.PictureURL,
                Title = data.Title,
                Description = data.Description,
                PublicationDate = data.PublicationDate,
                Price = data.Price,
                ISBN = data.ISBN,
                BookCategory = data.BookCategory,
                AuthorId = data.AuthorId,

            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var booksDetails = await _context.Books.Include(c => c.Author).FirstOrDefaultAsync(n => n.Id == id);
            return booksDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM();
            response.Authors = await _context.Authors.OrderBy(n => n.LastName).ToListAsync();
            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.PictureURL = data.PictureURL;
                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.PublicationDate = data.PublicationDate;
                dbBook.Price = data.Price;
                dbBook.ISBN = data.ISBN;
                dbBook.BookCategory = data.BookCategory;
                dbBook.AuthorId = data.AuthorId;
                await _context.SaveChangesAsync();
            }

            
        }
    }
}
