using Lab2.Models;

namespace Lab2.Factories
{
    /// Интерфейс абстрактной фабрики.
    /// Определяет методы для создания семейств связанных объектов:
    public interface IEventFactory
    {
        StageDirector CreateStageDirector();
        Spectator CreateSpectator(string type);
    }
}