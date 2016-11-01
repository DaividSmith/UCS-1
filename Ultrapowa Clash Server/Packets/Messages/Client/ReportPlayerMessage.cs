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

namespace UCS.PacketProcessing.Messages.Client
{
    // Packet 10117
    internal class ReportPlayerMessage : Message
    {
        public ReportPlayerMessage(PacketProcessing.Client client, PacketReader br) : base(client, br)
        {
        }

        public int unknown { get; set; }
        public int unknown2 { get; set; }
        public int unknown3 { get; set; }
        public int unknown4 { get; set; }

        public override void Decode()
        {
            using (var br = new PacketReader(new MemoryStream(GetData())))
            {
                unknown = br.ReadInt32();
                unknown2 = br.ReadInt32();
                unknown3 = br.ReadInt32();
                unknown4 = br.ReadInt32();

                /*
                Console.WriteLine("Unknown1: " + unknown);
                Console.WriteLine("Unknown2: " + unknown2);
                Console.WriteLine("Alliance ID: " + unknown3);
                Console.WriteLine("Unknown4: " + unknown4);
                */
            }
        }

        public override void Process(Level level)
        {
        }
    }
}