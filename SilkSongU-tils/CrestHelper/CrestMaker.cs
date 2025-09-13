using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using SilkSongUtils;
using UnityEngine;

namespace SilksongUTils.CrestHelper
{
    [BepInPlugin("SilkUtils", "SilksongUtils", "0.0.0.0")]
    public abstract class CrestMaker : SilkSongU_tils
    {
        public static List<string> CrestList = ["Hunter", "Beast", "Witch", "Snail", "Architect", "Reaper"];

        public void NewCrest(string CrestToAdd)
        {
            CrestList.Add(CrestToAdd);
            CrestStore.StoreNewCrest(CrestToAdd,configGroup);
        }

        public bool IsUnlocked { get; set; }
        public void UnlockCrest(string CrestToUnlock)
        {
            foreach (string crest in CrestList)
            {
                if (crest != null)
                {
                    if (crest == CrestToUnlock)
                    {
                        // unlock the Crest
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
            throw new ArgumentException("That crest is either not handled, not added by an enabled dependency, or misspelled.");
        }


        public HeroControllerConfig? heroControllerConfig;
        public int CurrentCrest;
        private HeroController.ConfigGroup configGroup;
        #region SlashGameObjects
        public GameObject? activeRootObject { get; set; }
        public GameObject? slashObject { get; set; }
        public GameObject? slashUpObject { get; set; }
        public GameObject? slashAltObject { get; set; }
        public GameObject? slashDownObject { get; set; }
        public GameObject? slashDashObject { get; set; }
        public GameObject? slashWallObject { get; set; }
        #endregion

        public HeroController.ConfigGroup getConfigGroup()
        {
            if (CurrentCrest > 6)
            {
                return CrestStore.groups[CurrentCrest - 6];
            }
            else
            {
                return getConfigGroup();
            }
        }

                
        public void NewCrestBaseAttacks()
        {
            configGroup = new HeroController.ConfigGroup
            {
                //alt slashes aren't accounted for.
                Config = heroControllerConfig,
                ActiveRoot = activeRootObject,
                NormalSlashObject = slashObject,
                AlternateSlashObject = slashAltObject,
                UpSlashObject = slashUpObject,
                DownSlashObject = slashDownObject,
                DashStab = slashDashObject,
                WallSlashObject = slashWallObject
            };
            if (configGroup == null) { return; }
            configGroup.Setup();
        }
        public abstract void DashFSM();
        public abstract void NailArtFSM();
    }
}
