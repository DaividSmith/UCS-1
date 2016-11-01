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
using System.IO;
using UCS.Files.Logic;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    // Packet 550
    internal class RemoveUnitsCommand : Command
    {
        public RemoveUnitsCommand(PacketReader br)
        {
            Unknown1 = br.ReadUInt32WithEndian();
            UnitTypesCount = br.ReadInt32WithEndian();

            UnitsToRemove = new List<UnitToRemove>();
            for (var i = 0; i < UnitTypesCount; i++)
            {
                var unit = (CharacterData) br.ReadDataReference();
                var count = br.ReadInt32WithEndian();
                var level = br.ReadInt32WithEndian();
                UnitsToRemove.Add(new UnitToRemove { Data = unit, Count = count, Level = level });
            }

            Unknown2 = br.ReadUInt32WithEndian();
        }

        public override void Execute(Level level)
        {
            foreach (var unit in UnitsToRemove)
            {
                List<Component> components = level.GetComponentManager().GetComponents(0);
                for (var i = 0; i < components.Count; i++)
                {
                    UnitStorageComponent c = (UnitStorageComponent)components[i];
                    if (c.GetUnitTypeIndex(unit.Data) != -1)
                    {
                        int storageCount = c.GetUnitCountByData(unit.Data);
                        if (storageCount >= unit.Count)
                        {
                            c.RemoveUnits(unit.Data, unit.Count);
                            break;
                        }
                        c.RemoveUnits(unit.Data, storageCount);
                        unit.Count -= storageCount;
                    }
                }
            }
        }

        public List<UnitToRemove> UnitsToRemove { get; set; }
        public int UnitTypesCount { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
    }

    internal class UnitToRemove
    {
        public int Count { get; set; }
        public CharacterData Data { get; set; }
        public int Level { get; set; }
    }
}
