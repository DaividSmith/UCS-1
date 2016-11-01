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

using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    // Packet 3072
    internal class UnknownCommand : Command
    {
        public UnknownCommand(PacketReader br)
        {
            //Unknown1 = br.ReadInt32();
            //Tick = br.ReadInt32();
            //Packet = br.ReadAllBytes();
        }

        public override void Execute(Level level)
        {
            //Console.WriteLine("[CMD][0]     " + Unknown1);
            //Console.WriteLine("[CMD][0]     " + Tick);
            //Console.WriteLine("[CMD][0][FULL] " + Encoding.ASCII.GetString(Packet));
        }

        public static byte[] Packet { get; set; }
        public static int Tick { get; set; }
        public static int Unknown1 { get; set; }
    }
}