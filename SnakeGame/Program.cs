using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            var game = new SnakeGame(40, 20);
            game.Run();
        }
    }

    class SnakeGame
    {
        private readonly int width;
        private readonly int height;
        private readonly Snake snake;
        private readonly Food food;
        private bool isRunning = true;
        private int score = 0;

        public SnakeGame(int w, int h)
        {
            width = w;
            height = h;
            snake = new Snake(w / 2, h / 2);
            food = new Food(w, h);
        }

        public void Run()
        {
            while (isRunning)
            {
                // Input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    snake.ChangeDirection(key);
                }

                // Zdecyduj o następnym polu
                var next = snake.PeekNextHead();
                bool willEat = (next.X == food.X && next.Y == food.Y);

                // Sprawdź kolizję: ściany oraz ciało (ogon ignorujemy tylko gdy nie jemy)
                if (snake.WillCollide(next, width, height, ignoreTail: !willEat))
                {
                    isRunning = false;
                }
                else
                {
                    // Wykonaj ruch
                    snake.Move(grow: willEat);

                    // Obsłuż jedzenie
                    if (willEat)
                    {
                        score++;
                        food.Respawn(snake, width, height); // nie pojawiaj na ciele
                    }
                }

                Draw();
                Thread.Sleep(100);
            }

            GameOver();
        }

        private void Draw()
        {
            Console.Clear();

            // Ramka
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 0); Console.Write("#");
                Console.SetCursorPosition(x, height - 1); Console.Write("#");
            }
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y); Console.Write("#");
                Console.SetCursorPosition(width - 1, y); Console.Write("#");
            }

            // Jedzenie
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("*");

            // Wąż
            foreach (var p in snake.Body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("O");
            }

            // Wynik
            Console.SetCursorPosition(0, height);
            Console.Write($"Score: {score}");
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine($"Game Over! Score: {score}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }

    struct Point2
    {
        public int X;
        public int Y;
        public Point2(int x, int y) { X = x; Y = y; }
    }

    class Snake
    {
        public List<Point2> Body { get; } = new List<Point2>();
        private int dx = 1, dy = 0; // start: w prawo

        public Snake(int startX, int startY)
        {
            Body.Add(new Point2(startX, startY));
        }

        // NAPRAWA: zwracaj pierwszy element listy (pojedynczy Point2), nie całą listę
        public Point2 Head => Body[0];

        public void ChangeDirection(ConsoleKey key)
        {
            // Blokada zawrotu o 180°
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (dy == 0) { dx = 0; dy = -1; }
                    break;
                case ConsoleKey.DownArrow:
                    if (dy == 0) { dx = 0; dy = 1; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (dx == 0) { dx = -1; dy = 0; }
                    break;
                case ConsoleKey.RightArrow:
                    if (dx == 0) { dx = 1; dy = 0; }
                    break;
            }
        }

        public Point2 PeekNextHead()
        {
            return new Point2(Head.X + dx, Head.Y + dy);
        }

        public void Move(bool grow)
        {
            var next = PeekNextHead();
            Body.Insert(0, next);
            if (!grow)
            {
                // Usuń ogon tylko gdy nie jemy
                Body.RemoveAt(Body.Count - 1);
            }
        }

        // ignoreTail: true, gdy nie jemy – ogon zaraz zniknie i nie powinien liczyć się jako kolizja
        public bool WillCollide(Point2 next, int width, int height, bool ignoreTail)
        {
            // Ściany
            if (next.X <= 0 || next.X >= width - 1 || next.Y <= 0 || next.Y >= height - 1)
                return true;

            // Ciało
            int lastIndex = Body.Count - 1 - (ignoreTail ? 1 : 0);
            for (int i = 0; i < lastIndex; i++)
            {
                if (Body[i].X == next.X && Body[i].Y == next.Y)
                    return true;
            }
            return false;
        }
    }

    class Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private readonly Random rand = new Random();

        public Food(int w, int h)
        {
            Respawn(null, w, h);
        }

        public void Respawn(Snake snake, int width, int height)
        {
            // Losuj pozycję wewnątrz ramki i unikaj pozycji zajętych przez węża
            while (true)
            {
                int x = rand.Next(1, width - 1);
                int y = rand.Next(1, height - 1);

                bool onSnake = false;
                if (snake != null)
                {
                    foreach (var p in snake.Body)
                    {
                        if (p.X == x && p.Y == y) { onSnake = true; break; }
                    }
                }

                if (!onSnake)
                {
                    X = x;
                    Y = y;
                    return;
                }
            }
        }
    }
}
