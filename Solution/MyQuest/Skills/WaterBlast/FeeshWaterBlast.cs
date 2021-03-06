﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyQuest
{
    class FeeshWaterBlast : WaterBlast
    {
        public FeeshWaterBlast() : base()
        {
            Name = Strings.ZA496;
            Description = Strings.ZA497;

            MpCost = 0;
            SpCost = 0;

            SpellPower = 1.1f;
            DamageModifierValue = 0.0f;

            BattleSkill = true;
            MapSkill = false;
            HealingSkill = false;
            MagicSkill = true;
            IsBasicAttack = true;

            DrawOffset = new Vector2(-50, -50);

            TargetsAll = false;
            CanTargetAllies = false;
            CanTargetEnemy = true;
        }
    }
}