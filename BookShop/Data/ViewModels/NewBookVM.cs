using BookShop.Data.Base;
using BookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class NewBookVM
	{
        public int Id { get; set; }
		
		[Display(Name ="Avatar")]
		[Required(ErrorMessage ="Avatar jest wymagane")]
        public string PictureURL { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }


        [Display(Name = "Data wydania")]
        [Required(ErrorMessage = "Data wydania jest wymagana")]
        public DateTime PublicationDate { get; set; }

		[DataType(DataType.Currency)]
		[Display(Name ="Cena")]
        [Required(ErrorMessage = "Cena jest wymagane")]
        public decimal Price { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "ISBN jest wymagany")]
        public string ISBN { get; set; }

		[Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Kategoria jest wymagana")]

        public BookCategory BookCategory { get; set; }

        [Display(Name = "Wybierz autora")]
        [Required(ErrorMessage = "Autor jest wymagane")]
        public int AuthorId { get; set; }
    }
}
