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
using System.Configuration;
using System.Threading;
using UCS.Core.Network;
using UCS.Core.Web;

namespace UCS.Core.Threading
{
    internal class NetworkThread
    {
        static Thread T { get; set; }

        public static void Start()
        {
            T = new Thread(() =>
            {
                new VersionChecker();
                new PacketManager();
                new MessageManager();
                new ResourcesManager();
                new ObjectManager();
                new Logger().Start();
                new Gateway().Start();
            }); T.Start();
        }
    }
}
