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
using System.Collections.Generic;
using System.Linq;
using UCS.Core;
using UCS.Helpers;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24403
    internal class GlobalPlayersMessage : Message
    {
        public GlobalPlayersMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24403);
        }

        public override void Encode()
        {
            var data = new List<byte>();
            var packet1 = new List<byte>();
            var i = 1;

            foreach (var player in ResourcesManager.GetInMemoryLevels().OrderByDescending(t => t.GetPlayerAvatar().GetScore()))
            {
                var pl = player.GetPlayerAvatar();
                if (i >= 100)
                    break;
                packet1.AddInt64(pl.GetId()); 
                packet1.AddString(pl.GetAvatarName()); 
                packet1.AddInt32(i); 
                packet1.AddInt32(pl.GetScore()); 
                packet1.AddInt32(i); 
                packet1.AddInt32(pl.GetAvatarLevel()); 
                packet1.AddInt32(100); 
                packet1.AddInt32(i); 
                packet1.AddInt32(100); 
                packet1.AddInt32(1); 
                packet1.AddInt32(pl.GetLeagueId()); 
                packet1.AddString(pl.GetUserRegion().ToUpper()); 
                packet1.AddInt64(pl.GetId()); 
                packet1.AddInt32(1); 
                packet1.AddInt32(1); 
                if (pl.GetAllianceId() > 0)
                {
                    packet1.Add(1); // 1 = Have an alliance | 0 = No alliance
                    packet1.AddInt64(pl.GetAllianceId()); 
                    packet1.AddString(ObjectManager.GetAlliance(pl.GetAllianceId()).GetAllianceName()); 
                    packet1.AddInt32(ObjectManager.GetAlliance(pl.GetAllianceId()).GetAllianceBadgeData());
                }
                else
                    packet1.Add(0);
                i++;
            }
            data.AddInt32(i - 1);
            data.AddRange(packet1);
            data.AddInt32(i - 1);
            data.AddRange(packet1);

            data.AddInt32((int) TimeSpan.FromDays(7).TotalSeconds);
            data.AddInt32(DateTime.Now.Year);
            data.AddInt32(DateTime.Now.Month);
            data.AddInt32(DateTime.Now.Year);
            data.AddInt32(DateTime.Now.Month - 1);
            Encrypt(data.ToArray());
        }
    }
}
