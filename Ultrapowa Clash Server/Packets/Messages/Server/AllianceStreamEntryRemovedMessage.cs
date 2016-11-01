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

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24318
    internal class AllianceStreamEntryRemovedMessage : Message
    {
        public static int PacketID = 24318;
    }
}