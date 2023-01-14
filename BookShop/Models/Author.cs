using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }

		public string ProfilePictureURL { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Biography { get; set; }
	}
}
