﻿
#pragma warning disable 1587

namespace AIO.Champions
{
    using System.Drawing;
    using System.Linq;

    using Aimtec;
    using Aimtec.SDK.Extensions;
    using Aimtec.SDK.Menu.Components;

    using AIO.Utilities;

    /// <summary>
    ///     The drawings class.
    /// </summary>
    internal partial class Syndra
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
                Render.Circle(UtilityClass.Player.Position, SpellClass.W.Range, 30, Color.Purple);
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
            if (SpellClass.R.Ready &&
                MenuClass.Drawings["r"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.R.Range, 30, Color.Red);
            }

            if (this.DarkSpheres.Any())
            {
                foreach (var sphere in this.DarkSpheres)
                {
                    /// <summary>
                    ///     Loads the DarkSpheres drawing.
                    /// </summary>
                    if (MenuClass.Drawings["spheres"].As<MenuBool>().Enabled)
                    {
                        Render.Circle(sphere.Value, SpellClass.Q.Width, 30, Color.Blue);
                    }

                    /// <summary>
                    ///     Loads the Sphere scatter drawing.
                    /// </summary>
                    if (UtilityClass.Player.Distance(sphere.Value) < SpellClass.E.Range &&
                        MenuClass.Drawings["scatter"].As<MenuBool>().Enabled &&
                        !UtilityClass.Player.SpellBook.GetSpell(SpellSlot.E).State.HasFlag(SpellState.Cooldown))
                    {
                        var hitbox = this.DarkSphereScatterRectangle(sphere);
                        hitbox.Draw(
                            GameObjects.EnemyHeroes.Any(h => h.IsValidTarget() && hitbox.IsInside((Vector2)h.ServerPosition))
                                ? Color.Blue
                                : Color.OrangeRed);
                    }
                }
            }
        }

        #endregion
    }
}