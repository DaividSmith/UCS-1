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
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    // Packet 14101
    internal class GoHomeMessage : Message
    {
        public GoHomeMessage(PacketProcessing.Client client, PacketReader br) : base(client, br)
        {
        }

        public override void Decode()
        {
        }

        public override void Process(Level level)
        {
            level.Tick();

            var alliance = ObjectManager.GetAlliance(level.GetPlayerAvatar().GetAllianceId());
            PacketManager.ProcessOutgoingPacket(new OwnHomeDataMessage(level.GetClient(), level));
            if (alliance != null)
                PacketManager.ProcessOutgoingPacket(new AllianceStreamMessage(level.GetClient(), alliance));
        }
    }
}
