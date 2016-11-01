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
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    // Packet 511
    internal class RequestAllianceUnitsCommand : Command
    {
        public RequestAllianceUnitsCommand(PacketReader br)
        {
            Unknown1 = br.ReadUInt32WithEndian();
            FlagHasRequestMessage = br.ReadByte();
            if (FlagHasRequestMessage == 0x01)
                Message = br.ReadScString();
            else
                Message = "I need reinforcements !";
        }

        public override void Execute(Level level)
        {
            /*
            var player = level.GetPlayerAvatar();

            var cm = new TroopRequestStreamEntry();
            cm.SetId((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            cm.SetSenderId(player.GetId());
            cm.SetHomeId(player.GetId());
            cm.SetSenderLeagueId(player.GetLeagueId());
            cm.SetSenderName(player.GetAvatarName());
            cm.SetSenderRole(player.GetAllianceRole());
            cm.SetMessage(Message);

            var all = ObjectManager.GetAlliance(player.GetAllianceId());
            all.AddChatMessage(cm);

            foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
                if (onlinePlayer.GetPlayerAvatar().GetAllianceId() == player.GetAllianceId())
                {
                    var p = new AllianceStreamEntryMessage(onlinePlayer.GetClient());
                    p.SetStreamEntry(cm);
                    PacketManager.ProcessOutgoingPacket(p);
                }
            */
        }

        public byte FlagHasRequestMessage { get; set; }
        public string Message { get; set; }
        public int MessageLength { get; set; }
        public uint Unknown1 { get; set; }
    }
}