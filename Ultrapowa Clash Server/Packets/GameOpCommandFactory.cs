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
using System.Collections.Generic;
using UCS.PacketProcessing.GameOpCommands;

namespace UCS.PacketProcessing
{
    internal static class GameOpCommandFactory
    {

        static readonly Dictionary<string, Type> m_vCommands;

        static GameOpCommandFactory()
        {
            m_vCommands = new Dictionary<string, Type>();
            m_vCommands.Add("/attack", typeof(AttackGameOpCommand));
            m_vCommands.Add("/ban", typeof(BanGameOpCommand));
            m_vCommands.Add("/kick", typeof(KickGameOpCommand));
            m_vCommands.Add("/rename", typeof(RenameAvatarGameOpCommand));
            m_vCommands.Add("/setprivileges", typeof(SetPrivilegesGameOpCommand));
            m_vCommands.Add("/shutdown", typeof(ShutdownServerGameOpCommand));
            m_vCommands.Add("/unban", typeof(UnbanGameOpCommand));
            m_vCommands.Add("/visit", typeof(VisitGameOpCommand));
            m_vCommands.Add("/sysmsg", typeof(SystemMessageGameOpCommand));
            m_vCommands.Add("/id", typeof(GetIdGameopCommand));
            m_vCommands.Add("/max", typeof(MaxRessourcesCommand));
            m_vCommands.Add("/saveacc", typeof(SaveAccountGameOpCommand));
            m_vCommands.Add("/saveall", typeof(SaveAllGameOpCommand));
            m_vCommands.Add("/becomeleader", typeof(BecomeLeaderGameOpCommand));
        }

        public static object Parse(string command)
        {
            var commandArgs = command.ToLower().Split(' ');
            object result = null;
            if (commandArgs.Length > 0)
            {
                if (m_vCommands.ContainsKey(commandArgs[0]))
                {
                    var type = m_vCommands[commandArgs[0]];
                    var ctor = type.GetConstructor(new[] { typeof(string[]) });
                    result = ctor.Invoke(new object[] { commandArgs });
                }
            }
            return result;
        }

    }
}
