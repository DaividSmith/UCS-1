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
using UCS.Helpers;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24111
    internal class AvatarNameChangeOkMessage : Message
    {
        public AvatarNameChangeOkMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24111);
            m_vServerCommandType = 0x03;
            m_vAvatarName = "";
        }

        readonly int m_vServerCommandType;
        string m_vAvatarName;

        public override void Encode()
        {
            var pack = new List<byte>();

            pack.AddInt32(m_vServerCommandType);
            pack.AddString(m_vAvatarName);
            pack.AddInt32(1);
            pack.AddInt32(-1);

            Encrypt(pack.ToArray());
        }

        public string GetAvatarName() => m_vAvatarName;

        public void SetAvatarName(string name)

        {
            m_vAvatarName = name;
        }
    }
}