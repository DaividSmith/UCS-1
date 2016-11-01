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

namespace UCS.PacketProcessing.Commands
{
    // Packet 519
    internal class MissionProgressCommand : Command
    {
        public MissionProgressCommand(PacketReader br)
        {
        }

        public uint MissionId { get; set; }
        public uint Unknown1 { get; set; }
    }
}