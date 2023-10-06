using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedBattleSystem
{
    internal class Unit
    {
        // Fields
        private int currentHp;
        private int maxHp;
        private int attackPower;
        private int healPower;
        private string unitName;
        private Random random;

        public int Hp
        {
            get { return currentHp; }
        }

        public string UnitName
        {
            get { return unitName; }
        }

        public bool IsDead
        {
            get { return currentHp <= 0; }
        }

        public Unit(int maxHp, int attackPower, int healPower, string unitName)
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp; // Starting Hp must be the maxHp value
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.WriteLine(
                unitName + " attacks " + unitToAttack.unitName + " and deals " + " damage!"
            );
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            if (IsDead)
                Console.WriteLine(unitName + " has been defeated!");
        }

        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * healPower);
            currentHp = heal + currentHp > maxHp ? maxHp : currentHp + heal;
            Console.WriteLine(unitName + " heals " + heal);
        }
    }
}
