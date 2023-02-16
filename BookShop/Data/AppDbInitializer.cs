using BookShop.Data.Static;
using BookShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;

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
							},
                            new Author()
								{
									ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/5/5d/J._K._Rowling_2010.jpg",
									Name = "Joanne",
									LastName = "Rowling",
									Biography = "J.K. Rowling to brytyjska pisarka, autorka serii powieści o Harrym Potterze. Jej książki stały się światowym fenomenem, przetłumaczonym na wiele języków i sprzedanym w milionach egzemplarzy. Rowling jest również zaangażowana w działalność charytatywną i społeczną, między innymi w walkę z nierównościami społecznymi i edukacją dzieci."
								},
                            new Author()
                            {
                                ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Walter_Isaacson_VF_2012_Shankbone_2.JPG/1920px-Walter_Isaacson_VF_2012_Shankbone_2.JPG",
                                Name = "Walter",
                                LastName="Isaacson",
                                Biography="Walter Isaacson to amerykański pisarz, biograf i historyk. Urodził się w 1952 roku w Nowym Orleanie w stanie Luizjana. Jest absolwentem Uniwersytetu Harvarda oraz Pembroke College na Uniwersytecie Oksfordzkim.\r\n\r\nIsaacson jest autorem bestsellerowych biografii, takich jak \"Steve Jobs\", \"Albert Einstein\" oraz \"Benjamin Franklin\". Jego książki cechują się nie tylko bogatą i dokładną treścią, ale także lekkim i przyjemnym stylem pisania, który sprawia, że czytelnik może wciągnąć się w historię i nauczyć się wiele o życiu i dokonaniach prezentowanych postaci."
                            },
                            new Author()
                            {
                                ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Krystyna_Kurczab-Redlich.jpg/480px-Krystyna_Kurczab-Redlich.jpg",
                                Name = "Krystyna",
                                LastName="Kurczab-Redlich",
                                Biography="Krystyna Kurczab-Redlich (ur. 29 czerwca 1946 w Krakowie) to polska dziennikarka, publicystka, pisarka i autorka audycji radiowych i telewizyjnych. Ukończyła polonistykę na Uniwersytecie Jagiellońskim, a następnie podjęła pracę w Radiu Kraków. W latach 70. XX wieku była korespondentką wojenną m.in. w Wietnamie i Kambodży.\r\n\r\nJest autorką licznych reportaży, wywiadów i audycji radiowych oraz telewizyjnych, a także książek. W swojej twórczości porusza tematykę wojenną, konflikty zbrojne oraz losy ludzi zamieszkujących strefy konfliktów. Znana jest z publikacji takich jak \"Czekając na Turka\" (1978), \"Szkice piórkiem\" (1981) czy \"Wojna w moim domu\" (1992), które zdobyły wiele nagród i wyróżnień.\r\n\r\nKrystyna Kurczab-Redlich jest laureatką wielu prestiżowych nagród, m.in. Nagrody Literackiej \"Nike\" (1998) za książkę \"Córka wodza\", Nagrody im. Dariusza Fikusa (2000) za całokształt twórczości oraz Nagrody Grand Press (2002) za reportaż \"Powrót do Sarajewa\". W 2013 roku została odznaczona Krzyżem Komandorskim Orderu Odrodzenia Polski."
                            },
                            new Author()
                            {
                                ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Italiaanse_schrijver_Umberto_Eco%2C_portret.jpg/1280px-Italiaanse_schrijver_Umberto_Eco%2C_portret.jpg",
                                Name = "Umberto",
                                LastName="Eco",
                                Biography="Umberto Eco (ur. 5 stycznia 1932 r., zm. 19 lutego 2016 r.) to włoski pisarz, filozof, semiotyk, teoretyk literatury oraz profesor uniwersytecki. Znany jest przede wszystkim ze swoich powieści, które łączą elementy kryminalne, sensacyjne i historyczne z zawiłymi zagadkami filozoficznymi i semiotycznymi.\r\n\r\nJego debiutancka powieść \"Imię róży\" (1980) stała się międzynarodowym bestsellerem i uważana jest za jedno z najważniejszych dzieł literatury XX wieku. W swoich książkach Eco często sięgał do motywów religijnych i historycznych, co stanowiło pretekst do przemyśleń na temat natury ludzkiej, wiedzy i prawdy. Innymi znanymi powieściami pisarza są m.in. \"Foucault's Pendulum\" (1988), \"Wyspa dnia przedwczorajszego\" (1994) oraz \"Baudolino\" (2000)."
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
							},
                            new Book()
								{
								Title = "Harry Potter i Kamień Filozoficzny",
								PictureURL = "https://ecsmedia.pl/c/harry-potter-i-kamien-filozoficzny-tom-1-w-iext123072033.jpg",
								Description = "Pierwsza część kultowej serii przygód młodego czarodzieja Harry'ego Pottera, który zostaje przyjęty do szkoły magii i czarodziejstwa Hogwart. Tam wraz z przyjaciółmi Ronem Weasleyem i Hermioną Granger odkrywa sekrety magicznego świata, a także staje w szranki z czarnoksiężnikiem Voldemortem. Powieść autorstwa brytyjskiej pisarki J.K. Rowling stała się międzynarodowym bestsellerem i zyskała liczne adaptacje filmowe oraz teatralne.",
								PublicationDate = new DateTime(1997, 6, 26),
								Price = 29.99m,
								ISBN = "9788380081886",
								BookCategory = Enums.BookCategory.Fantasy,
								AuthorId = 2
								},
								new Book()
								{
								Title = "Harry Potter i Komnata Tajemnic",
								PictureURL = "https://ecsmedia.pl/c/harry-potter-i-komnata-tajemnic-tom-2-w-iext123071948.jpg",
								Description = "Druga część serii o Harrym Potterze, który wraz z przyjaciółmi powraca do szkoły magii i czarodziejstwa Hogwart. Tam odkrywa tajemnicę legendarnego potwora, który terroryzuje uczniów, a także przeciwstawia się siłom czarnoksiężnika Voldemorta. Powieść autorstwa J.K. Rowling to kolejna bestsellerowa odsłona kultowej sagi o młodym czarodzieju.",
								PublicationDate = new DateTime(1998, 7, 2),
								Price = 29.99m,
								ISBN = "9788380081893",
								BookCategory = Enums.BookCategory.Fantasy,
								AuthorId = 2
								},
								new Book()
								{
								Title = "Harry Potter i Więzień Azkabanu",
								PictureURL = "https://ecsmedia.pl/c/harry-potter-i-wiezien-azkabanu-tom-3-w-iext123069623.jpg",
								Description = "Trzecia część przygód Harry'ego Pottera, który wraca do Hogwartu na kolejny rok nauki. Tam odkrywa, że z więzienia uciekł groźny przestępca, który jest związany z jego przeszłością. Wraz z Ronem i Hermioną musi stawić czoła niebezpieczeństwom, a także ujawnić tajemnice związaną z jego rodziną. Powieść autorstwa J.K. Rowling to kolejna bestsellerowa odsłona kultowej sagi o młodym czarodzieju.",
								PublicationDate = new DateTime(1999, 7, 8),
								Price = 29.99m,
								ISBN = "9788380081909",
								BookCategory = Enums.BookCategory.Fantasy,
								AuthorId = 2
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

				string adminUserEmail = "admin@admin.pl";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
				if (adminUser == null) {
					var newAdminUser = new ApplicationUser()
					{
						UserName = "admin",
						Email = "admin@admin.pl",
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
