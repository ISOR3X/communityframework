using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;

namespace CF
{
    /// <summary>
    /// This patches the Hatch method so when no parent can be found (which is the case when a pawn is spawned from a crafted item), it is set so the player faction. 
    /// </summary>
    [HarmonyPatch(typeof(CompHatcher))]
    [HarmonyPatch("Hatch")]
    class Hatch
    {
        public static void Prefix(CompHatcher __instance)
        {
            if (__instance.hatcheeParent == null) //If no parent is found for the hatchee, set the hatchee's faction to that of the player.
            {
                __instance.hatcheeFaction = Faction.OfPlayer;
            }
        }
    }
}
