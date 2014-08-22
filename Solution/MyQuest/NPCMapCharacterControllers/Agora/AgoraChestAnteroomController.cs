﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class AgoraChestAnteroomController : NPCMapCharacterController
    {
        Dialog giveDialog = new Dialog(DialogPrompt.NeedsClose, Strings.ZA623);
        Point chestPos;
        public void Complete()
        {
            chestPos = Party.Singleton.CurrentMap.GetNPC("AgoraChestAnteroom").TilePosition;
            Party.Singleton.GameState.Inventory.AddItem(typeof(HugeHealthPotion), 1);

            Party.Singleton.ModifyNPC(
                Party.Singleton.CurrentMap.Name,
                "AgoraChestAnteroom",  
                Point.Zero,  
                ModAction.Remove, 
                true);  

            Party.Singleton.ModifyNPC(
                Party.Singleton.CurrentMap.Name,
                "OpenChest1",
                chestPos,  
                ModAction.Add,
                true);
        }

        public override void Interact()  
        {
            Complete();
            ScreenManager.Singleton.AddScreen(new DialogScreen(giveDialog, DialogScreen.Location.TopLeft));  
            MusicSystem.InterruptMusic(AudioCues.ChestOpen);             
        }
    }
}

