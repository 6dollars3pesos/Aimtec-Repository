
using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using AIO.Utilities;

#pragma warning disable 1587

namespace AIO.Champions
{
    /// <summary>
    ///     The champion class.
    /// </summary>
    internal partial class Lucian
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        public void Harass()
        {
            /// <summary>
            ///     The Extended Q Mixed Harass Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                UtilityClass.Player.ManaPercent()
                    > ManaManager.GetNeededMana(SpellClass.Q.Slot, MenuClass.Spells["extendedq"]["mixed"]) &&
                MenuClass.Spells["extendedq"]["mixed"].As<MenuSliderBool>().Enabled &&
                Extensions.GetAllGenericUnitTargetsInRange(SpellClass.Q.Range).Any(m => m.IsValidTarget(SpellClass.Q.Range)))
            {
                var target = Extensions.GetBestEnemyHeroTargetInRange(SpellClass.Q2.Range);
                foreach (var minion in from minion in Extensions.GetAllGenericUnitTargetsInRange(SpellClass.Q.Range).Where(m => m.IsValidTarget(SpellClass.Q.Range))
                                       let polygon = new Geometry.Rectangle(
                                                            (Vector2)UtilityClass.Player.ServerPosition,
                                                            (Vector2)UtilityClass.Player.ServerPosition.Extend(minion.ServerPosition, SpellClass.Q2.Range-150f),
                                                            SpellClass.Q2.Width)
                                       where
                                           target != null &&
                                           target != minion &&
                                           polygon.IsInside((Vector2)SpellClass.Q2.GetPrediction(target).CastPosition) &&
                                           MenuClass.Spells["extendedq"]["whitelist"][target.ChampionName.ToLower()].Enabled
                                       select minion)
                {
                    SpellClass.Q.CastOnUnit(minion);
                }
            }
        }

        #endregion
    }
}