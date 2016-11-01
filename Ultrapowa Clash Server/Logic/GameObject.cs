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
using System.Windows;
using Newtonsoft.Json.Linq;
using UCS.Files.Logic;

namespace UCS.Logic
{
    internal class GameObject
    {
        public GameObject(Data data, Level level)
        {
            m_vLevel = level;
            m_vData = data;
            m_vComponents = new List<Component>();
            for (var i = 0; i < 11; i++)
                m_vComponents.Add(new Component());
        }

        readonly List<Component> m_vComponents;
        readonly Data m_vData;
        readonly Level m_vLevel;

        public virtual int ClassId => -1;

        public int GlobalId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void AddComponent(Component c)
        {
            if (m_vComponents[c.Type].Type != -1)
            {
            }
            else
            {
                m_vLevel.GetComponentManager().AddComponent(c);
                m_vComponents[c.Type] = c;
            }
        }

        public Component GetComponent(int index, bool test)
        {
            Component result = null;
            if (!test || m_vComponents[index].IsEnabled())
                result = m_vComponents[index];
            return result;
        }

        public Data GetData() => m_vData;

        public Level GetLevel() => m_vLevel;

        public Vector GetPosition() => new Vector(X, Y);

        public virtual bool IsHero() => false;

        public void Load(JObject jsonObject)
        {
            X = jsonObject["x"].ToObject<int>();
            Y = jsonObject["y"].ToObject<int>();
            foreach (var c in m_vComponents)
                c.Load(jsonObject);
        }

        public JObject Save(JObject jsonObject)
        {
            jsonObject.Add("x", X);
            jsonObject.Add("y", Y);
            foreach (var c in m_vComponents)
                c.Save(jsonObject);
            return jsonObject;
        }

        public void SetPositionXY(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public virtual void Tick()
        {
            foreach (var comp in m_vComponents)
            {
                if (comp.IsEnabled())
                    comp.Tick();
            }
        }
    }
}