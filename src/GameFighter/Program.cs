//-----------------------------------------------------------------------------
// <copyright file="Program.cs" company="Okolo IT">
//  Copyright (c) Okolo IT. All rights reserved.
// </copyright>
// <summary> Данный файл начальной точкой программы. </summary> 
//-----------------------------------------------------------------------------
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
            Console.ReadKey();
        }
    }
}
