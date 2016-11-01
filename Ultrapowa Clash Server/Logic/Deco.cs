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

using Newtonsoft.Json.Linq;
using UCS.Files.Logic;

namespace UCS.Logic
{
    internal class Deco : GameObject
    {
        Level m_vLevel;

        public Deco(Data data, Level l) : base(data, l)
        {
            m_vLevel = l;
        }

        public override int ClassId => 6;

        public DecoData GetDecoData() => (DecoData)GetData();

        public new void Load(JObject jsonObject)
        {
            base.Load(jsonObject);
        }

        public new JObject Save(JObject jsonObject)
        {
            base.Save(jsonObject);
            return jsonObject;
        }
    }
}