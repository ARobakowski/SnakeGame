# SnakeGame (C# Console)
Prosta gra Snake uruchamiana w konsoli.

<img width="974" height="507" alt="image" src="https://github.com/user-attachments/assets/b303e33a-5ae2-4cc2-89a6-577e654df91b" />



## Uruchomienie

**Wymagane:** .NET SDK 6 lub nowszy

### Kroki:
1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/ARobakowski/SnakeGame.git
   ```

2. Przejdź do katalogu:
   ```bash
   cd SnakeGame
   ```

3. Uruchom:
   ```bash
   dotnet run
   ```

## Sterowanie i zasady

- Strzałki: góra/dół/lewo/prawo – zmiana kierunku węża
- Wąż rośnie po zjedzeniu jedzenia
- Kolizja ze ścianą lub własnym ciałem kończy grę
- Aktualny wynik wyświetla się na dole ekranu

## Struktura projektu

- **Program.cs** – punkt wejścia aplikacji
- **SnakeGame** – pętla gry, wejście klawiszy, rysowanie, wynik i logika tury
- **Snake** – ruch, zmiana kierunku, wzrost, kolizje (ogonu nie usuwa się w turze jedzenia)
- **Food** – losowanie pozycji jedzenia poza ciałem węża
