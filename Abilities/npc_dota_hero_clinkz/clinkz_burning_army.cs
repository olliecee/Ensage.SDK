// <copyright file="clinkz_burning_army.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Abilities.npc_dota_hero_clinkz
{
        using System;

    using Ensage.SDK.Extensions;

    using SharpDX;

    public class clinkz_burning_army : LineAbility
    {
        public clinkz_burning_army(Ability ability)
            : base(ability)
        {
        }

        public override float Range
        {
            get
            {
                return this.Ability.GetAbilitySpecialData("range");
            }
        }

        public bool UseAbility(Vector3 startPosition, Vector3 direction)
        {
            if (!this.CanBeCasted)
            {
                return false;
            }

            if (!this.Ability.TargetPosition(startPosition) || !this.Ability.TargetPosition(direction))
            {
                return false;
            }

            var result = this.Ability.UseAbility(startPosition);

            if (result)
            {
                this.LastCastAttempt = Game.RawGameTime;
            }

            return result;
        }

        public override bool UseAbility(Vector3 position)
        {
            // simple position to get as close as possible to target
            var distance = Math.Max(this.Owner.AttackRange(), this.Owner.Distance2D(position) - this.CastRange);
            var startPosition = position.Extend(this.Owner.Position, distance);

            return this.UseAbility(startPosition, position);
        }
    }
}