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
    // Packet 20104
    internal class LoginOkMessage : Message
    {
        public LoginOkMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(20104);
        }

        readonly string m_vFacebookAppID = "297484437009394";
        string m_vAccountCreatedDate;
        long m_vAccountId;
        int m_vContentVersion;
        string m_vCountryCode;
        int m_vDaysSinceStartedPlaying;
        string m_vFacebookId;
        string m_vGamecenterId;
        int m_vGoogleID;
        int m_vLastUpdate;
        string m_vPassToken;
        int m_vPlayTimeSeconds;
        int m_vServerBuild;
        string m_vServerEnvironment;
        int m_vServerMajorVersion;
        string m_vServerTime;
        int m_vSessionCount;
        int m_vStartupCooldownSeconds;

        public string Unknown11 { get; set; }

        public string Unknown9 { get; set; }

        public override void Encode()
        {
            List<byte> pack = new List<byte>();

            pack.AddInt64(m_vAccountId);
            pack.AddInt64(m_vAccountId);
            pack.AddString(m_vPassToken);
            pack.AddString(m_vFacebookId);
            pack.AddString(m_vGamecenterId);
            pack.AddInt32(m_vServerMajorVersion);
            pack.AddInt32(m_vServerBuild);
            pack.AddInt32(m_vContentVersion);
            pack.AddString(m_vServerEnvironment);
            pack.AddInt32(m_vSessionCount);
            pack.AddInt32(m_vPlayTimeSeconds);
            pack.AddInt32(0);
            pack.AddString(m_vFacebookAppID);
            pack.AddString(m_vStartupCooldownSeconds.ToString());
            pack.AddString(m_vAccountCreatedDate);
            pack.AddInt32(0);
            pack.AddString(m_vGoogleID.ToString());
            pack.AddString(null);
            pack.AddString(m_vCountryCode);
            pack.AddString("someid2");

            /* // DEBUG INFO
            Console.WriteLine("Account ID : " + m_vAccountId);
            Console.WriteLine("User Token : " + m_vPassToken);
            Console.WriteLine("FacebookID : " + m_vFacebookId);
            Console.WriteLine("GameCenter : " + m_vGamecenterId);
            Console.WriteLine("MajorVers  : " + m_vServerMajorVersion);
            Console.WriteLine("MinorVers  : " + m_vServerBuild);
            Console.WriteLine("RevisionV  : " + m_vContentVersion);
            Console.WriteLine("LoginCount : " + m_vSessionCount);
            Console.WriteLine("PlayTime S : " + m_vPlayTimeSeconds);
            Console.WriteLine("FB APP ID  : " + m_vFacebookAppID.ToString());
            Console.WriteLine("Cooldown S : " + m_vStartupCooldownSeconds.ToString());
            Console.WriteLine("CreateDate : " + m_vAccountCreatedDate);
            Console.WriteLine("Google ID  : " + m_vGoogleID);
            Console.WriteLine("CountryCod : " + m_vCountryCode);
            Console.WriteLine("Environne  : " + m_vServerEnvironment);
            // END DEBUG */

            Encrypt(pack.ToArray());
        }

        public void SetAccountCreatedDate(string date)
        {
            m_vAccountCreatedDate = date;
        }

        public void SetAccountId(long id)
        {
            m_vAccountId = id;
        }

        public void SetContentVersion(int version)
        {
            m_vContentVersion = version;
        }

        public void SetCountryCode(string code)
        {
            m_vCountryCode = code;
        }

        public void SetDaysSinceStartedPlaying(int days)
        {
            m_vDaysSinceStartedPlaying = days;
        }

        public void SetFacebookId(string id)
        {
            m_vFacebookId = id;
        }

        public void SetGamecenterId(string id)
        {
            m_vGamecenterId = id;
        }

        public void SetPassToken(string token)
        {
            m_vPassToken = token;
        }

        public void SetPlayTimeSeconds(int seconds)
        {
            m_vPlayTimeSeconds = seconds;
        }

        public void SetServerBuild(int build)
        {
            m_vServerBuild = build;
        }

        public void SetServerEnvironment(string env)
        {
            m_vServerEnvironment = env;
        }

        public void SetServerMajorVersion(int version)
        {
            m_vServerMajorVersion = version;
        }

        public void SetServerTime(string time)
        {
            m_vServerTime = time;
        }

        public void SetSessionCount(int count)
        {
            m_vSessionCount = count;
        }

        public void SetStartupCooldownSeconds(int seconds)
        {
            m_vStartupCooldownSeconds = seconds;
        }
    }
}
