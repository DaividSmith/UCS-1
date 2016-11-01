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
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24101
    internal class OwnHomeDataMessage : Message
    {
        public OwnHomeDataMessage(PacketProcessing.Client client, Level level) : base(client)
        {
            SetMessageType(24101);
            Player = level;
        }

        public Level Player { get; set; }

        public override void Encode()
        {
            var Avatar = Player.GetPlayerAvatar();
            var data = new List<byte>();
            var home = new ClientHome(Avatar.GetId());
            var TimeStamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            home.SetShieldDurationSeconds(Avatar.RemainingShieldTime);
            home.SetHomeJSON(Player.SaveToJSON());

            data.AddInt32(0); // 8.332
            data.AddInt32(-1); // 8.332
            //data.AddInt32(TimeStamp); // 8.551
            data.AddInt32((int) Player.GetTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds); // 8.332
            data.AddRange(home.Encode()); 
            data.AddRange(Avatar.Encode());
            data.AddInt32(200); // 8.332
            data.AddInt32(100); // 8.332
            data.AddInt32(0); // 8.332
            data.AddInt32(0); // 8.332
            data.Add(0); // 8.332 & 8.551

            Encrypt(data.ToArray());
        }
    }
}