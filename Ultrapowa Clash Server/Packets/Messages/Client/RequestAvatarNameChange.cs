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
    // Packet 14600
    internal class RequestAvatarNameChange : Message
    {
        public RequestAvatarNameChange(PacketProcessing.Client client, PacketReader br) : base(client, br)
        {
        }

        public string PlayerName { get; set; }

        public byte Unknown1 { get; set; }

        public override void Decode()
        {
            using (var br = new PacketReader(new MemoryStream(GetData())))
            {
                PlayerName = br.ReadScString();
            }
        }

        public override void Process(Level level)
        {
            var id = level.GetPlayerAvatar().GetId();
            var l = ResourcesManager.GetPlayer(id, true);
            if (l != null)
            {
                l.GetPlayerAvatar().SetName(PlayerName);
                var p = new AvatarNameChangeOkMessage(l.GetClient());
                p.SetAvatarName(PlayerName);
                PacketManager.ProcessOutgoingPacket(p);
            }
        }
    }
}