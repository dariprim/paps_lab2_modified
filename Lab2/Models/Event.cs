using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2.Models
{
    public class Event
    {
        public string Name { get; set; }
        public StageDirector Director { get; set; }
        private List<Spectator> _spectators = new List<Spectator>();
        public int MaxCapacity { get; private set; }

        public Event(string name, int maxCapacity)
        {
            Name = name;
            MaxCapacity = maxCapacity;
        }
        public bool AddSpectator(Spectator spectator)
        {
            if (_spectators.Count >= MaxCapacity)
            {
                Console.WriteLine($"Ошибка: Лимит зала ({MaxCapacity} чел.) исчерпан. {spectator.GetInfo()} не добавлен.");
                return false;
            }

            _spectators.Add(spectator);
            return true;
        }
        public bool IsReadyToStart()
        {
            Console.WriteLine($"\nПроверка готовности: {Name}");

            // Проверка наличия режиссера
            if (Director == null)
            {
                Console.WriteLine("Мероприятие НЕ готово: не назначен режиссер!");
                return false;
            }

            Console.WriteLine($"{Director.GetInfo()}");

            // Проверка наличия зрителей
            if (!_spectators.Any())
            {
                Console.WriteLine("Мероприятие НЕ готово: нет зрителей!");
                return false;
            }

            Console.WriteLine($"Количество зрителей: {_spectators.Count}");

            // Проверка особых условий для детей
            var childrenCount = _spectators.Count(s => s.RequiresSpecialCondition());
            if (childrenCount > 0)
            {
                Console.WriteLine($" Внимание: Для {childrenCount} детей нужны особые условия.");
                Console.WriteLine($" Проверьте наличие детских кресел/подушек.");
            }

            Console.WriteLine("Мероприятие готово к началу!");
            return true;
        }
        public void GetInfo()
        {
            Console.WriteLine($"\n========== {Name} ==========");
            Console.WriteLine($"Вместимость зала: {MaxCapacity} мест");

            if (Director != null)
                Console.WriteLine(Director.GetInfo());
            else
                Console.WriteLine("Режиссер не назначен");

            Console.WriteLine($"Зрители ({_spectators.Count}):");
            if (_spectators.Any())
            {
                foreach (var s in _spectators)
                {
                    Console.WriteLine(s.GetInfo());
                }
            }
            else
            {
                Console.WriteLine("Зрителей пока нет");
            }
            Console.WriteLine("==============================\n");
        }
    }
}