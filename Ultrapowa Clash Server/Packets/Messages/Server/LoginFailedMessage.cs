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

using Ionic.Zlib;
using System.Collections.Generic;
using System.Configuration;
using UCS.Helpers;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 20103
    internal class LoginFailedMessage : Message
    {
        public LoginFailedMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(20103);
            SetUpdateURL(ConfigurationManager.AppSettings["UpdateUrl"]);
            SetMessageVersion(2);

            // 8  : New Version
            // 10 : Maintenance
            // 11 : Banned
            // 12 : Played to long
            // 13 : Acc locked
        }

        string m_vContentURL;
        int m_vErrorCode;
        string m_vReason;
        string m_vRedirectDomain;
        int m_vRemainingTime;
        string m_vResourceFingerprintData;
        string m_vUpdateURL;

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddInt32(m_vErrorCode);
            pack.AddString(m_vResourceFingerprintData);
            pack.AddString(m_vRedirectDomain);
            pack.AddString(m_vContentURL);
            pack.AddString(m_vUpdateURL);
            pack.AddString(m_vReason);
            pack.AddInt32(m_vRemainingTime);
            pack.AddInt32(-1);
            pack.Add(0);
            pack.AddInt32(-1);
            pack.AddInt32(-1);
            pack.AddInt32(-1);
            pack.AddInt32(-1);
            if (Client.CState > 0)
                Encrypt(pack.ToArray());
            else
                SetData(pack.ToArray());
        }
        public void RemainingTime(int code)
        {
            m_vRemainingTime = code;
        }

        public void SetContentURL(string url)
        {
            m_vContentURL = url;
        }

        public void SetErrorCode(int code)
        {
            m_vErrorCode = code;
        }

        public void SetReason(string reason)
        {
            m_vReason = reason;
        }

        public void SetRedirectDomain(string domain)
        {
            m_vRedirectDomain = domain;
        }

        public void SetResourceFingerprintData(string data)
        {
            m_vResourceFingerprintData = data;
        }

        public void SetUpdateURL(string url)
        {
            m_vUpdateURL = url;
        }
    }
}