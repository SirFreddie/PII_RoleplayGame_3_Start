using System.Collections.Generic;
namespace RoleplayGame
{
    public class Orc : Enemy
    {
        public Orc(string name, int vpValue)
            : base(name, vpValue)
        {
            this.AddItem(new Axe());
            this.AddItem(new Axe());
        }
    }
}