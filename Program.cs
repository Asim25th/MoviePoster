namespace MoviePoster
{
    class Program
    {
        static string[] availableFilms = new string[]
        {
            "Barbie / Барби (Warner Bros. Pictures)", "Oppenheimer / Оппенгеймер (Universal Pictures)",
            "Taylor Swift: The Eras Tour (Cinemark Theatres)", "Смешарики снимают кино (НМГ Кинопрокат)"
        };
        static string[] availableDates = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
        static int[,] cinemaHall = new int[7, 10]; // создание кинозала с 10 местами на каждом из 7 рядов
        
        static void Main(string[] args)
        {
            Random random = new Random(); // рандомное заполнение мест в кинозале как занятых (1) или свободных (0)
            for (int row = 0; row < 7; row++) // в кинозале 7 рядов
            {
                for (int seat = 0; seat < 10; seat++) // в каждом ряду в кинозале по 10 мест
                {
                    cinemaHall[row, seat] = random.Next(2);
                }
            }

            Console.WriteLine("КИНОАФИША - Программа для проверки наличия свободных мест на фильм"); // вывод информации о программе на экран
            Console.WriteLine("\nФункции программы:\n1. Выбор фильма\n2. Выбор дня\n3. Просмотр списка занятых и свободных мест");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить");
            Console.ReadKey();
            Console.Clear(); // очистка консоли от информации о программе
            chooseFilm();
        }

        static void chooseFilm() // выбор фильма
        {
            Console.WriteLine("Доступные сейчас фильмы:");
            for (int film_number = 0; film_number <= availableFilms.Length - 1; film_number++)
            {
                Console.WriteLine($"{film_number + 1}. {availableFilms[film_number]}");
            }
            Console.Write("Введите номер интересующего фильма: ");
            int filmChoice = int.Parse(Console.ReadLine());
            if (filmChoice < 1 || filmChoice > availableFilms.Length) // проверка на корректность введенных значений
            {
                Console.WriteLine("\nОШИБКА: Введенное значение не корректно. Нажмите Enter и попробуйте снова.");
                Console.ReadKey();
                Console.Clear();
                chooseFilm();
            }
            else 
            {
                Console.WriteLine();
                chooseDate(filmChoice); 
            }
        }

        static void chooseDate(int filmChoice) // выбор дня
        {
            Console.WriteLine("Свободные дни:");
            for (int day_number = 0; day_number <= availableDates.Length - 1; day_number++)
            {
                Console.WriteLine($"{day_number + 1}. {availableDates[day_number]}");
            }
            Console.Write("Введите номер удобного дня: ");
            int dayChoice = int.Parse(Console.ReadLine());
            if (dayChoice < 1 || dayChoice > availableDates.Length) // проверка на корректность введенных значений
            {
                Console.WriteLine("\nОШИБКА: Введенное значение не корректно. Нажмите Enter и попробуйте снова.");
                Console.ReadKey();
                Console.Clear();
                chooseDate(filmChoice);
            }
            else
            {
                Console.Clear();
                showSeats(cinemaHall, dayChoice, filmChoice);
            }
        }

        static void showSeats(int[,] cinemaHall, int dayChoice, int filmChoice) // просмотр списка занятых и свободных мест
        {
            Console.WriteLine($"{availableFilms[filmChoice - 1]} - {availableDates[dayChoice - 1]}");
            Console.WriteLine("\n1 - место занято, 0 - место свободно");

            Console.WriteLine("\nПлан кинозала:"); // вывод плана кинозала с отображением свободных мест как 0 и занятых мест как 1
            Console.Write("  ");
            for (int seat = 1; seat <= 10; seat++)
            {
                Console.Write($"{seat} ");
            }
            Console.WriteLine();
            int freeSeats = 0;
            int occupiedSeats = 0;
            for (int row = 0; row < 7; row++)
            {
                Console.Write($"{row + 1} ");
                for (int seat = 0; seat < 10; seat++)
                {
                    Console.Write($"{cinemaHall[row, seat]} ");
                    if (cinemaHall[row, seat] == 0)
                    {
                        freeSeats++;
                    }
                    else
                    {
                        occupiedSeats++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nКоличество свободных мест: {freeSeats}");
            Console.WriteLine($"Количество занятых мест: {occupiedSeats}");
            Console.ReadKey();
        }
    }
}