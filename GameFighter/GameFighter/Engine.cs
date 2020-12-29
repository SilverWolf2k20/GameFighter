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
    class Engine
    {
        private bool isPlaying;

        /// <summary>
        /// Инициализирует новый экземпляр класса Engine.
        /// </summary>
        public Engine()
        {
            isPlaying = true;
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
            while (isPlaying) {
                Draw();
                Input();
                Update();
            }
        }

        /// <summary>
        /// Получает информацию.
        /// </summary>
        /// <remarks>
        ///  <para>Ожидается пользовательский ввод.</para>
        /// </remarks>
        private void Input()
        {

        }

        /// <summary>
        /// Получает информацию.
        /// </summary>
        /// <remarks>
        ///  <para>Обрабатывается ход игрока, происходит ход компьютера.</para>
        /// </remarks>
        private void Update()
        {

        }

        /// <summary>
        /// Выводит данные.
        /// </summary>
        /// <remarks>
        ///  <para>Выводится информация об игроках.</para>
        /// </remarks>
        private void Draw()
        {

        }
    }
}