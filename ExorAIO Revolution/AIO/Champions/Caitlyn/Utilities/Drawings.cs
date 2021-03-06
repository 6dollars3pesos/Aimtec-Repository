
using System.Drawing;
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
    ///     The drawings class.
    /// </summary>
    internal partial class Caitlyn
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Initializes the menus.
        /// </summary>
        public void Drawings()
        {
            /// <summary>
            ///     Loads the Q drawing.
            /// </summary>
            if (SpellClass.Q.Ready &&
                MenuClass.Drawings["q"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.Q.Range, 30, Color.LightGreen);
            }

            /// <summary>
            ///     Loads the W drawing.
            /// </summary>
            if (SpellClass.W.Ready &&
                MenuClass.Drawings["w"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.W.Range, 30, Color.Yellow);
            }

            /// <summary>
            ///     Loads the E drawing.
            /// </summary>
            if (SpellClass.E.Ready &&
                MenuClass.Drawings["e"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.E.Range, 30, Color.Cyan);
            }

            /// <summary>
            ///     Loads the R drawing.
            /// </summary>
            if (SpellClass.R.Ready)
            {
                if (MenuClass.Drawings["r"].As<MenuBool>().Enabled)
                {
                    Render.Circle(UtilityClass.Player.Position, SpellClass.R.Range, 30, Color.Red);
                }

                if (MenuClass.Drawings["rmm"].As<MenuBool>().Enabled)
                {
                    Geometry.DrawCircleOnMinimap(UtilityClass.Player.Position, SpellClass.R.Range, Color.White);
                }
            }

            /// <summary>
            ///     Loads the R damage to healthbar.
            /// </summary>
            if (MenuClass.Drawings["rdmg"].As<MenuBool>().Enabled)
            {
                GameObjects.EnemyHeroes
                    .Where(h => h.IsValidSpellTarget(SpellClass.R.Range))
                    .ToList()
                    .ForEach(
                        hero =>
                            {
                                var width = DrawingClass.SWidth;
                                var height = DrawingClass.SHeight;

                                var xOffset = DrawingClass.SxOffset(hero);
                                var yOffset = DrawingClass.SyOffset(hero);

                                var barPos = hero.FloatingHealthBarPosition;
                                barPos.X += xOffset;
                                barPos.Y += yOffset;

                                var drawEndXPos = barPos.X + width * (hero.HealthPercent() / 100);
                                var damage = UtilityClass.Player.GetSpellDamage(hero, SpellSlot.R);
                                var drawStartXPos = (float)(barPos.X + (hero.GetRealHealth() > damage
                                                                            ? width * ((hero.GetRealHealth() - damage) / hero.MaxHealth * 100 / 100)
                                                                            : 0));

                                Render.Line(drawStartXPos, barPos.Y, drawEndXPos, barPos.Y, height, true, hero.GetRealHealth() < damage ? Color.Blue : Color.Orange);
                                Render.Line(drawStartXPos, barPos.Y, drawStartXPos, barPos.Y + height + 1, 1, true, Color.Lime);
                            });
            }
        }

        #endregion
    }
}