using System.Collections.Generic;
using BepInEx;
using MonoMod;
using MonoMod.RuntimeDetour;
using Newtonsoft.Json.Bson;
using UnityEngine;
using System;

namespace SilkSongUtils;

[BepInPlugin("SilkUtils", "SilksongUtils", "0.0.0.0")]
public class SilkSongU_tils : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        Log("Plugin SilksongUtils has loaded!");
    }


    public void Log(string message)
    {
        Logger.LogInfo(message);
    }



    
}
