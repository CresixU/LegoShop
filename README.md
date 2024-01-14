
# Lego Shop

Projekt przedstawia aplikacje do zamówienia szablonu mozaiki z lego.


## Jak pobrać projekt

W celu pobrania projektu możesz to zrobić na przynajmniej 3 sposoby
- Kliknąć w zielony guzik po prawej stronie "Code" -> "Download ZIP"
- Pobrać GitHub Desktop i sklonować to repozytorium
- Użyć komendy w cmd `git clone https://github.com/CresixU/LegoShop` 



## Jak uruchomić projekt

- Uruchom plik `LegoShop\LegoShop.sln`
- Uruchom projekt
Teoretycznie nic więcej nie musisz robić. \
Projekt jest przystosowany do automatycznego utworznia oraz zaaktualizowania bazy danych, a także automatycznego wypełnienia jej danymi, które powinny być stałe. 

    
## Mam błąd
W aplikacji mogą wystąpić dwa napotkane rodzaje błędów
- Problem z połączeniem do serwera bazy danych lub samej bazy danych
- Problem z seederem

#### Pierwszy błąd
Można go naprawić konfigurując odpowiednio plik appsettings.json  (Szczegóły w dokumentacji) \
NAZWA_TWOJEJ_BAZY - Wklej tutaj nazwę swojej bazy MYSQL oraz w mijesce localhost nazwę serwera, lub zostaw tak jak jest jeśli nazywa się localhost.
Zazwyczaj trzeba poprawić 3 linijkę, przykładowe poprawne linijki:

    "DefaultConnection": "Server=localhost;Database=NAZWA_TWOJEJ_BAZY;MultipleActiveResultSets=true;TrustServerCertificate=True;Trusted_Connection=True"
    "DefaultConnection": "Server=localhost\\mssqllocaldb;Database=aspnet-LegoShop-15d72906-114f-4f23-a9fc-aca0233d96ff;Trusted_Connection=True;MultipleActiveResultSets=true"

Różne konfiguracje występują na branchu `Krystian` oraz `Jakub`
Spróbuj uruchomić projekt ponownie

#### Drugi błąd

Wyłącz projekt \
Zakomentuj linijkę 23 w `Program.cs` \
Kliknij Narzędzia -> Menedżer pakietów NuGet -> Konsola... \
Wpisz `update-database` \
Odkomentuj linijkę 23 w `Program.cs` \
Uruchom projekt 


## Kontakt
Discord: CresixU



