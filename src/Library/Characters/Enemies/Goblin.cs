using System.Collections.Generic;
namespace RoleplayGame
{
    public class Goblin : Enemy
    {
        public Goblin(string name, int vpValue)
            : base(name, vpValue)
        {
            this.AddItem(new Helmet());
        }
    }
}