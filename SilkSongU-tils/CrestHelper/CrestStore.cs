using System;
using System.Collections.Generic;
using System.Text;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using GO = UnityEngine.GameObject;

namespace SilksongUTils.CrestHelper
{
    internal static class CrestStore
    {

        
        public static List<HeroController.ConfigGroup> groups = new List<HeroController.ConfigGroup>();
        
        public static void StoreNewCrest(string Crest, HeroController.ConfigGroup config)
        {
            foreach (string Crests in CrestMaker.CrestList)
            {
                if (Crests == null)
                {
                    break;
                }
                else
                {
                    if (Crests == Crest)
                    {
                        groups.Add(config);  
                    }
                }
            };
        }

        public static void ReplaceCrest(string Crest, HeroController.ConfigGroup config)
        {
            if (groups == null) 
            {
                return;
            }
            else
            {
                groups[CrestMaker.CrestList.IndexOf(Crest)] = config;
            } 
        }
    }
}