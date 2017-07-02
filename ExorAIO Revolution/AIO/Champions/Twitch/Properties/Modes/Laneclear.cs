
#pragma warning disable 1587

namespace AIO.Champions
{
    using System.Linq;

    using Aimtec.SDK.Extensions;
    using Aimtec.SDK.Menu.Components;

    using AIO.Utilities;

    /// <summary>
    ///     The champion class.
    /// </summary>
    internal partial class Twitch
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        public static void Laneclear()
        {
            /// <summary>
            ///     The Laneclear W Logic.
            /// </summary>
            if (SpellClass.W.Ready &&
                UtilityClass.Player.ManaPercent()
                > ManaManager.GetNeededMana(SpellClass.W.Slot, MenuClass.Spells["w"]["laneclear"]) &&
                MenuClass.Spells["w"]["laneclear"].As<MenuSliderBool>().Enabled)
            {
                /*
                var farmLocation = SpellClass.W.GetCircularFarmLocation(UtilityClass.GetEnemyLaneMinionsTargets().Where(m => m.GetBuffCount("twitchdeadlyvenom") <= 4).ToList(), SpellClass.W.Width);
                if (farmLocation.MinionsHit >= 3))
                {
                    SpellClass.W.Cast(farmLocation.Position);
                }
                */
            }

            /// <summary>
            ///     The Laneclear E Logic.
            /// </summary>
            if (SpellClass.E.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.E.Slot, MenuClass.Spells["e"]["laneclear"]) &&
                MenuClass.Spells["e"]["laneclear"].As<MenuSliderBool>().Enabled)
            {
                var perfectlyKillableMinions = UtilityClass.GetEnemyLaneMinionsTargetsInRange(SpellClass.E.Range).Count(m => IsPerfectExpungeTarget(m) && GetTotalExpungeDamage(m) > m.Health);
                if (perfectlyKillableMinions >= MenuClass.Miscellaneous["e2"]["laneclear"].As<MenuSlider>().Value)
                {
                    SpellClass.E.Cast();
                }
            }
        }

        #endregion
    }
}