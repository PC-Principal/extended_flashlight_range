using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using ExtendedFlashlightRange.Patches;
using HarmonyLib;
using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using UnityEngine;

/* Mod namespace */
namespace ExtendedFlashlightRange
{
    /* required params for BepInEx Plugin */
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("ainavt.lc.lethalconfig")]

    /* Class with mod logic */
    public class ExtendedFlashlightRangeModBase : BaseUnityPlugin
    {
        /* Mod unique name */
        private const string modGUID = "PC_Principal.ExtendedFlashlightRangeMod";

        /* Mode name in store */
        private const string modName = "Extended Flashlight Range Mod";

        /* mod version */
        private const string modVersion = "1.1.1";

        /** readonly variable with harmony lib for mod */
        private readonly Harmony harmony = new Harmony(modGUID);

        /** Instance of current class */
        private static ExtendedFlashlightRangeModBase Instance;

        /* Internal log journal */
        internal ManualLogSource log_journal;

        /* Configuration entries */
        public static ConfigEntry<float> FlashlightIntensity;
        public static ConfigEntry<float> FlashlightRange;
        public static ConfigEntry<float> HelmetIntensity;
        public static ConfigEntry<float> HelmetRange;
        
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
            log_journal.LogInfo($"{modName} initiate started: v{modVersion}");

            /* Initialize configuration */
            InitializeConfig();

            /* Using try for patching game */
            try
            {
                /* Patch all with type of current class */
                harmony.PatchAll(typeof(ExtendedFlashlightRangeModBase));

                /* Patch all with type of FlashLightPatch class */
                harmony.PatchAll(typeof(FlashlightPatch));
                
                /* Patch all with type of PlayerControllerBPatch class (Here patching helmet light) */
                harmony.PatchAll(typeof(PlayerControllerBPatch));
                
                /* String of mod Initiated (Modname and its version) */
                log_journal.LogInfo($"{modName} harmony patch successfull");
            } 
            catch
            {
                /* String that says - something went wrong with harmony patching */
                log_journal.LogError($"{modName}: Error while harmony patching");
            }
        }

        private void InitializeConfig()
        {
            // Default values
            float defaultFlashlightIntensity = 2000f;
            float defaultFlashlightRange = 500f;
            float defaultHelmetIntensity = 2500f;
            float defaultHelmetRange = 800f;

            // Helmet and flashlight config items
            FlashlightIntensity = Config.Bind("Flashlight", "Intensity", defaultFlashlightIntensity, "Flashlight Intensity");
            FlashlightRange = Config.Bind("Flashlight", "Range", defaultFlashlightRange, "Flashlight Range");
            HelmetIntensity = Config.Bind("Helmet", "Intensity", defaultHelmetIntensity, "Helmet Intensity");
            HelmetRange = Config.Bind("Helmet", "Range", defaultHelmetRange, "Helmet Range");

            // Lethal config items with x2 mazimum values
            LethalConfigManager.AddConfigItem(new FloatSliderConfigItem(
                FlashlightIntensity,
                new FloatSliderOptions
                {
                    RequiresRestart = false,
                    Min = 0f,
                    Max = defaultFlashlightIntensity * 2f
                }
            ));

            LethalConfigManager.AddConfigItem(new FloatSliderConfigItem(
                FlashlightRange,
                new FloatSliderOptions
                {
                    RequiresRestart = false,
                    Min = 0f,
                    Max = defaultFlashlightRange * 2f
                }
            ));

            LethalConfigManager.AddConfigItem(new FloatSliderConfigItem(
                HelmetIntensity,
                new FloatSliderOptions
                {
                    RequiresRestart = false,
                    Min = 0f,
                    Max = defaultHelmetIntensity * 2f
                }
            ));

            LethalConfigManager.AddConfigItem(new FloatSliderConfigItem(
                HelmetRange,
                new FloatSliderOptions
                {
                    RequiresRestart = false,
                    Min = 0f,
                    Max = defaultHelmetRange * 2f
                }
            ));

            // Устанавливаем иконку и описание мода
            LethalConfigManager.SetModDescription("Configurable helmet and flashlights range and intensity - as you asked, for the Company! Pls star it on githab repo :3");
            var modIcon = ModInfo.GetModIcon();
            if (modIcon != null)
            {
                LethalConfigManager.SetModIcon(modIcon);
            }
        }
    }

    public static class ModInfo
    {
        public static Sprite GetModIcon()
        {
            // Icon download from resources
            var assembly = typeof(ModInfo).Assembly;
            using (var stream = assembly.GetManifestResourceStream("ExtendedFlashlightRange.thunderstore_package.icon.png"))
            {
                if (stream == null)
                {
                    Debug.LogWarning("Icon not found in resources");
                    return null;
                }
                
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);

                // Создаем текстуру
                var texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);

                // Создаем спрайт
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
    }
}