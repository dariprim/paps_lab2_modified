namespace Lab2.Models
{
    /// Абстрактный класс Зритель.
    public abstract class Spectator
    {
        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public abstract string GetInfo();

        /// Требуются ли особые условия (подушка и т.д.)
        public abstract bool RequiresSpecialCondition();
    }
}