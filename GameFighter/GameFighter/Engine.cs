/******************************************************************************
* Engine.cs
*
* $ Id: Engine.cs v 1.0 2020/12/28 19:03 $
*
* Данный файл служит для реализации игрового движка.
*
* The following code is (c)copyright 2020, SW Okolo IT.
* ALL RIGHT RESERVED
******************************************************************************/
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
    ///  <item>
    ///   <term>Input</term>
    ///   <description>Операция получения информации</description>
    ///  </item>
    ///  <item>
    ///   <term>Update</term>
    ///   <description>Операция обработки</description>
    ///  </item>
    ///  <item>
    ///   <term>Drav</term>
    ///   <description>Операция прорисовки</description>
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
        /// Инициализирует новый экземпляр класса Engine и выводит приветсвие.
        /// </summary>
        public Engine()
        {
            isPlaying = true;

            Console.Write("Добро пожаловать в игру!\nДля выбора действий " +
                          "используйте цифры.\nУдачи!\n\n");
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
        /// Прорисовка данных.
        /// </summary>
        /// <remarks>
        ///  <para>Выводится информация об игроках.</para>
        /// </remarks>
        private void Draw() 
        { 

        }
    }
}
