﻿// <copyright file="item_force_staff.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Abilities.Items
{
    using Ensage.SDK.Abilities.Components;
    using Ensage.SDK.Extensions;

    public class item_force_staff : RangedAbility, IHasTargetModifier
    {
        public item_force_staff(Item item)
            : base(item)
        {
        }

        public float PushLength
        {
            get
            {
                return this.Ability.GetAbilitySpecialData("push_length");
            }
        }

        public float PushSpeed { get; } = 1500.0f;

        public string TargetModifierName { get; } = "modifier_item_forcestaff_active";
    }
}