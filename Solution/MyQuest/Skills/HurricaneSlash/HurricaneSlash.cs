﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    class HurricaneSlash : Skill
    {
        #region Fields

        enum WhirlwindState
        {
            Traveling,
            Impact
        }

        #endregion

        #region Frame Animations

        static readonly FrameAnimation TravelingFrames = new FrameAnimation()
        {
            FrameDelay = 0.09,
            Frames = new List<Rectangle>()
            {
                new Rectangle(0,   0, 400, 400),
                new Rectangle(400,   0, 400, 400),
                new Rectangle(800,   0, 400, 400),
                new Rectangle(1200,   0, 400, 400),
                new Rectangle(1600,   0, 400, 400),

                new Rectangle(0,   400, 400, 400),
                new Rectangle(400,   400, 400, 400),
                new Rectangle(800,   400, 400, 400),
                new Rectangle(1200,   400, 400, 400),
                new Rectangle(1600,   400, 400, 400),

                new Rectangle(0,   800, 400, 400),
                new Rectangle(400,   800, 400, 400),
            }
        };

        static readonly FrameAnimation ImpactFrames = new FrameAnimation()
        {
            FrameDelay = 0.09,
            Frames = new List<Rectangle>()
            {
                new Rectangle(800,   800, 600, 400),
                new Rectangle(1400,   800, 600, 400),
               
                new Rectangle(0,   1200, 800, 400),
                new Rectangle(800,   1200, 800, 400), 
            }
        };


        #endregion


        #region Fields


        List<CombatAnimation> whirlwindAnimations;
        int currentAnimation;

        WhirlwindState state;

        Vector2 screenPosition;

        Vector2 velocity;

        SpriteEffects effect;

        int targetsHit;




        #endregion


        #region Constructor



        public HurricaneSlash()
        {
            Name = "Hurricane Slash";
            Description = "Nathan swings his sword with the force of a hurricane, damaging all enemies";

            MpCost = 300;
            SpCost = 10;

            SpellPower = 1.5f;
            DamageModifierValue = .65f;

            BattleSkill = true;
            MapSkill = false;
            HealingSkill = false;
            MagicSkill = false;
            IsBasicAttack = false;

            TargetsAll = true;
            CanTargetAllies = false;
            CanTargetEnemy = true;

            DrawOffset = new Vector2(-230, -230);

            whirlwindAnimations = new List<CombatAnimation>()
            {
                new CombatAnimation()
                {
                    Name = "Traveling1",
                    TextureName = "gust_attack2",
                    Loop = false,
                    Animation = TravelingFrames
                },
                new CombatAnimation()
                {
                    Name = "Impact",
                    TextureName = "gust_attack2",
                    Loop = false,
                    Animation = ImpactFrames
                }
            };

            foreach (CombatAnimation anim in whirlwindAnimations)
                anim.LoadContent(ContentPath.ToSkillTextures);
        }


        #endregion

        public override void Activate(FightingCharacter actor, params FightingCharacter[] targets)
        {
            base.Activate(actor, targets);

            SubtractCost(actor);

            screenPosition = actor.ProjectileOrigin + new Vector2(150,0);

            targetsHit = 0;

            effect = (targets[0].ScreenPosition.X < screenPosition.X ? SpriteEffects.FlipHorizontally : SpriteEffects.None);

            velocity =
                (targets[0].ScreenPosition - screenPosition) / (float)TimeSpan.FromSeconds((TravelingFrames.FrameDelay * TravelingFrames.Frames.Count)).TotalMilliseconds;

            state = WhirlwindState.Traveling;
            currentAnimation = 0;
            whirlwindAnimations[currentAnimation].Play();

            SoundSystem.Play(AudioCues.Wind);
            actor.SetAnimation("Slash");
        }

        public override void Update(GameTime gameTime)
        {

         
            if (actor.CurrentAnimation.IsRunning == false)
            {
                actor.SetAnimation("Idle");
            }

            switch (state)
            {
                case WhirlwindState.Traveling:
                    whirlwindAnimations[currentAnimation].Update(gameTime.ElapsedGameTime.TotalMilliseconds);
                    screenPosition += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (whirlwindAnimations[currentAnimation].IsRunning == false)
                    {                 
                        targetsHit++;
                        if (targetsHit < targets.Count)
                        {
                            velocity = (targets[targetsHit].ScreenPosition - screenPosition) / (float)TimeSpan.FromSeconds((TravelingFrames.FrameDelay * TravelingFrames.Frames.Count)).TotalMilliseconds;

                            whirlwindAnimations[currentAnimation].Play();
                            SoundSystem.Play(AudioCues.Cloud);
                        }

                        else
                        {
                            whirlwindAnimations[++currentAnimation].Play();
                            state = WhirlwindState.Impact;
                        }
                    }
                    break;

                case WhirlwindState.Impact:
                    {
                        whirlwindAnimations[currentAnimation].Update(gameTime.ElapsedGameTime.TotalMilliseconds);
                    if (whirlwindAnimations[currentAnimation].IsRunning == false)

                        {
                            DamageModifier modifier = new DamageModifier(true, DamageModifierValue);
                            actor.AddDamageModifier(modifier);
                            DealPhysicalDamage(actor, targets.ToArray());


                            isRunning = false;
                            actor.SetAnimation("Idle");

                            SoundSystem.Play(AudioCues.MonsterHit);
                        }
                   }


                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            whirlwindAnimations[currentAnimation].Draw(spriteBatch, screenPosition + DrawOffset, effect);
        }
    }
}
