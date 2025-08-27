using HarmonyLib;
// using static Obeliskial_Essentials.Essentials;
using static WeeklySelectorMod.Plugin;
// using static WeeklySelectorMod.CustomFunctions;
// using static WeeklySelectorMod.WeeklySelectorModFunctions;
// using Photon.Pun;
// using Unity.TextMeshPro;

// Make sure your namespace is the same everywhere
namespace WeeklySelectorMod
{

    [HarmonyPatch] // DO NOT REMOVE/CHANGE - This tells your plugin that this is part of the mod

    public class WeeklySelectorModPatches
    {
        public static bool devMode = false; //DevMode.Value;
        public static bool bSelectingPerk = false;
        public static bool IsHost()
        {
            return GameManager.Instance.IsMultiplayer() && NetworkManager.Instance.IsMaster();
        }




        [HarmonyPrefix]
        [HarmonyPatch(typeof(Globals), "GetWeeklyData")]
        public static void GetWeeklyDataPrefix(ref int _week)
        {
            if (ChosenWeeklyNumber == 0 || ChooseWeekly.Value == "None")
            {
                return;
            }
            LogDebug($"GetWeeklyDataPrefix setting weekly to {ChosenWeeklyNumber}");
            _week = ChosenWeeklyNumber;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(AtOManager), "GetWeeklyName")]
        public static void GetWeeklyNamePrefix(ref int _week)
        {
            if (ChosenWeeklyNumber == 0 || ChooseWeekly.Value == "None")
            {
                return;
            }
            LogDebug($"GetWeeklyNamePrefix setting weekly to {ChosenWeeklyNumber}");
            _week = ChosenWeeklyNumber;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(AtOManager), "GetWeekly")]
        public static void GetWeeklyPrefix(ref int __result)
        {
            if (ChosenWeeklyNumber == 0 || ChooseWeekly.Value == "None")
            {
                return;
            }
            LogDebug($"GetWeeklyPrefix setting weekly to {ChosenWeeklyNumber}");
            __result = ChosenWeeklyNumber;
        }



    }
}