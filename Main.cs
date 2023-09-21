using MelonLoader;
using BoneLib;
using HarmonyLib;
using SLZ.Bonelab;
using UnityEngine;
using System.Collections;
using System;
using System.Reflection;



namespace TutorialFixer
{
    internal partial class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Hooking.OnLevelInitialized += LevelInitialized;
        }

        /*[HarmonyPatch(typeof(SLZ.Bonelab.TutorialTrigger))]
        [HarmonyPatch("OnTriggerEnter")]
        public static class TutorialTriggerPatch
        {
            [HarmonyPostfix]
            public static void AfterTriggerEnter(Collider other, SLZ.Bonelab.TutorialTrigger __instance)
            {
                ControllerToolTip controller_left = Player.rigManager.tutorialRig.toolTip_left.GetComponent<ControllerToolTip>();
                ControllerToolTip controller_right = Player.rigManager.tutorialRig.toolTip_right.GetComponent<ControllerToolTip>();

                Vector3 bgMaxScaleNew = new Vector3(1.7711f, 0.5631f, 0.8788f);
                controller_left.max_bg_scale = bgMaxScaleNew;
                controller_right.max_bg_scale = bgMaxScaleNew;
                controller_left.target_bg_scale = bgMaxScaleNew;
                controller_right.target_bg_scale = bgMaxScaleNew;
            }

        }*/

        private static IEnumerator ExecuteAfterDelay()
        {
            yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
            TutorialRig tutorialRigInstance = Player.rigManager.tutorialRig;
            ControllerToolTip controller_left = Player.rigManager.tutorialRig.toolTip_left.GetComponent<ControllerToolTip>();
            ControllerToolTip controller_right = Player.rigManager.tutorialRig.toolTip_right.GetComponent<ControllerToolTip>();

            // Send a tutorial pop-up so the game doesnt show nothing upon entering a tooltip trigger
            TutorialRig.InputHighlight inputHighlight1 = TutorialRig.InputHighlight.none;
            TutorialRig.InputHighlight inputHighlight2 = TutorialRig.InputHighlight.none;
            TutorialRig.LocationHighlight locationHighlight1 = TutorialRig.LocationHighlight.none_l;
            TutorialRig.LocationHighlight locationHighlight2 = TutorialRig.LocationHighlight.none_r;
            TutorialRig.SpecificHand specificHand = TutorialRig.SpecificHand.both;
            bool someBool = false;
            string someString1 = "";
            string someString2 = "";
            int someInt = 1;
            float someFloat = 0.001f;
            Sprite someSprite1 = null;
            Sprite someSprite2 = null;
            AudioClip someAudioClip = null;
            TutorialTrigger someTutorialTrigger = null;

            try
            {
                tutorialRigInstance.CUSTOMTUTORIAL(inputHighlight1, inputHighlight2, locationHighlight1, locationHighlight2, specificHand, someBool, someString1, someString2, someInt, someFloat, someSprite1, someSprite2, someAudioClip, someTutorialTrigger);
                MelonLogger.Msg("Tutorial bootstrapper method invoked successfully.");
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Error starting the tutorial bootstrapper: {ex.Message}");
            }
            yield return new WaitForSeconds(0.05f); // Wait for 0.5 seconds

            Vector3 bgMaxScaleNew = new Vector3(1.7711f, 0.5631f, 0.8788f);
            controller_left.max_bg_scale = bgMaxScaleNew;
            controller_right.max_bg_scale = bgMaxScaleNew;
            controller_left.target_bg_scale = bgMaxScaleNew;
            controller_right.target_bg_scale = bgMaxScaleNew;
        }

        internal static void LevelInitialized(LevelInfo info)
        {
            MelonLogger.Msg($"BONELAB level has been loaded! Trying to fix tutorial pop-ups now...");
            if (Player.rigManager == null)
            {
                MelonLogger.Msg("Player.rigManager is null. Exiting method.");
                return;
            }

            if (Player.rigManager.tutorialRig == null)
            {
                MelonLogger.Msg("Player.rigManager.tutorialRig is null. Exiting method.");
                return;
            }

            if (Player.rigManager.tutorialRig.toolTip_left == null)
            {
                MelonLogger.Msg("Player.rigManager.tutorialRig.toolTip_left is null. Exiting method.");
                return;
            }

            if (Player.rigManager.tutorialRig.toolTip_left.GetComponent<ControllerToolTip>() == null)
            {
                MelonLogger.Msg("ControllerToolTip component not found on left controller. Exiting method.");
                return;
            }

            if (Player.rigManager.tutorialRig.toolTip_right.GetComponent<ControllerToolTip>() == null)
            {
                MelonLogger.Msg("ControllerToolTip component not found on right controller. Exiting method.");
                return;
            }

            // Start the tutorial bootstrapper
            MelonCoroutines.Start(ExecuteAfterDelay());
        }
    }
}
