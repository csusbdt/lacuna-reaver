﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class Library1Chest1Controller : NPCMapCharacterController
    {
        Dialog giveDialog = new Dialog(DialogPrompt.NeedsClose, Strings.Z128);

        public void Complete()
        {
            Party.Singleton.GameState.Inventory.AddItem(typeof(MediumHealthPotion), 1);

            Party.Singleton.ModifyNPC(
                "possessed_library_1ground",
                "Library1Chest1",
                Point.Zero,
                ModAction.Remove,
                true);

            Party.Singleton.ModifyNPC(
                "possessed_library_1ledge",
                "Library1Chest1",
                Point.Zero,
                ModAction.Remove,
                true);

            Party.Singleton.ModifyNPC(
                "possessed_library_1ledge",
                "OpenChest1",
                new Point(18, 16),
                ModAction.Add,
                true);

            Party.Singleton.ModifyNPC(
                "possessed_library_1ground",
                "OpenChest1",
                new Point(18, 16),
                ModAction.Add,
                true);
        }
        public override void Interact()
        {
            Complete();

            ScreenManager.Singleton.AddScreen(new DialogScreen(giveDialog, DialogScreen.Location.TopLeft));

            MusicSystem.InterruptMusic(AudioCues.ChestOpen);
            //SoundSystem.Play(SoundSystem.ChestOpen);
            
        }
    }
}