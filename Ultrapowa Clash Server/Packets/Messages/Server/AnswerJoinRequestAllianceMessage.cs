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

using System.Collections.Generic;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24317
    internal class AnswerJoinRequestAllianceMessage : Message
    {
        public AnswerJoinRequestAllianceMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24317);
        }

        public override void Encode()
        {
            var pack = new List<byte>();
            Encrypt(pack.ToArray());
        }
    }
}