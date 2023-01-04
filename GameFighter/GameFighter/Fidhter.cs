//-----------------------------------------------------------------------------
// <copyright file="Fidhter.cs" company="Okolo IT">
//  Copyright (c) Okolo IT. All rights reserved.
// </copyright>
// <summary> 
// Данный файл служит для реализации класса истребителя. 
// </summary> 
//-----------------------------------------------------------------------------
using System;

namespace GameFighter
{
    /// <summary>
    /// Класс <c>Fidhter</c> представляет истребитель.
    /// Содержит все методы для управления.
    /// <list type="bullet">
    ///  <item>
    ///   <term>BulletCheck</term>
    ///   <description>Операция проверки наличия патров.</description>
    ///  </item>
    ///  <item>
    ///   <term>Draw</term>
    ///   <description>Операция вывода статов.</description>
    ///  </item>
    ///  <item>
    ///   <term>Fire</term>
    ///   <description>Операция выстрела.</description>
    ///  </item>
    ///  <item>
    ///   <term>Heal</term>
    ///   <description>Операция увеличения здоровья на 20%.</description>
    ///  </item>
    ///  <item>
    ///   <term>Hit</term>
    ///   <description>Операция получения урона.</description>
    ///  </item>
    ///  <item>
    ///   <term>IsAlive</term>
    ///   <description>Операция провеки наличия здоровья.</description>
    ///  </item>
    ///  <item>
    ///   <term>Recharge</term>
    ///   <description>Операция перезарядки.</description>
    ///  </item>
    /// </list>
    /// </summary>
    class Fidhter : IFidhter
    {
        private const int MAX_BULLET = 20;
        private readonly int MAX_HEALTH;

        private int armor;
        private int bullet;
        private int damage;
        private int health;

        /// <summary>
        /// Инициализирует новый экземпляр класса Fidhter.
        /// </summary>
        public Fidhter(int health, int armor, int damage)
        {
            this.MAX_HEALTH = health;
            this.health     = this.MAX_HEALTH;
            this.armor      = armor;
            this.damage     = damage;
            this.bullet     = MAX_BULLET;
        }

        /// <summary>
        /// Возвращает количество урона.
        /// </summary>
        public int Damage {
            get => damage;
        }

        /// <summary>
        /// Проверяет наличие патронов.
        /// </summary>
        /// <remarks>
        /// <return>Возвращает истинну при наличии патронов.</return>
        /// </remarks>
        public bool BulletCheck() => (this.bullet > 0);

        /// <summary>
        /// Выводит состояние истребителя.
        /// </summary>
        public string OutputtingInformationToString()
        {
            return $"показатели: Жизнь: {health} Броня: {armor} " +
                   $"Урон: {damage} Патроны: {bullet}";
        }

        /// <summary>
        /// Совершает выстрел т.е. уменьшает количество патронов на 1.
        /// </summary>
        /// <remarks>
        /// <return>Возвращает истинну при успешном выстеле.</return>
        /// </remarks>
        public bool Fire()
        {
            if (!BulletCheck())
                return false;
            bullet--;
            return true;
        }

        /// <summary>
        /// Совершает исцеление.
        /// </summary>
        /// <remarks>
        ///  <para>Увеличивает здоровье на 20%.</para>
        /// </remarks>
        public void Heal() 
        {
            this.health += (int)(MAX_HEALTH * 0.2);
            if(this.health > this.MAX_HEALTH)
                this.health = this.MAX_HEALTH;
        }

        /// <summary>
        /// Уменьшает количество здоровья на <paramref name="value"/>.
        /// </summary>
        /// <remarks>
        /// <return>Возвращает состояние выстрела.</return>
        /// </remarks>
        public ShotState Hit(int value)
        {
            Random random = new Random();
            ShotState shotState;

            if (random.Next(1, 4) == 1) {
                shotState = ShotState.Miss;
                return shotState;
            }
            
            if (random.Next(1, 10) == 2) {
                shotState = ShotState.Critical;
                value = (int)((double)value * 1.2);
            }
            else {
                shotState = ShotState.Normal;
            }
                
            if (armor > 0) {
                armor -= value;
                if (armor <= 0)
                    armor = 0;
            }
            else {
                health -= value;
                if (health <= 0) 
                    health = 0;
            }
            return shotState;
        }

        /// <summary>
        /// Проверяет наличие здоровья.
        /// </summary>
        /// <remarks>
        /// <return>Возвращает истинну при наличии здоровья.</return>
        /// </remarks>
        public bool IsAlive() => (this.health > 0);

        /// <summary>
        /// Совершает перезарядку.
        /// </summary>
        /// <remarks>
        ///  <para>Количество патронов становиться равным 20.</para>
        /// </remarks>
        public void Recharge() => this.bullet = MAX_BULLET;
    }
}