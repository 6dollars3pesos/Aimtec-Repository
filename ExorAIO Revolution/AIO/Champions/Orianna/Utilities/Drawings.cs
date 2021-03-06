﻿
using System.Drawing;
using Aimtec;
using Aimtec.SDK.Menu.Components;
using AIO.Utilities;

#pragma warning disable 1587

namespace AIO.Champions
{
    /// <summary>
    ///     The prediction drawings class.
    /// </summary>
    internal partial class Orianna
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Loads the range drawings.
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
            ///     Loads the E drawing.
            /// </summary>
            if (SpellClass.E.Ready &&
                MenuClass.Drawings["e"].As<MenuBool>().Enabled)
            {
                Render.Circle(UtilityClass.Player.Position, SpellClass.E.Range, 30, Color.Cyan);
            }

            if (BallPosition == null)
            {
                return;
            }

            /// <summary>
            ///     Loads the Ball drawing.
            /// </summary>
            if (MenuClass.Drawings["ball"].As<MenuSliderBool>().Enabled)
            {
                for (var i = 0; i < MenuClass.Drawings["ball"].As<MenuSliderBool>().Value; i++)
                {
                    Render.Circle((Vector3)BallPosition, (uint)(60 + i * 5), 30, Color.Black);
                }
            }

            /// <summary>
            ///     Loads the W width drawing.
            /// </summary>
            if (SpellClass.W.Ready &&
                MenuClass.Drawings["ballw"].As<MenuBool>().Enabled)
            {
                Render.Circle((Vector3)BallPosition, SpellClass.W.Width, 30, Color.Purple);
            }

            /// <summary>
            ///     Loads the R width drawing.
            /// </summary>
            if (SpellClass.R.Ready &&
                MenuClass.Drawings["ballr"].As<MenuBool>().Enabled)
            {
                Render.Circle((Vector3)BallPosition, SpellClass.R.Width, 30, Color.Red);
            }
        }

        #endregion
    }
}