﻿// <copyright file="abaddon_death_coil.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Abilities.npc_dota_hero_abaddon
{
    using Ensage.SDK.Abilities.Components;
    using Ensage.SDK.Extensions;

    public class abaddon_death_coil : RangedAbility, IHasHealthCost, IHasHealthRestore, IAreaOfEffectAbility
    {

        public abaddon_death_coil(Ability ability)
            : base(ability)
        {
        }

        public float HealthCost
        {
            get
            {
                return this.Ability.GetAbilitySpecialDataWithTalent(this.Owner, "self_damage");
            }
        }

        public override float Speed
        {
            get
            {
                return this.Ability.GetAbilitySpecialData("missile_speed");
            }
        }

        public float TotalHealthRestore
        {
            get
            {
                return this.Ability.GetAbilitySpecialDataWithTalent(this.Owner, "heal_amount");
            }
        }

        protected override float RawDamage
        {
            get
            {
                return this.Ability.GetAbilitySpecialDataWithTalent(this.Owner, "target_damage");
            }
        }

        public float Radius
        {
            get
            {
                var talent = this.Owner.GetAbilityById(AbilityId.special_bonus_unique_abaddon_4);
                if (talent?.Level > 0)
                {
                    return talent.GetAbilitySpecialData("value");
                }

                return 0;
            }
        }
    }
}