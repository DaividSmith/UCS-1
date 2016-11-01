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
using UCS.Files.CSV;
using UCS.Helpers;

namespace UCS.Files.Logic
{
    internal class Globals : DataTable
    {
        #region Public Constructors

        public Globals(CSVTable table, int index) : base(table, index)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public static int GetDarkElixirDiamondCost(int resourceCount)
        {
            var result = 0;
            if (resourceCount >= 1)
            {
                if (resourceCount >= 10)
                {
                    if (resourceCount >= 100)
                    {
                        if (resourceCount >= 1000)
                        {
                            if (resourceCount >= 10000)
                            {
                                var supCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_100000")
                                                 .NumberValue;
                                var infCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_10000")
                                                 .NumberValue;
                                result = GamePlayUtil.CalculateResourceCost(100000, 10000, supCost, infCost,
                                    resourceCount);
                            }
                            else
                            {
                                var supCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_10000")
                                                 .NumberValue;
                                var infCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_1000")
                                                 .NumberValue;
                                result = GamePlayUtil.CalculateResourceCost(10000, 1000, supCost, infCost, resourceCount);
                            }
                        }
                        else
                        {
                            var supCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_1000")
                                             .NumberValue;
                            var infCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_100")
                                             .NumberValue;
                            result = GamePlayUtil.CalculateResourceCost(1000, 100, supCost, infCost, resourceCount);
                        }
                    }
                    else
                    {
                        var supCost =
                            ObjectManager.DataTables.GetGlobals()
                                         .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_100")
                                         .NumberValue;
                        var infCost =
                            ObjectManager.DataTables.GetGlobals()
                                         .GetGlobalData("DARK_ELIXIR_DIAMOND_COST_10")
                                         .NumberValue;
                        result = GamePlayUtil.CalculateResourceCost(100, 10, supCost, infCost, resourceCount);
                    }
                }
                else
                {
                    var supCost =
                        ObjectManager.DataTables.GetGlobals().GetGlobalData("DARK_ELIXIR_DIAMOND_COST_10").NumberValue;
                    var infCost =
                        ObjectManager.DataTables.GetGlobals().GetGlobalData("DARK_ELIXIR_DIAMOND_COST_1").NumberValue;
                    result = GamePlayUtil.CalculateResourceCost(10, 1, supCost, infCost, resourceCount);
                }
            }
            return result;
        }

        public static int GetResourceDiamondCost(int resourceCount, ResourceData resourceData)
        {
            var result = 0;
            if (resourceData == ObjectManager.DataTables.GetResourceByName("DarkElixir"))
            {
                result = GetDarkElixirDiamondCost(resourceCount);
            }
            else
            {
                if (resourceCount >= 1)
                {
                    if (resourceCount >= 100)
                    {
                        if (resourceCount >= 1000)
                        {
                            if (resourceCount >= 10000)
                            {
                                if (resourceCount >= 100000)
                                {
                                    if (resourceCount >= 1000000)
                                    {
                                        var supCost =
                                            ObjectManager.DataTables.GetGlobals()
                                                         .GetGlobalData("RESOURCE_DIAMOND_COST_10000000")
                                                         .NumberValue;
                                        var infCost =
                                            ObjectManager.DataTables.GetGlobals()
                                                         .GetGlobalData("RESOURCE_DIAMOND_COST_1000000")
                                                         .NumberValue;
                                        result = GamePlayUtil.CalculateResourceCost(10000000, 1000000, supCost, infCost,
                                            resourceCount);
                                    }
                                    else
                                    {
                                        var supCost =
                                            ObjectManager.DataTables.GetGlobals()
                                                         .GetGlobalData("RESOURCE_DIAMOND_COST_1000000")
                                                         .NumberValue;
                                        var infCost =
                                            ObjectManager.DataTables.GetGlobals()
                                                         .GetGlobalData("RESOURCE_DIAMOND_COST_100000")
                                                         .NumberValue;
                                        result = GamePlayUtil.CalculateResourceCost(1000000, 100000, supCost, infCost,
                                            resourceCount);
                                    }
                                }
                                else
                                {
                                    var supCost =
                                        ObjectManager.DataTables.GetGlobals()
                                                     .GetGlobalData("RESOURCE_DIAMOND_COST_100000")
                                                     .NumberValue;
                                    var infCost =
                                        ObjectManager.DataTables.GetGlobals()
                                                     .GetGlobalData("RESOURCE_DIAMOND_COST_10000")
                                                     .NumberValue;
                                    result = GamePlayUtil.CalculateResourceCost(100000, 10000, supCost, infCost,
                                        resourceCount);
                                }
                            }
                            else
                            {
                                var supCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("RESOURCE_DIAMOND_COST_10000")
                                                 .NumberValue;
                                var infCost =
                                    ObjectManager.DataTables.GetGlobals()
                                                 .GetGlobalData("RESOURCE_DIAMOND_COST_1000")
                                                 .NumberValue;
                                result = GamePlayUtil.CalculateResourceCost(10000, 1000, supCost, infCost, resourceCount);
                            }
                        }
                        else
                        {
                            var supCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("RESOURCE_DIAMOND_COST_1000")
                                             .NumberValue;
                            var infCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("RESOURCE_DIAMOND_COST_100")
                                             .NumberValue;
                            result = GamePlayUtil.CalculateResourceCost(1000, 100, supCost, infCost, resourceCount);
                        }
                    }
                    else
                    {
                        result =
                            ObjectManager.DataTables.GetGlobals().GetGlobalData("RESOURCE_DIAMOND_COST_100").NumberValue;
                    }
                }
            }
            return result;
        }

        public static int GetSpeedUpCost(int seconds)
        {
            var cost = 0;
            if (seconds >= 1)
            {
                if (seconds >= 60)
                {
                    if (seconds >= 3600)
                    {
                        if (seconds >= 86400)
                        {
                            var supCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("SPEED_UP_DIAMOND_COST_1_WEEK")
                                             .NumberValue;
                            var infCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("SPEED_UP_DIAMOND_COST_24_HOURS")
                                             .NumberValue;
                            cost = GamePlayUtil.CalculateSpeedUpCost(604800, 86400, supCost, infCost, seconds);
                        }
                        else
                        {
                            var supCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("SPEED_UP_DIAMOND_COST_24_HOURS")
                                             .NumberValue;
                            var infCost =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("SPEED_UP_DIAMOND_COST_1_HOUR")
                                             .NumberValue;
                            cost = GamePlayUtil.CalculateSpeedUpCost(86400, 3600, supCost, infCost, seconds);
                        }
                    }
                    else
                    {
                        var supCost =
                            ObjectManager.DataTables.GetGlobals()
                                         .GetGlobalData("SPEED_UP_DIAMOND_COST_1_HOUR")
                                         .NumberValue;
                        var infCost =
                            ObjectManager.DataTables.GetGlobals()
                                         .GetGlobalData("SPEED_UP_DIAMOND_COST_1_MIN")
                                         .NumberValue;
                        cost = GamePlayUtil.CalculateSpeedUpCost(3600, 60, supCost, infCost, seconds);
                    }
                }
                else
                {
                    cost =
                        ObjectManager.DataTables.GetGlobals().GetGlobalData("SPEED_UP_DIAMOND_COST_1_MIN").NumberValue;
                }
            }
            return cost;
        }

        public GlobalData GetGlobalData(string name)
        {
            return (GlobalData) GetDataByName(name);
        }

        #endregion Public Methods
    }
}