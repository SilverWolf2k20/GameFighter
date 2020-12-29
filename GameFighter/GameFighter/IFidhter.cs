//-----------------------------------------------------------------------------
// <copyright file="IFidhter.cs" company="SW Okolo IT">
//  Copyright (c) SW Okolo IT. All rights reserved.
// </copyright>
// <summary> 
// Данный файл служит для реализации интерфейса истребителя. 
// </summary> 
//-----------------------------------------------------------------------------

namespace GameFighter
{
    interface IFidhter
    {
        public bool BulletCheck();
        public void Draw();
        public void Heal();
        public bool Hit(int value);
        public bool IsAlive();
        public void Recharge();
    }
}