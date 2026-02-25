using System;
using Lab2.Models;
using Lab2.Factories;

namespace Lab2.Builders
{
    /// Строитель для пошагового создания мероприятия.
    /// Реализует паттерн Builder 
    /// Позволяет контролировать процесс конструирования сложного объекта.
    public class EventBuilder
    {
        private Event _event;
        public EventBuilder CreateEvent(string name, int capacity)
        {
            _event = new Event(name, capacity);
            Console.WriteLine($"Шаг 1: Создано мероприятие '{name}' (вместимость: {capacity})");
            return this; // Возвращаем себя для Fluent Interface
        }
        public EventBuilder AssignDirector(IEventFactory factory)
        {
            if (_event == null) 
                throw new InvalidOperationException("Сначала вызовите CreateEvent!");
            
            _event.Director = factory.CreateStageDirector();
            Console.WriteLine($"Шаг 2: Назначен режиссер");
            return this;
        }
        public EventBuilder AddSpectator(IEventFactory factory, string type, int count)
        {
            if (_event == null) 
                throw new InvalidOperationException("Сначала вызовите CreateEvent!");

            Console.WriteLine($"Шаг 3: Добавление {count} зрителей типа '{type}'");
            
            int added = 0;
            for (int i = 0; i < count; i++)
            {
                var spectator = factory.CreateSpectator(type);
                if (_event.AddSpectator(spectator))
                {
                    added++;
                }
                else
                {
                    break; // Прекращаем добавление, если зал полон
                }
            }
            
            Console.WriteLine($"Добавлено {added} из {count} запрошенных");
            return this;
        }
        public Event Build()
        {
            if (_event == null) 
                throw new InvalidOperationException("Событие не создано!");
            return _event;
        }
    }
}