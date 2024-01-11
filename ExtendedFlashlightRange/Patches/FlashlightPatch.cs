using System;
using HarmonyLib;
using GameNetcodeStuff;
using UnityEngine;

/** Namespace with flashlight patch class */
namespace ExtendedFlashlightRange.Patches
{
    /* Class with flashlight patch (We patch FlashlightItem) */
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightPatch
    {
        /* We should add changes after method in class FlashLightItem that named is Update() with PostFix
         *Need to use ___variable if you need to overwrite variables from parent class
         *
         * todo: We need to work Here with light
         */
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void patchIntensityUpdate(ref Light ___flashlightBulb)
        {
            /* Perfect intensity always */
            ___flashlightBulb.intensity = 600f;
        }
    }
}