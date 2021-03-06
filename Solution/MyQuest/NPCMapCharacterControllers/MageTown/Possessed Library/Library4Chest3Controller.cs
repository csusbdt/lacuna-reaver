﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class Library4Chest3Controller : NPCMapCharacterController
    {
        Dialog giveDialog = new Dialog(DialogPrompt.NeedsClose, Strings.Z128);

        public void Complete()
        {
            Party.Singleton.GameState.Inventory.AddItem(typeof(MediumHealthPotion), 1);

            //remove closed chest from LEDGE
            Party.Singleton.ModifyNPC(
                "possessed_library_4ledge",
                "Library4Chest3",
                Point.Zero,
                ModAction.Remove,
                true);

            //remove closed chest from GROUND
            Party.Singleton.ModifyNPC(
                "possessed_library_4ground",
                "Library4Chest3",
                Point.Zero,
                ModAction.Remove,
                true);

            //remove closed chest from secret1
            Party.Singleton.ModifyNPC(
              "possessed_library_4secret1",
              "Library4Chest3",
              Point.Zero,
              ModAction.Remove,
              true);

            //remove closed chest from secret2
            Party.Singleton.ModifyNPC(
              "possessed_library_4secret2",
              "Library4Chest3",
              Point.Zero,
              ModAction.Remove,
              true);

            //remove closed chest from secret3
            Party.Singleton.ModifyNPC(
              "possessed_library_4secret3",
              "Library4Chest3",
              Point.Zero,
              ModAction.Remove,
              true);

            //place open chest on GROUND
            Party.Singleton.ModifyNPC(
                "possessed_library_4ground",
                "OpenChest3",
                new Point(2, 18),
                ModAction.Add,
                true);

            //place open chest on LEDGE
            Party.Singleton.ModifyNPC(
                "possessed_library_4ledge",
                "OpenChest3",
                new Point(2, 18),
                ModAction.Add,
                true);

            //place open chest on secret1
            Party.Singleton.ModifyNPC(
                "possessed_library_4secret1",
                "OpenChest3",
                new Point(2, 18),
                ModAction.Add,
                true);

            //place open chest on secret2
            Party.Singleton.ModifyNPC(
                "possessed_library_4secret2",
                "OpenChest3",
                new Point(2, 18),
                ModAction.Add,
                true);

            //place open chest on secret3
            Party.Singleton.ModifyNPC(
                "possessed_library_4secret3",
                "OpenChest3",
                new Point(2, 18),
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