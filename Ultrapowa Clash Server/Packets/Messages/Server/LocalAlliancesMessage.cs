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

using System.Collections.Generic;
using System.Linq;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24402
    internal class LocalAlliancesMessage : Message
    {
        List<Alliance> m_vAlliances;

        public LocalAlliancesMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24402);
            m_vAlliances = new List<Alliance>();
        }

        public override void Encode()
        {
            var packet = new List<byte>();
            var data = new List<byte>();

            var i = 1;
            foreach (var alliance in ObjectManager.GetInMemoryAlliances().OrderByDescending(t => t.GetScore()))
            {
                if (i >= 100)
                    break;
                var all = alliance.GetAllianceId();
                data.AddInt64(all);
                data.AddString(alliance.GetAllianceName());
                data.AddInt32(i);
                data.AddInt32(alliance.GetScore());
                data.AddInt32(i);
                data.AddInt32(alliance.GetAllianceBadgeData());
                data.AddInt32(alliance.GetAllianceMembers().Count);
                data.AddInt32(0);
                data.AddInt32(alliance.GetAllianceLevel());
                i++;
            }
            packet.AddInt32(i - 1);       
            packet.AddRange(data.ToArray());
            Encrypt(packet.ToArray());
        }
    }
}
