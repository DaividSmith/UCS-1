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

namespace UCS.PacketProcessing.Messages.Client
{
    // Packet 15001
    internal class AllianceWarAttackAvatarMessage : Message
    {
        public static int PacketID = 15001;
    }
}