// ReSharper disable ConvertIfStatementToConditionalTernaryExpression


using System.Linq;
using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using AIO.Utilities;

#pragma warning disable 1587

namespace AIO.Champions
{
    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Taliyah
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called on tick update.
        /// </summary>
        public void Combo()
        {
            /// <summary>
            ///     The Rylai Q Combo Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                UtilityClass.Player.HasItem(ItemId.RylaisCrystalScepter))
            {
                var bestTarget = Extensions.GetBestEnemyHeroTargetInRange(SpellClass.Q.Range-50f);
                if (bestTarget != null &&
                    !bestTarget.HasBuffOfType(BuffType.Slow) &&
                    !Invulnerable.Check(bestTarget, DamageType.Magical))
                {
                    switch (MenuClass.Spells["q"]["customization"]["qmodes"]["combo"].As<MenuList>().Value)
                    {
                        case 0:
                            if (!IsNearWorkedGround())
                            {
                                SpellClass.Q.Cast(bestTarget);
                            }
                            break;
                        case 1:
                            SpellClass.Q.Cast(bestTarget);
                            break;
                    }
                }
            }

            /// <summary>
            ///     The W->Boulders Combo Logic.
            /// </summary>
            if (SpellClass.W.Ready &&
                MenuClass.Spells["w"]["boulders"].As<MenuBool>().Enabled)
            {
                var bestTargets = ImplementationClass.ITargetSelector.GetOrderedTargets(SpellClass.W.Range - 100f)
                    .Where(t => MenuClass.Spells["w"]["selection"][t.ChampionName.ToLower()].As<MenuList>().Value < 4);

                var objAiHeroes = bestTargets as Obj_AI_Hero[] ?? bestTargets.ToArray();
                foreach (var target in objAiHeroes)
                {
                    var bestBoulderHitPos = GetBestBouldersHitPosition(target);
                    var bestBoulderHitPosHitBoulders = GetBestBouldersHitPositionHitBoulders(target);
                    if (bestBoulderHitPos != Vector3.Zero && bestBoulderHitPosHitBoulders > 0)
                    {
                        SpellClass.W.Cast(bestBoulderHitPos, SpellClass.W.GetPrediction(target).CastPosition);
                    }
                }
            }

            /// <summary>
            ///     The W Combo Logic.
            /// </summary>
            if (SpellClass.W.Ready &&
                (SpellClass.E.Ready ||
                    !MenuClass.Spells["w"]["customization"]["onlyeready"].As<MenuBool>().Enabled) &&
                MenuClass.Spells["w"]["combo"].As<MenuBool>().Enabled)
            {
                var bestTarget = Extensions.GetBestEnemyHeroTargetInRange(SpellClass.W.Range-100f);
                if (bestTarget.IsValidTarget() &&
                    !Invulnerable.Check(bestTarget, DamageType.Magical))
                {
                    switch (MenuClass.Spells["pattern"].As<MenuList>().Value)
                    {
                        case 0:
                            var targetPred = SpellClass.W.GetPrediction(bestTarget).CastPosition;
                            SpellClass.W.Cast(GetTargetPositionAfterW(bestTarget), targetPred);

                            if (SpellClass.E.Ready &&
                                MenuClass.Spells["e"]["combo"].As<MenuBool>().Enabled)
                            {
                                SpellClass.E.Cast(GetTargetPositionAfterW(bestTarget));
                            }
                            break;
                        case 1:
                            if (SpellClass.E.Ready &&
                                MenuClass.Spells["e"]["combo"].As<MenuBool>().Enabled)
                            {
                                SpellClass.E.Cast(GetTargetPositionAfterW(bestTarget));
                            }
                            break;
                    }
                }
            }

            var bestETarget = Extensions.GetBestEnemyHeroTargetInRange(UtilityClass.Player.AttackRange - 50f);

            /// <summary>
            ///     The E Combo Logic.
            /// </summary>
            if (SpellClass.E.Ready &&
                (!SpellClass.W.Ready || !MenuClass.Spells["w"]["combo"].As<MenuBool>().Enabled) &&
                !MenuClass.Spells["e"]["customization"]["onlywready"].As<MenuBool>().Enabled &&
                MenuClass.Spells["e"]["combo"].As<MenuBool>().Enabled)
            {
                if (bestETarget != null &&
                    !Invulnerable.Check(bestETarget, DamageType.Magical))
                {
                    SpellClass.E.Cast(bestETarget.ServerPosition);
                }
            }

            /// <summary>
            ///     The Q Combo Logic.
            /// </summary>
            if (SpellClass.Q.Ready &&
                (!SpellClass.E.Ready || !MenuClass.Spells["e"]["combo"].As<MenuBool>().Enabled || bestETarget == null) &&
                MenuClass.Spells["q"]["combo"].As<MenuBool>().Enabled)
            {
                var bestTarget = Extensions.GetBestEnemyHeroTargetInRange(SpellClass.Q.Range - 150f);
                if (bestTarget != null &&
                    !Invulnerable.Check(bestTarget, DamageType.Magical))
                {
                    switch (MenuClass.Spells["q"]["customization"]["qmodes"]["combo"].As<MenuList>().Value)
                    {
                        case 0:
                            if (!IsNearWorkedGround())
                            {
                                SpellClass.Q.Cast(bestTarget);
                            }
                            break;
                        case 1:
                            SpellClass.Q.Cast(bestTarget);
                            break;
                    }
                }
            }
        }

        #endregion
    }
}