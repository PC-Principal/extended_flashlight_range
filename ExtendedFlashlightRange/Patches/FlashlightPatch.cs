﻿using System;
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
         * Need to use ___variable if you need to overwrite variables from parent class or __variable if need to use class
         */
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void patchIntensityUpdate(ref FlashlightItem __instance)
        {
            /* Set more powerfull flashlight Intensity */
            __instance.flashlightBulb.intensity = 2000f;
            
            /* Set large radius for flashlightBulb */
            __instance.flashlightBulb.range = 500f;
        }
    }
}