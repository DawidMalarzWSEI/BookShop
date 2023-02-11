using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }

		[Display(Name= "ProfilePictureURL")]
		[Required(ErrorMessage = "Zdjęcie profilowe jest wymagane")]
		public string ProfilePictureURL { get; set; }
		
		[Display(Name="Imię")]
		public string Name { get; set; }
		
		[Display(Name = "Nazwisko")]
		[Required(ErrorMessage = "Proszę uzupełnić nazwisko")]
		public string LastName { get; set; }
		
		[Display(Name="O Autorze")]
		[Required(ErrorMessage = "Proszę uzupełnić opis autora")]
		public string Biography { get; set; }
	}
}
