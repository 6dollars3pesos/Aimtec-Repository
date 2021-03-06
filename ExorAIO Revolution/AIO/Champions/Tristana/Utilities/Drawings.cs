﻿
using System.Drawing;
using System.Linq;
using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using AIO.Utilities;

#pragma warning disable 1587

namespace AIO.Champions
{
    /// <summary>
    ///     The drawings class.
    /// </summary>
    internal partial class Tristana
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Initializes the menus.
        /// </summary>
        public void Drawings()
        {
            /// <summary>
            ///     Loads the W drawing.
            /// </summary>
            if (SpellClass.W.Ready &&
                MenuClass.Drawings["w"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.W.Range, 30, Color.Yellow);
            }

            /// <summary>
            ///     Loads the E damage to healthbar.
            /// </summary>
            if (MenuClass.Drawings["edmg"].As<MenuBool>().Enabled)
            {
                ObjectManager.Get<Obj_AI_Base>()
                    .Where(h => IsCharged(h) && (h is Obj_AI_Hero && !Invulnerable.Check((Obj_AI_Hero)h) || UtilityClass.JungleList.Contains(h.UnitSkinName)))
                    .ToList()
                    .ForEach(
                        unit =>
                            {
                                var heroUnit = unit as Obj_AI_Hero;
                                var jungleList = UtilityClass.JungleList;
                                var mobOffset = DrawingClass.JungleHpBarOffsetList.FirstOrDefault(x => x.UnitSkinName.Equals(unit.UnitSkinName));

                                int width;
                                if (jungleList.Contains(unit.UnitSkinName))
                                {
                                    width = mobOffset?.Width ?? DrawingClass.SWidth;
                                }
                                else
                                {
                                    width = DrawingClass.SWidth;
                                }

                                int height;
                                if (jungleList.Contains(unit.UnitSkinName))
                                {
                                    height = mobOffset?.Height ?? DrawingClass.SHeight;
                                }
                                else
                                {
                                    height = DrawingClass.SHeight;
                                }

                                int xOffset;
                                if (jungleList.Contains(unit.UnitSkinName))
                                {
                                    xOffset = mobOffset?.XOffset ?? DrawingClass.SxOffset(heroUnit);
                                }
                                else
                                {
                                    xOffset = DrawingClass.SxOffset(heroUnit);
                                }

                                int yOffset;
                                if (jungleList.Contains(unit.UnitSkinName))
                                {
                                    yOffset = mobOffset?.YOffset ?? DrawingClass.SyOffset(heroUnit);
                                }
                                else
                                {
                                    yOffset = DrawingClass.SyOffset(heroUnit);
                                }

                                var barPos = unit.FloatingHealthBarPosition;
                                barPos.X += xOffset;
                                barPos.Y += yOffset;

                                var drawEndXPos = barPos.X + width * (unit.HealthPercent() / 100);
                                var drawStartXPos = (float)(barPos.X + (unit.GetRealHealth() > GetTotalExplosionDamage(unit)
                                                                            ? width * ((unit.GetRealHealth() - GetTotalExplosionDamage(unit)) / unit.MaxHealth * 100 / 100)
                                                                            : 0));

                                Render.Line(drawStartXPos, barPos.Y, drawEndXPos, barPos.Y, height, true, unit.GetRealHealth() < GetTotalExplosionDamage(unit) ? Color.Blue : Color.Orange);
                                Render.Line(drawStartXPos, barPos.Y, drawStartXPos, barPos.Y + height + 1, 1, true, Color.Lime);
                            });
            }

            /// <summary>
            ///     Loads the W drawing.
            /// </summary>
            if (SpellClass.W.Ready &&
                MenuClass.Drawings["w"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.W.Range, 30, Color.Yellow);
            }
        }

        #endregion
    }
}