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
         * Need to use ___variable if you need to overwrite variables from parent class or __variable if instance class
         *
         * todo: We need to work Here with light
         */
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void patchIntensityUpdate(ref FlashlightItem __instance)
        {
            /* Always 0 - flashlightInterferenceLevel */
            __instance.flashlightInterferenceLevel = 0;
            
            /* Perfect intensity always */
            __instance.flashlightBulb.intensity = 600f;
            
            /** Extend flashlight Range (Work thing) */
            __instance.flashlightBulb.range = __instance.flashlightBulb.range * 20;
        }
    }
}