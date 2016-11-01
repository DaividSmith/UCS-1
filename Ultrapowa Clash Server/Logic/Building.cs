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

using UCS.Core;
using UCS.Files.Logic;

namespace UCS.Logic
{
    internal class Building : ConstructionItem
    {
        public Building(Data data, Level level) : base(data, level)
        {
            Locked = GetBuildingData().Locked;
            AddComponent(new HitpointComponent());
            if (GetBuildingData().IsHeroBarrack)
            {
                var hd = ObjectManager.DataTables.GetHeroByName(GetBuildingData().HeroType);
                AddComponent(new HeroBaseComponent(this, hd));
            }
            if (GetBuildingData().UpgradesUnits)
                AddComponent(new UnitUpgradeComponent(this));
            if (GetBuildingData().UnitProduction[0] > 0)
                AddComponent(new UnitProductionComponent(this));
            if (GetBuildingData().HousingSpace[0] > 0)
            {
                if (GetBuildingData().Bunker)
                    AddComponent(new BunkerComponent());
                else
                    AddComponent(new UnitStorageComponent(this, 0));
            }
            if (GetBuildingData().Damage[0] > 0 || GetBuildingData().BuildingClass == "Defense")
                AddComponent(new CombatComponent(this, level));
            if (GetBuildingData().ProducesResource != null && GetBuildingData().ProducesResource != string.Empty)
            {
                var s = GetBuildingData().ProducesResource;
                AddComponent(new ResourceProductionComponent(this, level));
            }
            if (GetBuildingData().MaxStoredGold[0] > 0 ||
                GetBuildingData().MaxStoredElixir[0] > 0 ||
                GetBuildingData().MaxStoredDarkElixir[0] > 0 ||
                GetBuildingData().MaxStoredWarGold[0] > 0 ||
                GetBuildingData().MaxStoredWarElixir[0] > 0 ||
                GetBuildingData().MaxStoredWarDarkElixir[0] > 0)
                AddComponent(new ResourceStorageComponent(this));
        }

        public override int ClassId => 0;

        public BuildingData GetBuildingData() => (BuildingData)GetData();
    }
}