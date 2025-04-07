using System;
using HarmonyLib;
using GameNetcodeStuff;
using UnityEngine;
using ExtendedFlashlightRange;

/** Namespace with flashlight patch class */
namespace ExtendedFlashlightRange.Patches
{
    /* Class with flashlight patch (We patch FlashlightItem) */
    [HarmonyPatch(typeof(FlashlightItem))]
    internal class FlashlightPatch
    {
        /* We patch Update method to constantly update flashlight settings */
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void patchIntensityUpdate(ref FlashlightItem __instance)
        {
            if (__instance.flashlightBulb != null)
            {
                /* Set flashlight Intensity from config */
                __instance.flashlightBulb.intensity = ExtendedFlashlightRangeModBase.FlashlightIntensity.Value;
                
                /* Set flashlight range from config */
                __instance.flashlightBulb.range = ExtendedFlashlightRangeModBase.FlashlightRange.Value;
            }
        }
    }
    
    /* Class with PlayerControllerB patch (We patch Helmet Light) */
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        /* We patch Update method to constantly update helmet light settings */
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void patchIntensityUpdate(ref PlayerControllerB __instance)
        {
            if (__instance.helmetLight != null)
            {
                /* Set helmet light Intensity from config */
                __instance.helmetLight.intensity = ExtendedFlashlightRangeModBase.HelmetIntensity.Value;
                
                /* Set helmet light range from config */
                __instance.helmetLight.range = ExtendedFlashlightRangeModBase.HelmetRange.Value;
            }
        }
    }
}