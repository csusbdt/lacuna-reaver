﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MyQuest
{
    class Stunned : StatusEffect
    {
        #region Constructors

        /// <summary>
        /// Constructs the Weakened status effect with a given duration.
        /// </summary>
        /// <param name="duration"></param>
        public Stunned(int turnDuration)
        {
            Name = "Stunned";
            IconName = null;
            Probability = .55f;
            TurnDuration = turnDuration;
            //PercentDamage = 0;
            //FlatDamage = 0;
            //PersistsOutOfCombat = false;
            Removable = true;
            //AttributeModifier = false;
            NegativeEffect = true;
            StatusEffectMessageColor = Color.NavajoWhite;
            //SkillName = "ParalyzingStrike";
        }

        #endregion

        public override void OnActivateEffect(FightingCharacter target)
        {
            base.OnActivateEffect(target);
            target.SetState(State.Stunned);
        }

        public override void OnStartTurn(FightingCharacter target)
        {
            base.OnStartTurn(target);
            if (TurnsRemaining == 0)
            {
                target.SetState(State.Normal);
            }
        }

        public override void OnEndCombat(FightingCharacter target)
        {
            base.OnEndCombat(target);
            target.SetState(State.Normal);
        }
    }
}
