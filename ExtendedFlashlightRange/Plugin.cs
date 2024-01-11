using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MonoMod.ModInterop;

/* Mod namespace */
namespace ExtendedFlashlightRange
{
    /* required params for BepInEx Plugin */
    [BepInPlugin(modGUID, modName, modVersion)]

    /* Class with mod logic */
    public class ExtendedFlashlightRangeModBase : BaseUnityPlugin
    {
        /* Mod unique name */
        private const string modGUID = "PC_Principal.ExtendedFlashlightRangeMod";

        /* Mode name in store */
        private const string modName = "Extended Flashlight Range Mod";

        /* mod version */
        private const string modVersion = "1.0.0";

        /** readonly variable with harmony lib for mod */
        private readonly Harmony harmony = new Harmony(modGUID);

        /** Instance of current class */
        private static ExtendedFlashlightRangeModBase Instance;

        /* Internal log journal */
        internal ManualLogSource log_journal;
        
        /* Called when plugin initiated */
        void Awake()
        {
            /* Check if instance if not exists */
            if (Instance == null)
            {
                /* Set instance like this class */
                Instance = this;
            }

            /* Log object for current mod */
            log_journal = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            
            /* String of mod Initiated (Modname and its version) */
            log_journal.LogInfo($"{modName} initiated: v{modName}");
            
            /* Patch all with type of current class */
            harmony.PatchAll(typeof(ExtendedFlashlightRangeModBase));
        }
    }
}