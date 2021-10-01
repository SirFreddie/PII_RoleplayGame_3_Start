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
                    checkAndRemoveDeadHeroes();
                    heroAttack();
                    checkAndRemoveDeadEnemies();
                    healHeroes();
                }
                printWinner();
            }
        }

        // Ataque de los enemigos.
        private void enemyAttack()
        {
            float ratio = (float) this.heroes.Count / (float) this.enemies.Count;

            for (int i = 0; i < this.enemies.Count; i++)
            {
                int target;

                // Si el ratio es < 1.0 ; hay mas enemigos que heroes.
                if (ratio < 1.0)
                {
                    target = (int) Math.Floor(i * ratio);
                }
                /*
                Si el ratio es >= 1.0 entonces tengo la misma cantidad de heroes que de enemigos (1.0)
                o mas heroes que enemigos (un numero > 1.0)
                */
                else
                {
                    target = i;
                }

                this.heroes[target].ReceiveAttack(this.enemies[i].AttackValue);
                Console.WriteLine($"{this.enemies[i].Name}:{this.enemies[i].Health} attacks {this.heroes[target].Name}:{this.heroes[target].Health}");
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
                        Console.WriteLine($"{hero.Name}:{hero.Health} attacks {enemy.Name}:{enemy.Health} DMG {hero.AttackValue}");   
                    }
                }
            }
        }

        // Verifica que entidades estan muertas y las quita de la lista.
        private void checkAndRemoveDeadEnemies()
        {
            this.enemies.RemoveAll((enemy) => enemy.Health <= 0);
        }

        // Verifica que heroes estan muertos y los quita de la lista.
        private void checkAndRemoveDeadHeroes()
        {
            this.heroes.RemoveAll((hero) => hero.Health <= 0);
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