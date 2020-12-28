/******************************************************************************
* Program.cs
*
* $ Id: Program.cs v 1.0 2020/12/28 19:02 $
*
* Данный файл начальной точкой программы.
*
* The following code is (c)copyright 2020, SW Okolo IT.
* ALL RIGHT RESERVED
******************************************************************************/
using System;

namespace GameFighter
{
    /// <summary>
    /// Класс <c>Program</c> представляет основной класс программы.
    /// <list type="bullet">
    ///  <item>
    ///   <term>Main</term>
    ///   <description>Операция запуска</description>
    ///  </item>
    /// </list>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Запускает программу.
        /// </summary>
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
