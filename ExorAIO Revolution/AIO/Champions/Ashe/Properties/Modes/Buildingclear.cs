﻿
#pragma warning disable 1587

namespace AIO.Champions
{
    using Aimtec.SDK.Extensions;
    using Aimtec.SDK.Menu.Components;
    using Aimtec.SDK.Orbwalking;

    using AIO.Utilities;

    /// <summary>
    ///     The champion class.
    /// </summary>
    internal partial class Ashe
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called on do-cast.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="PostAttackEventArgs" /> instance containing the event data.</param>
        public static void Buildingclear(object sender, PostAttackEventArgs args)
        {
            var target = args.Target;
            if (!target.IsBuilding())
            {
                return;
            }

            /// <summary>
            ///     The Q BuildingClear Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                UtilityClass.Player.HasBuff("AsheQCastReady") &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.Q.Slot, MenuClass.Spells["q"]["buildings"]) &&
                MenuClass.Spells["q"]["buildings"].As<MenuSliderBool>().Enabled)
            {
                SpellClass.Q.Cast();
            }
        }

        #endregion
    }
}