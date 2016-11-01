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
using System.Net.Sockets;
using System.Threading;
using UCS.Logic;
using UCS.PacketProcessing;

namespace UCS.Core.Network
{
    internal class PacketManager : IDisposable
    {
        static readonly BlockingCollection<Message> m_vIncomingPackets = new BlockingCollection<Message>();
        static readonly BlockingCollection<Message> m_vOutgoingPackets = new BlockingCollection<Message>();

        public PacketManager()
        {
            IncomingProcessingDelegate incomingProcessing = IncomingProcessing;
            OutgoingProcessingDelegate outgoingProcessing = OutgoingProcessing;
            incomingProcessing.BeginInvoke(null, null);
            outgoingProcessing.BeginInvoke(null, null);
            Console.WriteLine("[UCS]    Packet Manager  class has been Initialized.");
        }

        public void Dispose()
        {
            m_vIncomingPackets.Dispose();
            m_vOutgoingPackets.Dispose();
        }

        public static void ProcessIncomingPacket(Message p) => m_vIncomingPackets.Add(p);

        public static void ProcessOutgoingPacket(Message p)
        {
            try
            {
                p.Encode();
                p.Process(p.Client.GetLevel());
                m_vOutgoingPackets.TryAdd(p);
            }
            catch (Exception)
            {
            }
        }

        static void IncomingProcessing()
        {
            while (true)
            {
                Message packet = m_vIncomingPackets.Take();
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Message p = (Message)state;
                    try
                    {
                        if (p.GetMessageType() != 10100)
                            p.Decrypt();
                        MessageManager.ProcessPacket(packet);
                    }
                    catch (Exception)
                    {
                    }
                }, packet);
            }
        }

        static void OutgoingProcessing()
        {
            while (true)
            {
                Message packet = m_vOutgoingPackets.Take();
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Message p = (Message)state;
                    try
                    {
                        p.Client.Socket.BeginSend(p.GetRawData(), 0, p.GetRawData().Length, 0, null, p.Client.Socket);
                    }
                    catch (Exception)
                    {
                    }
                }, packet);
            }
        }

        delegate void IncomingProcessingDelegate();

        delegate void OutgoingProcessingDelegate();
    }
}
