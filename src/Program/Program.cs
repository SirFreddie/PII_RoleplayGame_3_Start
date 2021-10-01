using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Orc azog = new Orc("Azog", 5);
            Orc azog2 = new Orc("Azog2", 5);
            Orc azog3 = new Orc("Azog3", 5);
            Orc oli = new Orc("Oli", 5);
            Orc israel = new Orc("Israel", 5);
            Goblin gollum = new Goblin("Gollum", 5);

            Knight aragorn = new Knight("Aragorn");
            aragorn.AddItem(new Sword());
            Dwarf gimli = new Dwarf("Gimli");

            Encounter battle = new Encounter();

            battle.AddEnemy(azog);
            battle.AddEnemy(gollum);
            battle.AddEnemy(israel);
            battle.AddEnemy(azog2);
            battle.AddEnemy(oli);
            
            battle.AddHero(aragorn);
            battle.AddHero(gimli);
            //battle.AddHero(gandalf);

            battle.DoEncounter();
        }
    }
}
