using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    /// Класс Режиссер - реализация паттерна Singleton с поддержкой нескольких категорий
    public sealed class StageDirector
    {
        // Словарь для хранения экземпляров для разных категорий
        private static Dictionary<string, StageDirector> _instances = new Dictionary<string, StageDirector>();
        private static object _lock = new object();

        public string Name { get; private set; }
        public string Category { get; private set; }

        private StageDirector(string category)
        {
            Category = category;
            // Выбираем имя в зависимости от категории
            Name = category switch
            {
                "Кино" => "Джеймс Кэмерон",
                "Театр" => "Константин Станиславский",
                _ => "Неизвестный режиссер"
            };
        }
        public static StageDirector GetInstance(string category)
        {
            lock (_lock)
            {
                // Если для этой категории еще нет режиссера - создаем
                if (!_instances.ContainsKey(category))
                {
                    _instances[category] = new StageDirector(category);
                }

                return _instances[category];
            }
        }

        public string GetInfo()
        {
            return $"Режиссер: {Name} (категория '{Category}')";
        }
    }
}