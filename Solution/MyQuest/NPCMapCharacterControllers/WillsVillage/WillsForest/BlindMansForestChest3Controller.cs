﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class BlindMansForestChest3Controller : NPCMapCharacterController
    {
        Dialog giveDialog = new Dialog(DialogPrompt.NeedsClose, Strings.Z486);  //Declare the dialog variable
        
        public void Complete()
        {
            Party.Singleton.GameState.Inventory.AddItem(typeof(RingOfVeneration), 1);  //Adds the RingOfVeneration item to the inventory

            Party.Singleton.ModifyNPC(
                "blind_mans_forest_2",  //Select the map where the modification is applied. Current map in this case.
                "BlindMansForestChest3",  //The name of the npc being modified
                Point.Zero,  //Position where the modification is being done. Point.Zero is used when removing an npc.
                ModAction.Remove,  //Add or Remove the npc
                true);  //Is the change being done permanent? If it is set, this to true. If it's false, the modification will revert to it's original state when the player leaves the map.

            Party.Singleton.ModifyNPC(
                "blind_mans_forest_2",
                "OpenChest3",
                new Point(2, 29),  //OpenChest3 is added at position (34,37). Press D on the keyboard in the game to find the map name and the coordinates.
                ModAction.Add,
                true);
        }

        public override void Interact()  //The interact method will activate when the player presses the A button(or the space bar) on the npc.
        {
            Complete();
            ScreenManager.Singleton.AddScreen(new DialogScreen(giveDialog, DialogScreen.Location.TopRight));  //Brings the Dialog up, Location at the topleft.
            MusicSystem.InterruptMusic(AudioCues.ChestOpen);  //adds the ChestOpen audio when you interact             
        }
    }
}

//  Each closed chest needs it's own xml. To make an xml file, go to MyQuestGameContent, characters, and then NPCMapCharacters. You will see a list of NPCMapCharacters
//that are used in the game. Find Keepf2Chest.xml and become familiar with how xml sheets work. You'll see the <name></name> trait, this is the string the code will
//expect when ModifyNPC asks for the asset name. At the bottom of the xml sheet, you'll see that the xml sheet has a <ControllerName></ControllerName>. This name will be different
//for every chest. Every chest will have idleonly set to true. 
