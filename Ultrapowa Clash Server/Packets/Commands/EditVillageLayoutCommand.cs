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
    // Packet 546
    internal class EditVillageLayoutCommand : Command
    {
        public EditVillageLayoutCommand(PacketReader br)
        {
            br.ReadInt32(); 
            br.ReadInt32(); 
            br.ReadInt32(); 
            br.ReadInt32(); 
            br.ReadInt32();
        }

        public override void Execute(Level level)
        {
        }
    }
}
