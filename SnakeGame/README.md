SnakeGame (C# Console)
Prosta gra Snake uruchamiana w konsoli, przygotowana jako projekt zespo�owy z praktyk� pracy na ga��ziach i zg�oszeniach zmian.

Uruchomienie
Wymagane: .NET SDK 6 lub nowszy.

Kroki:

sklonuj repozytorium: git clone https://github.com/ARobakowski/SnakeGame.git

przejd� do katalogu: cd SnakeGame

uruchom: dotnet run

Sterowanie i zasady
Strza�ki: g�ra/d�/lewo/prawo � zmiana kierunku w�a.

W�� ro�nie po zjedzeniu jedzenia.

Kolizja ze �cian� lub w�asnym cia�em ko�czy gr�.

Aktualny wynik wy�wietla si� na dole ekranu.

Struktura
Program.cs � punkt wej�cia aplikacji.

SnakeGame � p�tla gry, wej�cie klawiszy, rysowanie, wynik i logika tury.

Snake � ruch, zmiana kierunku, wzrost, kolizje (ogonu nie usuwa si� w turze jedzenia).

Food � losowanie pozycji jedzenia poza cia�em w�a.

Wymagania
.NET 6+

Windows/Linux/macOS z obs�ug� konsoli (SetCursorPosition)