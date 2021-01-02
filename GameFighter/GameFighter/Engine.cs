//-----------------------------------------------------------------------------
// <copyright file="Engine.cs" company="SW Okolo IT">
//  Copyright (c) SW Okolo IT. All rights reserved.
// </copyright>
// <summary> Данный файл служит для реализации игрового движка. </summary> 
//-----------------------------------------------------------------------------
using System;

namespace GameFighter
{
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
            // Работает пока не будет корректный ввод.
            while (true) {
                int temp;
                // Работает пока не будет введено число.
                while (!int.TryParse(Console.ReadLine(), out temp))
                    Console.WriteLine("Неверный ввод!");
                // Проверяет вхождение числа в диапазон.
                if (temp <= 0 && temp < (int)PlayerAction.Exit)
                    Console.WriteLine("Неверный ввод!");
                else {
                    this.choice = (PlayerAction)temp;
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
            Random random = new Random();

            // Анализ выбора игрока.
            switch (this.choice) {
                case PlayerAction.Attack:
                    // Проверка на наличие патронов.
                    if (this.player.Fire()) {
                        switch (this.computer.Hit(this.player.Damage)) {
                            // Обработка состояния урона.
                            case ShotState.Miss:
                                Console.WriteLine("Игрок промахнулся...");
                                break;
                            case ShotState.Critical:
                                Console.WriteLine("Компьютер получил критический урон.");
                                break;
                            case ShotState.Normal:
                                Console.WriteLine("Компьютер получил урон.");
                                break;
                        }
                    }
                    break;
                case PlayerAction.Heal:
                    this.player.Heal();
                    Console.WriteLine("Игрок использовал лечение.");
                    break;

                case PlayerAction.BuyBullet:
                    this.player.Recharge();
                    Console.WriteLine("Игрок купил патроны.");
                    break;

                case PlayerAction.Exit:
                    isPlaying = false;
                    // return используется чтобы закончить выполнение функции
                    // без ее дальнейшей работы.
                    return;
            }

            // Ход компьютера.
            switch (random.Next(1, 10)) {
                case (int)PlayerAction.Heal:
                    this.computer.Heal();
                    Console.WriteLine("Компьютер использовал лечение.");
                    break;
                case (int)PlayerAction.BuyBullet:
                    this.computer.Recharge();
                    Console.WriteLine("Компьютер купил патроны.");
                    break;
                default:
                    // В default был положен выстрел чтобы он совершался с 80%
                    // шансом.
                    // Проверка на наличие патронов.
                    if (this.computer.Fire()) {
                        switch (this.player.Hit(this.computer.Damage)) {
                            // Обработка состояния урона.
                            case ShotState.Miss:
                                Console.WriteLine("Компьютер промахнулся...");
                                break;
                            case ShotState.Critical:
                                Console.WriteLine("Игрок получил критический урон.");
                                break;
                            case ShotState.Normal:
                                Console.WriteLine("Игрок получил урон.");
                                break;
                        }
                    }
                    break;
            }

            // Условия победы/проигрыша
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
            Console.Write("\nИгрок ");
            this.player.Draw();
            Console.Write("Компьютер ");
            this.computer.Draw();

            Console.Write("1 - стрелять, 2 - лечиться, " + 
                          "3 - перезарядка, 4 - выход\n" + 
                          "Выберите действие: ");
        }
    }
}