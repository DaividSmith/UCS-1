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
using System.Collections.Concurrent;
using System.Threading;
using UCS.PacketProcessing;

namespace UCS.Core
{
    internal class MessageManager
    {
        private static BlockingCollection<Message> m_vPackets = new BlockingCollection<Message>();
        
        /// <summary>
        ///     The loader of the MessageManager class.
        /// </summary>
        public MessageManager()
        {
            PacketProcessingDelegate packetProcessing = PacketProcessing;
            packetProcessing.BeginInvoke(null, null);
            Console.WriteLine("[UCS]    Message manager class has been Initialized.");
        }

        /// <summary>
        ///     This function process packets.
        /// </summary>
        void PacketProcessing()
        {
            while (true)
            {
                var p = m_vPackets.Take();
                ThreadPool.QueueUserWorkItem(state =>
                {
                    var m = (Message)state;
                    var m2 = m.Client.GetLevel();
                    try
                    {
                        m.Decode();
                        m.Process(m2);
                    }
                    catch (Exception e)
                    {
                    }
                }, p);
            }
        }

        private delegate void PacketProcessingDelegate();

        /// <summary>
        ///     This function handle the packet by enqueue him.
        /// </summary>
        /// <param name="p">The message/packet.</param>
        public static void ProcessPacket(Message p)
        {
            m_vPackets.Add(p);
        }
    }
}
