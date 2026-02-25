using System;
using Lab2.Models;

namespace Lab2.Factories
{
    /// Конкретная фабрика для создания объектов для театра
    public class TheaterEventFactory : IEventFactory
    {
        public StageDirector CreateStageDirector()
        {
            // Вызов Singleton - всегда возвращает один и тот же экземпляр
            // для категории "Театр"
            return StageDirector.GetInstance("Театр");
        }
        public Spectator CreateSpectator(string type)
        {
            return type.ToLower() switch
            {
                "adult" => new AdultTheaterSpectator(),
                "child" => new ChildTheaterSpectator(),
                "loyal" => new PensionerSpectator(), // Льготный в театре - пенсионер
                _ => throw new ArgumentException($"Неизвестный тип зрителя для театра: {type}")
            };
        }
    }
}