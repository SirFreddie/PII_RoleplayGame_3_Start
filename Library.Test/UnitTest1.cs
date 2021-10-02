using NUnit.Framework;

namespace RoleplayGame
{
    public class Tests
    {
        [Test]
        public void TestAtaque()
        {
            Dwarf testDwarf = new Dwarf("Test Dwarf");
            Knight testKnight = new Knight("Test Knight");

            testKnight.ReceiveAttack(testDwarf.AttackValue);

            int expected = 100;
            Assert.AreEqual(expected, testKnight.Health);
        }
        
        [Test]
        public void TestAgregarHechizo()
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());

            int expected = 70;
            Assert.AreEqual(expected, book.AttackValue);
        }

        [Test]
        public void TestEncounterIgualCantidad()
        {
            Orc testOrc = new Orc("Test Orc", 5);
            Knight testKnight = new Knight("Test Knight");
            Encounter testEncounter = new Encounter();

            testEncounter.AddHero(testKnight);
            testEncounter.AddEnemy(testOrc);

            testEncounter.DoEncounter();

            int expected = 0;

            Assert.AreEqual(expected, testEncounter.EnemiesRemaining);
        }

        [Test]
        public void TestEncounterMasEnemigosQueHeroes()
        {
            Orc testOrc = new Orc("Test Orc", 5);
            Orc testOrc1 = new Orc("Test Orc 1", 5);
            Knight testKnight = new Knight("Test Knight");
            Encounter testEncounter = new Encounter();

            testEncounter.AddHero(testKnight);
            testEncounter.AddEnemy(testOrc);
            testEncounter.AddEnemy(testOrc1);

            testEncounter.DoEncounter();

            int expected = 0;

            Assert.AreEqual(expected, testEncounter.HeroesRemmaining);
        }

        [Test]
        public void TestEncounterMasHeroesQueEnemigos()
        {
            Orc testOrc = new Orc("Test Orc", 5);
            Orc testOrc1 = new Orc("Test Orc 1", 5);
            Knight testKnight = new Knight("Test Knight");
            Archer testArcher = new Archer("Test Archer");
            Dwarf testDwarf = new Dwarf("Test Dwarf");
            Encounter testEncounter = new Encounter();

            testEncounter.AddHero(testKnight);
            testEncounter.AddHero(testArcher);
            testEncounter.AddHero(testDwarf);
            testEncounter.AddEnemy(testOrc);
            testEncounter.AddEnemy(testOrc1);

            testEncounter.DoEncounter();

            int expected = 3;

            Assert.AreEqual(expected, testEncounter.HeroesRemmaining);
        }

        [Test]
        public void TestHealInEncounter()
        {
            Orc testOrc = new Orc("Test Orc", 5);
            Orc testOrc1 = new Orc("Test Orc 1", 5);
            Goblin testGoblin = new Goblin("Test Goblin", 5);
            Knight testArcher = new Knight("Test Archer");

            Encounter testEncounter = new Encounter();

            testEncounter.AddEnemy(testOrc);
            testEncounter.AddEnemy(testOrc1);
            testEncounter.AddEnemy(testGoblin);
            testEncounter.AddHero(testArcher);

            testEncounter.DoEncounter();

            int expected = 100;

            Assert.AreEqual(expected, testArcher.Health);
        }
    }
}