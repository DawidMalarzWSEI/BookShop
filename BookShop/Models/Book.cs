using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
	{
		[Key]
		public int Id { get; set; }
		
		[Display(Name ="")]
        public string PictureURL { get; set; }
        [Display(Name = "Tytuł")]

        public string Title { get; set; }
		[Display(Name = "Opis")]
		public string Description { get; set; }
		[Display(Name = "Dzień wydania")]
		public DateTime PublicationDate { get; set; }

		[DataType(DataType.Currency)]
		[Display(Name ="Cena")]
		public decimal Price { get; set; }
		public string ISBN { get; set; }
		[Display(Name = "Kategoria")]
		public BookCategory BookCategory { get; set; }

		// Author
		public int AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		[Display(Name = "Autor")]
		public Author Author { get; set; }
	}
}
