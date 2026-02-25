using System;

namespace Lab2.Models
{
    public class AdultCinemaSpectator : Spectator
    {
        public AdultCinemaSpectator()
        {
            Name = "Взрослый зритель (кино)";
            Age = 35;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 350₽";

        public override bool RequiresSpecialCondition() => false;
    }
    public class StudentSpectator : Spectator
    {
        public StudentSpectator()
        {
            Name = "Студент (льготный)";
            Age = 20;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 250₽ (льготный)";

        public override bool RequiresSpecialCondition() => false;
    }
    public class ChildCinemaSpectator : Spectator
    {
        public ChildCinemaSpectator()
        {
            Name = "Ребенок (кино)";
            Age = 8;
        }

        public override string GetInfo()
            => $"{Name}, возраст: {Age} - билет 200₽ (нужна подушка-бустер)";

        public override bool RequiresSpecialCondition() => true;
    }
}