//-----------------------------------------------------------------------------
// <copyright file="Engine.cs" company="SW Okolo IT">
//  Copyright (c) SW Okolo IT. All rights reserved.
// </copyright>
// <summary> Данный файл служит для реализации игрового движка. </summary> 
//-----------------------------------------------------------------------------
using System;

namespace GameFighter
{
    enum PlayerAction : byte
    {
        Attack,
        Heal,
        BuyBullet,
        Exit
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
    class Engine
    {
        private const int PLAYER_ARMOR  = 50;
        private const int PLAYER_DAMAGE = 10;
        private const int PLAYER_HEALTH = 100;

        private bool            isPlaying;
        private PlayerAction    choice;
        private Fidhter         player;
        private Fidhter         computer;

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

        /// <summary>
        /// Запускает игровой движок.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///  Запускается цикл, последовательно вызывающий методы 
        ///  получения информации, изменения и прорисовки, и работающий пока
        ///  <paramref name="isPlaying"/> != false, т.е. игра не 
        ///  законченна.
        ///  </para>
        /// </remarks>
        public void Run()
        {
            Console.Write("Добро пожаловать в игру!\nДля выбора действий " +
                          "используйте цифры.\nУдачи!\n\n");
            while (this.isPlaying) {
                Draw();
                Input();
                Update();
            }
            Console.Write("Спасибо за игру!");
        }

        /// <summary>
        /// Получает информацию.
        /// </summary>
        /// <remarks>
        ///  <para>Ожидается пользовательский ввод.</para>
        /// </remarks>
        private void Input()
        {
            while (true) {
                string temp = Console.ReadLine();
                switch (temp) {
                    case "0":
                        this.choice = PlayerAction.Attack;
                        return;
                    case "1":
                        this.choice = PlayerAction.Heal;
                        return;
                    case "2":
                        this.choice = PlayerAction.BuyBullet;
                        return;
                    case "3":
                        this.choice = PlayerAction.Exit;
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        /// <summary>
        /// Получает информацию.
        /// </summary>
        /// <remarks>
        ///  <para>Обрабатывается ход игрока, происходит ход компьютера.</para>
        /// </remarks>
        private void Update()
        {
            switch (this.choice) {
                case PlayerAction.Attack:
                    this.computer.Hit(this.player.Damage);
                    break;
                case PlayerAction.Heal:
                    this.player.Heal();
                    break;
                case PlayerAction.BuyBullet:
                    this.player.Recharge();
                    break;
                case PlayerAction.Exit:
                    isPlaying = false;
                    break;
            }



            if (!player.IsAlive()) {
                Console.WriteLine("Вы проиграли...");
                isPlaying = false;
            }
            if (!computer.IsAlive()) {
                Console.WriteLine("Вы выиграли!");
                isPlaying = false;
            }
        }

        /// <summary>
        /// Выводит данные.
        /// </summary>
        /// <remarks>
        ///  <para>Выводится информация об игроках.</para>
        /// </remarks>
        private void Draw()
        {
            this.player.Draw();
            this.computer.Draw();

            Console.Write("1 - стрелять, 2 - лечиться, " + 
                          "3 - перезарядка, 4 - выход\n" + 
                          "Выберите действие: ");
        }
    }
}