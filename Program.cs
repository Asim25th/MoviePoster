namespace MoviePoster
{
    class Program
    {
        static string[] AvailableFilms = new string[]
        {
            "Barbie / Барби (Warner Bros. Pictures)", "Oppenheimer / Оппенгеймер (Universal Pictures)",
            "Taylor Swift | The Eras Tour (Cinemark Theatres)", "Смешарики снимают кино (НМГ Кинопрокат)"
        };
        static string[] AvailableDates = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
        static int[,] CinemaHall = new int[7, 10]; // создание кинозала с 10 местами на каждом из 7 рядов
        
        static void Main(string[] args)
        {
            Random random = new Random(); // рандомное заполнение мест в кинозале как занятых (1) или свободных (0)
            for (int row = 0; row < 7; row++) // в кинозале 7 рядов
            {
                for (int seat = 0; seat < 10; seat++) // в каждом ряду в кинозале по 10 мест
                {
                    CinemaHall[row, seat] = random.Next(2);
                }
            }

            Console.WriteLine("КИНОАФИША - Программа для проверки наличия свободных мест на фильм"); // вывод информации о программе на экран
            Console.WriteLine("\nФункции программы:\n1. Выбор фильма\n2. Выбор дня\n3. Просмотр списка занятых и свободных мест");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить");
            Console.ReadKey();
            Console.Clear(); // очистка консоли от информации о программе
            ChooseFilm();
        }

        static void ChooseFilm() // выбор фильма
        {
            Console.WriteLine("Доступные сейчас фильмы:");
            for (int film_number = 0; film_number <= AvailableFilms.Length - 1; film_number++)
            {
                Console.WriteLine($"{film_number + 1}. {AvailableFilms[film_number]}");
            }
            Console.Write("Введите номер интересующего фильма: ");
            int filmChoice = int.Parse(Console.ReadLine());
            if (filmChoice < 1 || filmChoice > AvailableFilms.Length) // проверка на корректность введенных значений
            {
                Console.WriteLine("\nОШИБКА: Введенное значение не корректно. Нажмите Enter и попробуйте снова.");
                Console.ReadKey();
                Console.Clear();
                ChooseFilm();
            }
            else 
            {
                Console.WriteLine();
                ChooseDate(filmChoice); 
            }
        }

        static void ChooseDate(int filmChoice) // выбор дня
        {
            Console.WriteLine("Свободные дни:");
            for (int day_number = 0; day_number <= AvailableDates.Length - 1; day_number++)
            {
                Console.WriteLine($"{day_number + 1}. {AvailableDates[day_number]}");
            }
            Console.Write("Введите номер удобного дня: ");
            int dayChoice = int.Parse(Console.ReadLine());
            if (dayChoice < 1 || dayChoice > AvailableDates.Length) // проверка на корректность введенных значений
            {
                Console.WriteLine("\nОШИБКА: Введенное значение не корректно. Нажмите Enter и попробуйте снова.");
                Console.ReadKey();
                Console.Clear();
                ChooseDate(filmChoice);
            }
            else
            {
                Console.Clear();
                ShowSeats(CinemaHall, dayChoice, filmChoice);
            }
        }

        static void ShowSeats(int[,] cinemaHall, int dayChoice, int filmChoice) // просмотр списка занятых и свободных мест
        {
            Console.WriteLine($"{AvailableFilms[filmChoice - 1]} - {AvailableDates[dayChoice - 1]}");
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