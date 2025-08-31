SnakeGame (C# Console)
Prosta gra Snake uruchamiana w konsoli, przygotowana jako projekt zespołowy z praktyką pracy na gałęziach i zgłoszeniach zmian.

<img width="974" height="507" alt="image" src="https://github.com/user-attachments/assets/b303e33a-5ae2-4cc2-89a6-577e654df91b" />



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
