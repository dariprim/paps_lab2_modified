using System;
using Lab2.Models;
using Lab2.Factories;
using Lab2.Builders;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Создаем фабрики для разных типов мероприятий
                IEventFactory cinemaFactory = new CinemaEventFactory();
                IEventFactory theaterFactory = new TheaterEventFactory();

                // Демонстрация 1: Создание киносеанса
                Console.WriteLine("Создание киносеанса");
                Console.WriteLine("----------------------------------------");

                Event cinemaEvent = new EventBuilder()
                    .CreateEvent("Кино: Аватар 2", 50)
                    .AssignDirector(cinemaFactory)
                    .AddSpectator(cinemaFactory, "adult", 20)
                    .AddSpectator(cinemaFactory, "loyal", 15)
                    .AddSpectator(cinemaFactory, "child", 10)
                    .Build();

                cinemaEvent.GetInfo();
                cinemaEvent.IsReadyToStart();

                // Демонстрация 2: Создание спектакля
                Console.WriteLine("\nСоздание спектакля");
                Console.WriteLine("----------------------------------------");

                Event theaterEvent = new EventBuilder()
                    .CreateEvent("Театр: Чайка", 30)
                    .AssignDirector(theaterFactory)
                    .AddSpectator(theaterFactory, "adult", 15)
                    .AddSpectator(theaterFactory, "loyal", 10)
                    .AddSpectator(theaterFactory, "child", 7)
                    .Build();

                theaterEvent.GetInfo();
                theaterEvent.IsReadyToStart();

                // Демонстрация 3: Проверка работы Singleton
                Console.WriteLine("\nПроверка Singleton");
                Console.WriteLine("----------------------------------------");

                var cinemaDirector = StageDirector.GetInstance("Кино");
                var theaterDirector = StageDirector.GetInstance("Театр");

                Console.WriteLine(cinemaDirector.GetInfo());
                Console.WriteLine(theaterDirector.GetInfo());

                // Проверяем, что это разные объекты
                Console.WriteLine($"\nЭто разные режиссеры: {cinemaDirector != theaterDirector}");

                // Демонстрация 4: Попытка создать мероприятие без режиссера
                Console.WriteLine("\nПопытка создать мероприятие без режиссера");
                Console.WriteLine("----------------------------------------");

                Event badEvent = new EventBuilder()
                    .CreateEvent("Кино: Плохой фильм", 10)
                    .AddSpectator(cinemaFactory, "adult", 5)
                    .Build();

                badEvent.GetInfo();
                badEvent.IsReadyToStart();

                // Демонстрация 5: Проверка лимитов
                Console.WriteLine("\nПроверка лимитов (попытка добавить больше зрителей)");
                Console.WriteLine("----------------------------------------");

                Event fullEvent = new EventBuilder()
                    .CreateEvent("Кино: Аншлаг", 5)
                    .AssignDirector(cinemaFactory)
                    .AddSpectator(cinemaFactory, "adult", 3)
                    .AddSpectator(cinemaFactory, "adult", 3) // Попытка добавить еще 3 при лимите 5
                    .Build();

                fullEvent.GetInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}