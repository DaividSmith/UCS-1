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

using System;
using System.IO;
using System.Text;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Client
{
    // Packet 14100
    internal class AttackResultMessage : Message
    {
        public AttackResultMessage(PacketProcessing.Client client, PacketReader br)
            : base(client, br)
        {

        }

        public override void Decode()
        {
            // TODO
            // Console.WriteLine("Packet Attack Result : " + Encoding.UTF8.GetString(GetData()));
        }

        public override void Process(Level level)
        {
        }
    }
}