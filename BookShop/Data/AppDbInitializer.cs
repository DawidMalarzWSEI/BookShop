using BookShop.Data.Static;
using BookShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
//				builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));

				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				context.Database.EnsureCreated();

				if(!context.Authors.Any())
				{
					context.Authors.AddRange(
						new List<Author>()
						{
							new Author()
							{
								ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/e/e3/Stephen_King%2C_Comicon.jpg",
								Name = "Stephen",
								LastName="King",
								Biography="Stephen King to amerykański pisarz, który napisał dotychczas dziesiątki książek i opowiadań - głównie horrorów. Jego książki rozeszły się w setkach milionów egzemplarzy na całym świecie. Do jego najbardziej znanych dzieł należą: \"Zielona mila\", \"Skazani na Shawshank\", \"Lśnienie\", \"Miasteczko Salem\", \"To\", a także seria fantastyczna \"Mroczna Wieża\"."
							}
						});
					context.SaveChanges();
				}
				if (!context.Books.Any())
				{
					context.Books.AddRange(
						new List<Book>()
						{
							new Book()
							{
								Title="Baśniowa opowieść",
								PictureURL="https://s.lubimyczytac.pl/upload/books/5022000/5022292/992194-352x500.jpg",
								Description="Okładka książki Baśniowa opowieść Stephen King\r\nPatronat LC\r\nStephen King Wydawnictwo: Albatros\r\nfantasy, science fiction\r\n704 str. 11 godz. 44 min.\r\n\r\nTytuł oryginału:\r\n    Fairy Tale \r\nData wydania:\r\n    2022-09-07 \r\nData 1. wyd. pol.:\r\n    2022-09-07 \r\nData 1. wydania:\r\n    2022-09-06 \r\nLiczba stron:\r\n    704 \r\nJęzyk:\r\n    polski \r\nISBN:\r\n    9788367338189 \r\nTłumacz:\r\n    Janusz Ochab \r\nTagi:\r\n\r\nSiedemnastolatek otrzymuje w spadku niezwykłe dziedzictwo – klucz do równoległego wymiaru, w którym toczy się wojna między dobrem i złem; walka o najwyższą stawkę: przetrwanie zarówno tamtego świata, jak i tego, który znamy. Historia klasyczna jak baśń czy mit. Zaskakująca i świeża, lecz jednocześnie pełna motywów, które w twórczości Stephena Kinga lubimy najbardziej. Być może wszyscy tę opowieść znamy, lecz wciąż chcemy ją czytać, gdy opowiadana jest na nowo, przez pisarzy tej rangi, co Stephen King.",
								PublicationDate=DateTime.Now.AddDays(-10),
								Price=(decimal)36.82f,
								ISBN="9788367338189",
								BookCategory=Enums.BookCategory.Horror,
								AuthorId=1
							}
						}
					);
					context.SaveChanges();
					
				}
			}
		}
		
		public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
				{
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
				}
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

				string adminUserEmail = "dmalarz.kontakt@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
				if (adminUser == null) {
					var newAdminUser = new ApplicationUser()
					{
						UserName = "admin",
						Email = "dmalarz.kontakt@gmail.com",
						EmailConfirmed = true
					};
					await userManager.CreateAsync(newAdminUser, "zaq1@WSX");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
				}

                string userEmail = "test@test.pl";

                var user = await userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        UserName = "AppUser",
                        Email = userEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newUser, "zaq1@WSX");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }

            }
        }
	}
}
