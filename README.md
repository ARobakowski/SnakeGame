<img width="928" height="614" alt="image" src="https://github.com/user-attachments/assets/6b3840cc-9b0f-4246-a13f-cabae4b0d683" />

Uruchomienie
Wymagane: .NET SDK 6 lub nowszy.

Kroki:

sklonuj repozytorium: git clone https://github.com/<org>/<repo>.git

przejdź do katalogu: cd SnakeGame

uruchom: dotnet run

Sterowanie i zasady
Strzałki: góra/dół/lewo/prawo – zmiana kierunku węża.

Wąż rośnie po zjedzeniu jedzenia.

Kolizja ze ścianą lub własnym ciałem kończy grę.

Aktualny wynik wyświetla się na dole ekranu.

Struktura
Program.cs – punkt wejścia aplikacji.

SnakeGame – pętla gry, wejście klawiszy, rysowanie, wynik i logika tury.

Snake – ruch, zmiana kierunku, wzrost, kolizje (ogonu nie usuwa się w turze jedzenia).

Food – losowanie pozycji jedzenia poza ciałem węża.

Wymagania
.NET 6+

Windows/Linux/macOS z obsługą konsoli (SetCursorPosition)
