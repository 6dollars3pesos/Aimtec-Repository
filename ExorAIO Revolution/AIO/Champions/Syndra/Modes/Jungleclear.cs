﻿
#pragma warning disable 1587

namespace AIO.Champions
{
    using Aimtec;
    using Aimtec.SDK.Damage;
    using Aimtec.SDK.Extensions;
    using Aimtec.SDK.Menu.Components;

    using AIO.Utilities;

    /// <summary>
    ///     The champion class.
    /// </summary>
    internal partial class Syndra
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        public void Jungleclear()
        {
            var jungleTarget = ImplementationClass.IOrbwalker.GetOrbwalkingTarget() as Obj_AI_Minion;
            if (!Extensions.GetGenericJungleMinionsTargets().Contains(jungleTarget) ||
                jungleTarget?.GetRealHealth() < UtilityClass.Player.GetAutoAttackDamage(jungleTarget) * 3)
            {
                return;
            }

            /// <summary>
            ///     The Jungleclear W Logic.
            /// </summary>
            if (SpellClass.W.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.W.Slot, MenuClass.Spells["w"]["jungleclear"]) &&
                MenuClass.Spells["w"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                if (!this.IsHoldingForceOfWillObject())
                {
                    var obj = this.ForceOfWillObject();
                    if (obj != null &&
                        obj.Distance(UtilityClass.Player) < SpellClass.W.Range)
                    {
                        SpellClass.W.CastOnUnit(obj);
                    }
                }
                else
                {
                    SpellClass.W.Cast(jungleTarget?.ServerPosition ?? Game.CursorPos);
                }
            }

            if (UtilityClass.Player.SpellBook.GetSpell(SpellSlot.W).State == SpellState.Ready)
            {
                return;
            }

            /// <summary>
            ///     The Jungleclear Q Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                jungleTarget.IsValidTarget(SpellClass.Q.Range) &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.Q.Slot, MenuClass.Spells["q"]["jungleclear"]) &&
                MenuClass.Spells["q"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                if (jungleTarget != null)
                {
                    SpellClass.Q.Cast(jungleTarget.ServerPosition);
                }
            }

            /// <summary>
            ///     The Jungleclear E Logics.
            /// </summary>
            if (SpellClass.E.Ready &&
                this.IsPerfectSphereTarget(jungleTarget) &&
                jungleTarget.IsValidTarget(SpellClass.E.Range) &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.E.Slot, MenuClass.Spells["e"]["jungleclear"]) &&
                MenuClass.Spells["e"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                SpellClass.E.Cast(jungleTarget);
            }

        }

        #endregion
    }
}