﻿using Microsoft.Xna.Framework;

namespace MyQuest
{
    public class StolenItem3Controller : NPCMapCharacterController
    {
        #region Interact

        public override void Interact()
        {
            int stolenItemsCollected = Party.Singleton.GameState.Inventory.ItemCount(typeof(StolenItem));
            Party.Singleton.GameState.Inventory.AddItem(typeof(StolenItem), 1);

            SoundSystem.Play("ItemPickup"); //temporary soundeffect

            Party.Singleton.ModifyNPC(
                Party.Singleton.CurrentMap.Name,
                "StolenItem3",
                Point.Zero,
                ModAction.Remove,
                true);

        }

        #endregion

    }
}
