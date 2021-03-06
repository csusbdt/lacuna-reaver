﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class ForbiddenCavernHighChest2Controller : NPCMapCharacterController
    {
        Dialog giveDialog = new Dialog(DialogPrompt.NeedsClose, Strings.ZA555);  //Declare the dialog variable

        public override void Interact()  //The interact method will activate when the player presses the A button(or the space bar) on the npc.
        {
            Party.Singleton.GameState.Inventory.AddItem(typeof(BlueMark), 1);  //Adds the Small Health Potion item to the inventory

            Party.Singleton.ModifyNPC(
                Maps.forbiddenCavernHigh,  //Select the map where the modification is applied. Current map in this case.
                "ForbiddenCavernHighChest2",  //The name of the npc being modified
                Point.Zero,  //Position where the modification is being done. Point.Zero is used when removing an npc.
                ModAction.Remove,  //Add or Remove the npc
                true);  //Is the change being done permanent? If it is set, this to true. If it's false, the modification will revert to it's original state when the player leaves the map.

            Party.Singleton.ModifyNPC(
                Maps.forbiddenCavernLow,
                "ForbiddenCavernHighChest2",
                Point.Zero,
                ModAction.Remove,
                true);

            Party.Singleton.ModifyNPC(
                Maps.forbiddenCavernHigh,
                "OpenChest2",
                new Point(12,14),  //OpenChest2 is added at position (12,14). Press D on the keyboard in the game to find the map name and the coordinates.
                ModAction.Add,
                true);

            Party.Singleton.ModifyNPC(
                Maps.forbiddenCavernLow,
                "OpenChest2",
                new Point(12, 14),
                ModAction.Add,
                true);

            ScreenManager.Singleton.AddScreen(new DialogScreen(giveDialog, DialogScreen.Location.TopLeft));  //Brings the Dialog up, Location at the topleft.

            MusicSystem.InterruptMusic(AudioCues.ChestOpen);  //adds the ChestOpen audio when you interact             
        }
    }
}

//  Each closed chest needs it's own xml. To make an xml file, go to MyQuestGameContent, characters, and then NPCMapCharacters. You will see a list of NPCMapCharacters
//that are used in the game. Find Keepf2Chest.xml and become familiar with how xml sheets work. You'll see the <name></name> trait, this is the string the code will
//expect when ModifyNPC asks for the asset name. At the bottom of the xml sheet, you'll see that the xml sheet has a <ControllerName></ControllerName>. This name will be different
//for every chest. Every chest will have idleonly set to true. 

//The easiest way to make a chest is to copy and paste the Keepf2Chest and change anything that will cause the new chest to conflict with Keepf2Chest.