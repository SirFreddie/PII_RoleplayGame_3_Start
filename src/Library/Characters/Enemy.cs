using System.Collections.Generic;

namespace RoleplayGame
{
    public class Enemy : GenericCharacter
    {
        public int VpValue { get; set; }

        public Enemy(string name, int vpValue)
            : base(name)
        {
            this.VpValue = vpValue;
        }
    }
}