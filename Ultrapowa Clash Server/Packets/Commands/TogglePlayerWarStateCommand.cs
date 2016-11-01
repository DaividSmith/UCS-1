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
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;
using UCS.Packets.Messages.Server;

namespace UCS.PacketProcessing.Commands
{
    // Packet 570
    internal class TogglePlayerWarStateCommand : Command
    {
        public TogglePlayerWarStateCommand(PacketReader br)
        {
            br.ReadInt32();
            br.ReadInt32();
        }

        public override void Execute(Level level)
        {
            /*
            var p = new PlayerWarStatusMessage();
            p.SetStatus(0);

            var a = new AvailableServerCommandMessage(level.GetClient());
            a.SetCommandId(14);
            a.SetCommand(p);
            PacketManager.ProcessOutgoingPacket(a);*/
            //TODO
        }
    }
}