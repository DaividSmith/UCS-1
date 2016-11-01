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

namespace UCS.Logic
{
    internal class GameObjectFilter
    {
        List<int> m_vIgnoredObjects;

        public void AddIgnoreObject(GameObject go)
        {
            if (m_vIgnoredObjects == null)
                m_vIgnoredObjects = new List<int>();
            m_vIgnoredObjects.Add(go.GlobalId);
        }

        public virtual bool IsComponentFilter() => false;

        public void RemoveAllIgnoreObjects()
        {
            if (m_vIgnoredObjects != null)
            {
                m_vIgnoredObjects.Clear();
                m_vIgnoredObjects = null;
            }
        }

        public bool TestGameObject(GameObject go)
        {
            var result = true;
            if (m_vIgnoredObjects != null)
            {
                result = m_vIgnoredObjects.IndexOf(go.GlobalId) == -1;
            }
            return result;
        }
    }
}