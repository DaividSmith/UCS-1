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
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    // Packet 24340
    internal class BookmarkMessage : Message
    {
        public ClientAvatar player { get; set; }
        public int i;

        public BookmarkMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24340);
            player = client.GetLevel().GetPlayerAvatar();
        }

        public override void Encode()
        {
            var data = new List<byte>();
            var list = new List<byte>();
            List<BookmarkSlot> rem = new List<BookmarkSlot>();
            foreach (BookmarkSlot p in player.BookmarkedClan)
            {
                Alliance a = ObjectManager.GetAlliance(p.Value);
                if (a != null)
                {
                    list.AddInt64(p.Value);
                    i++;
                }
                else
                {
                    rem.Add(p);
                    if (i > 0)
                        i--;
                }
            }
            data.AddInt32(i);
            data.AddRange(list);
            Encrypt(data.ToArray());
            foreach (var im in rem)
                player.BookmarkedClan.RemoveAll(t => t == im);
        }
    }
}