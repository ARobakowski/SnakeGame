SnakeGame (C# Console)
Prosta gra Snake uruchamiana w konsoli, przygotowana jako projekt zespo³owy z praktyk¹ pracy na ga³êziach i zg³oszeniach zmian.

Uruchomienie
Wymagane: .NET SDK 6 lub nowszy.

Kroki:

sklonuj repozytorium: git clone https://github.com/ARobakowski/SnakeGame.git

przejdŸ do katalogu: cd SnakeGame

uruchom: dotnet run

Sterowanie i zasady
Strza³ki: góra/dó³/lewo/prawo – zmiana kierunku wê¿a.

W¹¿ roœnie po zjedzeniu jedzenia.

Kolizja ze œcian¹ lub w³asnym cia³em koñczy grê.

Aktualny wynik wyœwietla siê na dole ekranu.

Struktura
Program.cs – punkt wejœcia aplikacji.

SnakeGame – pêtla gry, wejœcie klawiszy, rysowanie, wynik i logika tury.

Snake – ruch, zmiana kierunku, wzrost, kolizje (ogonu nie usuwa siê w turze jedzenia).

Food – losowanie pozycji jedzenia poza cia³em wê¿a.

Wymagania
.NET 6+

Windows/Linux/macOS z obs³ug¹ konsoli (SetCursorPosition)