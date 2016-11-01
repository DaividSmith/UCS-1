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
using System.IO;
using UCS.Utilities.ZLib;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24224
    internal class ReplayData : Message
    {
        public ReplayData(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24114);
        }

        public override void Encode()
        {
            var data = new List<byte>();
            string text = File.ReadAllText("replay-json.txt");
            data.AddRange(ZlibStream.CompressString(text));
            Encrypt(data.ToArray());
        }
    }
}