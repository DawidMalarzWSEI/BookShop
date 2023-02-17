using BookShop.Controllers;
using BookShop.Data.Services;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookShop.Tests.Controllers
{
    public class BooksControllerTests
    {
        private readonly Mock<IBooksService> _mockService;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockService = new Mock<IBooksService>();
            _controller = new BooksController(_mockService.Object);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithListOfBooks()
        {
            var books = new List<Book>()
            {
                new Book() { Id = 1, Title = "Book 1", Author = new Author() { Id = 1, ProfilePictureURL = "", Name = "John", LastName = "Doe", Biography = "" } },
                new Book() { Id = 2, Title = "Book 2", Author = new Author() { Id = 2, ProfilePictureURL = "", Name = "Jane", LastName = "Doe", Biography = "" } }
            };
            _mockService.Setup(s => s.GetAllAsync(n => n.Author)).ReturnsAsync(books);

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Filter_ReturnsAViewResult_WithFilteredBooks()
        {
            var books = new List<Book>()
            {
                new Book() { Id = 1, Title = "Book 1", Author = new Author() { Id = 1, ProfilePictureURL = "", Name = "John", LastName = "Doe", Biography = "" } },
                new Book() { Id = 2, Title = "Book 2", Author = new Author() { Id = 2, ProfilePictureURL = "", Name = "Jane", LastName = "Doe", Biography = "" } }
            };
            _mockService.Setup(s => s.GetAllAsync(n => n.Author)).ReturnsAsync(books);

            var result = await _controller.Filter("Book 1");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.ViewData.Model);
            Assert.Single(model);
            Assert.Equal("Book 1", model.First().Title);
        }

        [Fact]
        public async Task Details_ReturnsAViewResult_WithBook()
        {
            var book = new Book() { Id = 1, Title = "Book 1", Author = new Author() { Id = 1, ProfilePictureURL = "", Name = "John", LastName = "Doe", Biography = "" } };
            _mockService.Setup(s => s.GetBookByIdAsync(1)).ReturnsAsync(book);

            var result = await _controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Book>(viewResult.ViewData.Model);
            Assert.Equal("Book 1", model.Title);
        }

    }
}
