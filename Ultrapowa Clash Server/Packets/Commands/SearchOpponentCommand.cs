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
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Commands
{
    // Packet 700
    internal class SearchOpponentCommand : Command
    {
        public SearchOpponentCommand(PacketReader br)
        {
            br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        public override void Execute(Level level)
        {
            var l = ObjectManager.GetRandomOnlinePlayer();
            if (l != null)
            {
                l.Tick();
                PacketManager.ProcessOutgoingPacket(new EnemyHomeDataMessage(level.GetClient(), l, level));
            }
           else
                PacketManager.ProcessOutgoingPacket(new EnemyHomeDataMessage(level.GetClient(), l, level));
        }
    }
}