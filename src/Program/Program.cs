using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Orc azog = new Orc("Azog", 5);
            Orc oli = new Orc("Oli", 2);
            Orc israel = new Orc("Israel", 5);
            Goblin gollum = new Goblin("Gollum", 1);

            Knight aragorn = new Knight("Aragorn");
            Dwarf gimli = new Dwarf("Gimli");

            Encounter battle = new Encounter();

            battle.AddEnemy(azog);
            battle.AddEnemy(gollum);
            battle.AddHero(aragorn);
            battle.AddHero(gimli);
 
            battle.DoEncounter();
        }
    }
}
