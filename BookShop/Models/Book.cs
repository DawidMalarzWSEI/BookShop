using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		
		public DateTime PublicationDate { get; set; }

		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		public string ISBN { get; set; }
		public BookCategory BookCategory { get; set; }

		// Author
		public int AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public Author Author { get; set; }
	}
}
