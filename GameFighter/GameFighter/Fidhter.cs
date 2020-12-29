//-----------------------------------------------------------------------------
// <copyright file="Fidhter.cs" company="SW Okolo IT">
//  Copyright (c) SW Okolo IT. All rights reserved.
// </copyright>
// <summary> 
// Данный файл служит для реализации класса истребителя. 
// </summary> 
//-----------------------------------------------------------------------------
using System;

namespace GameFighter
{
    class Fidhter : IFidhter
    {
        private const int MAX_BULLET = 20;
        private int max_health;

        private int armor;
        private int bullet;
        private int damage;
        private int health;

        public Fidhter(int health, int armor, int damage)
        {
            this.max_health = health;
            this.health     = this.max_health;
            this.armor      = armor;
            this.damage     = damage;
            this.bullet     = MAX_BULLET;
        }

        public bool BulletCheck() => (this.bullet > 0);

        public void Draw()
        {
            Console.WriteLine($"показатели: " +
                              $"Жизнь: {health} "  +
                              $"Броня: {armor} "   +
                              $"Урон: {damage} "   +
                              $"Патроны: {bullet}");
        }

        public void Heal() => this.health += (int)(max_health * 0.2);

        public bool Hit(int value)
        {
            Random random = new Random();

            if (random.Next(1, 4) == 1)
                return false;

            if(armor > 0) {
                armor -= damage;
                if (armor <= 0)
                    armor = 0;
            }
            else {
                health -= damage;
                if (health <= 0) 
                    health = 0;
            }
            return true;
        }

        public bool IsAlive() => (this.health > 0);

        public void Recharge() => this.bullet = MAX_BULLET;

        public int Damage {
            get => damage;
        }
    }
}