﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MyQuest
{
    public class TagCutSceneB : Scene
    {
        NPCMapCharacter TagKid = Party.Singleton.CurrentMap.GetNPC("TagKid");

        public TagCutSceneB(Screen screen)
            : base(screen)
        {
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void Initialize()
        {
            SceneHelper tagKidHelper = new MoveNpcCharacterHelper(
               "TagKid",
               new Point(58, 37),
               4.0f);
            helpers.Add(tagKidHelper);

            tagKidHelper.OnCompleteEvent += new EventHandler(tagKidHelper1_OnCompleteEvent);
        }

        void tagKidHelper1_OnCompleteEvent(object sender, EventArgs e)
        {
            Party.Singleton.ModifyNPC(
          Party.Singleton.CurrentMap.Name,
          "TagKid",
          Point.Zero,
          ModAction.Remove,
          false);

            Party.Singleton.ModifyNPC(
            Party.Singleton.CurrentMap.Name,
            "TagKid",
            new Point(56, 22),
            ModAction.Add,
            false);

            Party.Singleton.PartyAchievements.Remove("taginitiatedb");
            Party.Singleton.PartyAchievements.Add("taginitiatedc");

            state = SceneState.Complete;
        }





        public override void HandleInput(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}
