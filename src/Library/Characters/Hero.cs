namespace RoleplayGame
{
    public class Hero : GenericCharacter
    {
        private int cumulatedVp = 0;

        public int CumulatedVp 
        {
            get 
            {
                return this.cumulatedVp;
            }
            set
            {
                this.cumulatedVp = value;
            }
        }

        public Hero(string name)
            : base(name)
        {
        }

        public void AddVp(Enemy enemy)
        {
            this.CumulatedVp += enemy.VpValue;
        }
    }
}