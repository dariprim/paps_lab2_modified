namespace Lab2.Models
{

    public class AdultTheaterSpectator : Spectator
    {
        public AdultTheaterSpectator()
        {
            Name = "Взрослый театрал";
            Age = 45;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 500₽";

        public override bool RequiresSpecialCondition() => false;
    }
    public class PensionerSpectator : Spectator
    {
        public PensionerSpectator()
        {
            Name = "Пенсионер (льготный)";
            Age = 70;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 300₽ (льготный)";

        public override bool RequiresSpecialCondition() => false;
    }
    public class ChildTheaterSpectator : Spectator
    {
        public ChildTheaterSpectator()
        {
            Name = "Ребенок (театр)";
            Age = 7;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 250₽ (нужно детское кресло)";

        public override bool RequiresSpecialCondition() => true;
    }
}