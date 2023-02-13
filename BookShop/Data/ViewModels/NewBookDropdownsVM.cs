using BookShop.Models;

namespace BookShop.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM() {
            Authors = new List<Author>();
        }
        public List<Author> Authors { get; set; }
    }
}
