/*
 * Program : Ultrapowa Clash Server
 * Description : A C# Writted 'Clash of Clans' Server Emulator !
 *
 * Authors:  Jean-Baptiste Martin <Ultrapowa at Ultrapowa.com>,
 *           And the Official Ultrapowa Developement Team
 *
 * Copyright (c) 2016  UltraPowa
 * All Rights Reserved.
 */

namespace UCS.Logic
{
    internal class NpcLevel
    {
        int m_vType = 0x01036640;
        int Id => m_vType + Index;
        int Index { get; set; }
        int LootedElixir { get; set; }
        int LootedGold { get; set; }
        string Name { get; set; }
        int Stars { get; set; }

        public NpcLevel()
        {
        }

        public NpcLevel(int index)
        {
            Index = index;
            Stars = 0;
            LootedGold = 0;
            LootedElixir = 0;
        }
    }
}