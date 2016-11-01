﻿/*
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
    // Packet 524
    internal class ToggleAttackModeCommand : Command
    {
        public ToggleAttackModeCommand(PacketReader br)
        {
            /*
            BuildingId = br.ReadUInt32WithEndian(); //buildingId - 0x1DCD6500;
            Unknown1 = br.ReadByte();
            Unknown2 = br.ReadUInt32WithEndian();
            Unknown3 = br.ReadUInt32WithEndian();
            */
        }

        public uint BuildingId { get; set; }
        public byte Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
    }
}