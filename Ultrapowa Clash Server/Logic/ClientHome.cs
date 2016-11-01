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
using Ionic.Zlib;
using UCS.Helpers;
using ZlibStream = UCS.Utilities.ZLib.ZlibStream;

namespace UCS.Logic
{
    internal class ClientHome : Base
    {
        readonly long m_vId;
        int m_vRemainingShieldTime;
        byte[] m_vSerializedVillage;

        public ClientHome() : base(0)
        {
        }

        public ClientHome(long id) : base(0)
        {
            m_vId = id;
        }

        public override byte[] Encode()
        {
            var data = new List<byte>();

            data.AddRange(base.Encode());
            data.AddInt64(m_vId);
            data.AddInt32(m_vRemainingShieldTime);
            data.AddInt32(1800);
            data.AddInt32(0);
            data.AddInt32(1200);
            data.AddInt32(60);
            data.Add(1);
            data.AddInt32(m_vSerializedVillage.Length + 4);
            data.AddRange(new byte[]
            {
                0xFF, 0xFF, 0x00, 0x00
            });
            data.AddRange(m_vSerializedVillage);

            return data.ToArray();
        }

        public byte[] GetHomeJSON() => m_vSerializedVillage;

        public void SetHomeJSON(string json)
        {
            m_vSerializedVillage = ZlibStream.CompressString(json);
        }

        public void SetShieldDurationSeconds(int seconds)
        {
            m_vRemainingShieldTime = seconds;
        }
    }
}