using System;
using Lab2.Models;

namespace Lab2.Factories
{
    /// Конкретная фабрика для создания объектов для кино
    public class CinemaEventFactory : IEventFactory
    {
        public StageDirector CreateStageDirector()
        {
            // Вызов Singleton - всегда возвращает один и тот же экземпляр
            // для категории "Кино"
            return StageDirector.GetInstance("Кино");
        }

        public Spectator CreateSpectator(string type)
        {
            return type.ToLower() switch
            {
                "adult" => new AdultCinemaSpectator(),
                "child" => new ChildCinemaSpectator(),
                "loyal" => new StudentSpectator(), // Льготный в кино - студент
                _ => throw new ArgumentException($"Неизвестный тип зрителя для кино: {type}")
            };
        }
    }
}