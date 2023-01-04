//-----------------------------------------------------------------------------
// <copyright file="EngineCore.cs" company="Okolo IT">
//  Copyright (c) Okolo IT. All rights reserved.
// </copyright>
// <summary> Данный файл служит для реализации игрового движка. </summary> 
//-----------------------------------------------------------------------------
using System;

namespace GameFighter
{
    /// <summary>
    /// Выбор игрока.
    /// </summary>
    enum PlayerAction : byte
    {
        /// <summary>
        /// Атака.
        /// </summary>
        Attack = 1,
        /// <summary>
        /// Исцеление.
        /// </summary>
        Heal,
        /// <summary>
        /// Покупка патронов.
        /// </summary>
        BuyBullet,
        /// <summary>
        /// Выход.
        /// </summary>
        Exit
    }

    /// <summary>
    /// Состояние выстрела.
    /// </summary>
    enum ShotState : byte
    {
        /// <summary>
        /// Промах.
        /// </summary>
        Miss,
        /// <summary>
        /// Критический урон.
        /// </summary>
        Critical,
        /// <summary>
        /// Обычный урон.
        /// </summary>
        Normal
    }

    /// <summary>
    /// Класс <c>Engine</c> представляет игровой движок.
    /// Содержит все методы для работы игры.
    /// <list type="bullet">
    ///  <item>
    ///   <term>Run</term>
    ///   <description>Операция запуска</description>
    ///  </item>
    /// </list>
    /// </summary>
    /// <remarks>
    ///  <para>Это не самая лучшая реализация движка.</para>
    /// </remarks>
    partial class Engine
    {
        private const int PLAYER_ARMOR  = 50;
        private const int PLAYER_DAMAGE = 10;
        private const int PLAYER_HEALTH = 100;

        private bool isPlaying;
        private PlayerAction choice;
        private Fidhter player;
        private Fidhter computer;

        /// <summary>
        /// Инициализирует новый экземпляр класса Engine.
        /// </summary>
        public Engine()
        {
            this.isPlaying = true;
            this.player = new Fidhter(PLAYER_HEALTH,
                                      PLAYER_ARMOR,
                                      PLAYER_DAMAGE);

            Random random = new Random();

            this.computer = new Fidhter(random.Next(100, 150),
                                        random.Next(50, 100),
                                        random.Next(10, 15));
        }
    }
}
