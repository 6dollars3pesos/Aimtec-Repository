﻿
#pragma warning disable 1587

namespace AIO.Champions
{
    using Aimtec;
    using Aimtec.SDK.Damage;
    using Aimtec.SDK.Extensions;
    using Aimtec.SDK.Menu.Components;
    using Aimtec.SDK.Orbwalking;

    using AIO.Utilities;

    /// <summary>
    ///     The champion class.
    /// </summary>
    internal partial class Corki
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called on do-cast.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="PostAttackEventArgs" /> instance containing the event data.</param>
        public void Jungleclear(object sender, PostAttackEventArgs args)
        {
            var jungleTarget = (Obj_AI_Minion)args.Target;
            if (!Extensions.GetGenericJungleMinionsTargets().Contains(jungleTarget) || jungleTarget.Health < UtilityClass.Player.GetAutoAttackDamage(jungleTarget)*2)
            {
                return;
            }

            /// <summary>
            ///     The Q Jungleclear Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.Q.Slot, MenuClass.Spells["q"]["jungleclear"]) &&
                MenuClass.Spells["q"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                SpellClass.Q.Cast(jungleTarget);
                return;
            }

            /// <summary>
            ///     The E Jungleclear Logic.
            /// </summary>
            if (SpellClass.E.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.E.Slot, MenuClass.Spells["e"]["jungleclear"]) &&
                MenuClass.Spells["e"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                SpellClass.E.Cast();
                return;
            }

            /// <summary>
            ///     The R Jungleclear Logic.
            /// </summary>
            if (SpellClass.R.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.R.Slot, MenuClass.Spells["r"]["jungleclear"]) &&
                MenuClass.Spells["r"]["jungleclear"].As<MenuSliderBool>().Enabled)
            {
                SpellClass.R.Cast(jungleTarget);
            }
        }

        #endregion
    }
}