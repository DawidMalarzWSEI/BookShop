# Sklep internetowy z książkami

Jest to aplikacja napisana w języku C# z wykorzystaniem wzorca architektonicznego Model-View-Controller (MVC). Aplikacja umożliwia użytkownikom stworzenie własnych kont oraz zakup wybranych przez siebie książek.
Wymagania systemowe

Aplikacja wymaga zainstalowania następujących narzędzi:

    Visual Studio 2019 lub nowszej wersji
    .NET Core 3.1 lub nowszej wersji
    Microsoft SQL Server 2012 lub nowszej wersji

## Instalacja i uruchomienie

### Repozytorium
1. Sklonuj repozytorium na swoje urządzenie:
    ```bash
    https://github.com/DawidMalarzWSEI/BookShop.git
    ```

2. Otwórz projekt w programie Visual Studio.
3. Uruchom aplikację w trybie debugowania lub skompiluj ją i uruchom plik wykonywalny.

### Baza danych
Konfiguracja bazy danych
W pliku appsettings.json zmień nazwę serwera SQL Servera oraz login i hasło, jeśli zostały zmienione:
```
"ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-4ODKDHC;Initial Catalog=bookshopv2;Integrated Security=True;Pooling=False;TrustServerCertificate=True"
  },
```

### Aplikacja
user
```
Login: test@test.pl
Hasło: zaq1@WSX
```

admin:
```
Login: admin@admin.pl
Hasło: zaq1@WSX
```

# Opis

### Opis funkcjonalności:

Aplikacja umożliwia użytkownikom:
- utworzenie nowego konta,
- zalogowanie się na istniejące konto,
- przeglądanie dostępnych książek,
- dodawanie książek do koszyka,
- podsumowanie zamówienia przed dokonaniem płatności,
- dokonanie płatności za zamówienie.

### Struktura projektu
- Controllers - kontrolery obsługujące żądania HTTP
- Models - modele danych aplikacji
- Views - widoki wyświetlane użytkownikom
- ViewModels - modele widoków wykorzystywane przez kontrolery i widoki
- Data - klasy dostępu do danych, np. do bazy danych
- Services - serwisy wykorzystywane przez kontrolery
- Utilities - narzędzia i pomocnicze klasy wykorzystywane w aplikacji
- appsettings.json - plik konfiguracyjny
- Program.cs - klasa zawierająca metodę Main
- Startup.cs - klasa konfigurująca aplikację

# O aplikacji
Strona główna sklepu internetowego z książkami zawiera listę dostępnych książek wraz z ich okładkami, tytułami i cenami.  
Użytkownicy mają możliwość przeglądania książek oraz dodawania wybranych pozycji do koszyka.
Dodatkowo, na stronie znajduje się zakładka z pisarzami, w której można znaleźć informacje o autorach.
Aby ułatwić użytkownikom wyszukiwanie konkretnych pozycji, aplikacja posiada także wyszukiwarkę książek, która umożliwia filtrowanie wyników po tytułach.
W górnym prawym rogu strony znajdują się przyciski do zalogowania się lub utworzenia konta. Dzięki temu użytkownicy mają możliwość korzystania ze swojego indywidualnego koszyka i historii zamówień.

<img src="https://github.com/DawidMalarzWSEI/BookShop/blob/master/BookShop/Images/app.png">

# Baza danych
Do tego projektu została wykorzystana relacyjna baza danych oparta na systemie zarządzania bazą danych Microsoft SQL Server.

W bazie danych znajdują się pięć tabel:

- Tabela `Orders` przechowująca informacje o zamówieniach, w tym datę złożenia zamówienia, informacje o kliencie, informacje o dostawie i łączną kwotę zamówienia.
- Tabela `OrderItems` przechowująca informacje o każdym przedmiocie z zamówienia, w tym informacje o książce, ilości zamówionych egzemplarzy i łącznej cenie.
- Tabela `Books` przechowująca informacje o każdej książce, w tym tytuł, autora, opis, okładkę i cenę.
- Tabela `Authors` przechowująca informacje o każdym autorze, w tym imię i nazwisko, biografię i zdjęcie.
- Tabela `ShoppingCartItems` przechowująca informacje o przedmiotach w koszyku, w tym informacje o książce, ilości egzemplarzy i łącznej cenie.

<img src="https://github.com/DawidMalarzWSEI/BookShop/blob/master/BookShop/Images/db.png">


# Dodatkowo w projekcie:
- Znajdują się kilka testów
- W folderze z kontrolerami znajduje się dodatkowo kontroler API
