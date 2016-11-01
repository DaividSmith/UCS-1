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

using System;
using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    // Packet 522
    internal class BuyShieldCommand : Command
    {
        public BuyShieldCommand(PacketReader br)
        {
            ShieldId = br.ReadInt32WithEndian(); 
            Unknown1 = br.ReadUInt32WithEndian();
        }

        public override void Execute(Level level)
        {
            //Console.WriteLine(ShieldId);
            //Console.WriteLine(Unknown1);
        }

        public int ShieldId { get; set; }
        public uint Unknown1 { get; set; }
    }
}
