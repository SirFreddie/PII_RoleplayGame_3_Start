using System;
using System.Collections;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounter
    {
        private List<Enemy> enemies = new List<Enemy>();
        private List<Hero> heroes = new List<Hero>();

        // Agrega un enemigo al encuentro.
        public void AddEnemy(Enemy enemy)
        {
            this.enemies.Add(enemy);
        }

        // Agrega un heroe al encuentro.
        public void AddHero(Hero hero)
        {
            this.heroes.Add(hero);
        }

        // Metodo para activar el encuentro.
        public void DoEncounter()
        {
            // Verifica si hay suficientes participantes para el encuentro.
            if (this.enemies.Count <= 0 || this.heroes.Count <= 0)
            {
                Console.WriteLine($"No hay suficientes participantes para este encuentro.\nEnemigos: {this.enemies.Count}\nHeroes: {this.heroes.Count}");
            }
            else
            {
                // Mientras que haya suficientes enemigos y heroes el loop del encuentro continua.
                while (this.enemies.Count > 0 && this.heroes.Count > 0)
                {
                    enemyAttack();
                    checkAndRemoveDeadHeroes(this.heroes);
                    heroAttack();
                    checkAndRemoveDeadEnemies(this.enemies);
                    healHeroes();
                }
                printWinner();
            }
        }

        // Ataque de los enemigos.
        private void enemyAttack()
        {
            if (this.heroes.Count == 1)
            {
                foreach (Enemy enemy in this.enemies)
                {
                    this.heroes[0].ReceiveAttack(enemy.AttackValue);
                    Console.WriteLine($"{enemy.Name}:{enemy.Health} attacks {this.heroes[0].Name}:{this.heroes[0].Health}");
                }
            }
            else if (this.heroes.Count == this.enemies.Count)
            {
                for (int i = 0; i < this.heroes.Count; i++)
                {
                    this.heroes[i].ReceiveAttack(this.enemies[i].AttackValue);
                    Console.WriteLine($"{this.enemies[i].Name}:{this.enemies[i].Health} attacks {this.heroes[i].Name}:{this.heroes[i].Health}");
                }
            }
            else if (this.heroes.Count < this.enemies.Count)
            {
                for (int i = 0; i <= this.enemies.Count; i++)
                {
                    if ((i+1) >= this.enemies.Count)
                    {
                        this.heroes[i].ReceiveAttack(this.enemies[0].AttackValue);
                        Console.WriteLine($"{this.enemies[0].Name}:{this.enemies[0].Health} attacks {this.heroes[i].Name}:{this.heroes[i].Health}");
                    }
                    else
                    {
                        this.heroes[i].ReceiveAttack(this.enemies[i+1].AttackValue);
                        Console.WriteLine($"{this.enemies[i+1].Name}:{this.enemies[i+1].Health} attacks {this.heroes[i].Name}:{this.heroes[i].Health}");
                    }
                }
            }
        }

        // Ataque de los heroes.
        private void heroAttack()
        {
            foreach (Hero hero in this.heroes)
            {
                foreach (Enemy enemy in this.enemies)
                {
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine($"{enemy.Name} died!");
                    }
                    else
                    {
                        enemy.ReceiveAttack(hero.AttackValue);
                        Console.WriteLine($"{hero.Name}:{hero.Health} attacks {enemy.Name}:{enemy.Health}");   
                    }
                }
            }
        }

        // Verifica que entidades estan muertas y las quita de la lista.
        private void checkAndRemoveDeadEnemies(List<Enemy> enemyList)
        {
            enemyList.RemoveAll((enemy) => enemy.Health <= 0);
        }

        // Verifica que heroes estan muertos y los quita de la lista.
        private void checkAndRemoveDeadHeroes(List<Hero> heroList)
        {
            heroList.RemoveAll((hero) => hero.Health <= 0);
        }


        // Los heroes se curan segun sus vp.
        private void healHeroes()
        {
            foreach (Hero hero in this.heroes)
            {
                if (hero.CumulatedVp >= 5)
                {
                    hero.Cure();
                    Console.WriteLine($"{hero.Name} has been healed!");
                }
            }
        }

        // Imprime un mensaje con el ganador.
        private void printWinner()
        {
            if (this.enemies.Count > 0)
            {
                Console.WriteLine("Enemies win!");
            }
            else
            {
                Console.WriteLine("Heroes win!");
            }
        }
    }
}