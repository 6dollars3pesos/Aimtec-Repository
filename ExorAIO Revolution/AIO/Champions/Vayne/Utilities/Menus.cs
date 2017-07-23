#pragma warning disable 1587

namespace AIO.Champions
{
    using System.Linq;

    using Aimtec.SDK.Menu;
    using Aimtec.SDK.Menu.Components;

    using AIO.Utilities;

    /// <summary>
    ///     The menu class.
    /// </summary>
    internal partial class Vayne
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Sets the menu.
        /// </summary>
        public void Menus()
        {
            /// <summary>
            ///     Sets the spells menu.
            /// </summary>
            MenuClass.Spells = new Menu("spells", "Spells");
            {
                /// <summary>
                ///     Sets the menu for the Q.
                /// </summary>
                MenuClass.Q = new Menu("q", "Use Q to:");
                {
                    MenuClass.Q.Add(new MenuBool("combo", "Combo"));
                    MenuClass.Q.Add(new MenuBool("engage", "Engager", false));
                    MenuClass.Q.Add(new MenuBool("killsteal", "KillSteal"));
                    MenuClass.Q.Add(new MenuSliderBool("farmhelper", "Help to farm / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.Q.Add(new MenuSliderBool("jungleclear", "Jungleclear / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.Q.Add(new MenuSliderBool("buildings", "Demolish buildings / if Mana >= x%", true, 50, 0, 99));

                    /// <summary>
                    ///     Sets the customization menu for the Q spell.
                    /// </summary>
                    MenuClass.Q2 = new Menu("customization", "Q Customization:");
                    {
                        MenuClass.Q2.Add(new MenuBool("alwaysq", "Always Q after AA"));
                        MenuClass.Q2.Add(new MenuBool("wstacks", "Use Q only to proc 3rd W Ring", false));
                    }
                    MenuClass.Q.Add(MenuClass.Q2);
                }
                MenuClass.Spells.Add(MenuClass.Q);

                /// <summary>
                ///     Sets the menu for the E.
                /// </summary>
                MenuClass.E = new Menu("e", "Use E to:");
                {
                    MenuClass.E.Add(new MenuBool("logical", "To stun"));
                    MenuClass.E.Add(new MenuBool("killsteal", "KillSteal"));
                    MenuClass.E.Add(new MenuBool("gapcloser", "Anti-Gapcloser"));
                    MenuClass.E.Add(new MenuBool("interrupter", "Interrupt Enemy Channels"));
                    MenuClass.E.Add(new MenuSliderBool("jungleclear", "Jungleclear / if Mana >= x%", true, 50, 0, 99));

                    /// <summary>
                    ///     Sets the customization menu for the E spell.
                    /// </summary>
                    MenuClass.E2 = new Menu("customization", "E Customization:");
                    {
                        MenuClass.E2.Add(new MenuSlider("eaacheck", "Don't try to stun if target can die in x autos", 3, 1, 5));
                    }
                    MenuClass.E.Add(MenuClass.E2);

                    if (GameObjects.EnemyHeroes.Any())
                    {
                        /// <summary>
                        ///     Sets the menu for the E Whitelist.
                        /// </summary>
                        MenuClass.WhiteList = new Menu("whitelist", "Condemn: Whitelist");
                        {
                            //MenuClass.WhiteList.Add(new MenuSeperator("separator1", "WhiteList only works for Combo"));
                            //MenuClass.WhiteList.Add(new MenuSeperator("separator2", "not Killsteal (Automatic)"));
                            foreach (var target in GameObjects.EnemyHeroes)
                            {
                                MenuClass.WhiteList.Add(new MenuBool(target.ChampionName.ToLower(), "Stun: " + target.ChampionName));
                            }
                        }
                        MenuClass.E.Add(MenuClass.WhiteList);
                    }
                    else
                    {
                        MenuClass.E.Add(new MenuSeperator("exseparator", "No enemies found, no need for a Whitelist Menu."));
                    }
                }
                MenuClass.Spells.Add(MenuClass.E);
            }
            MenuClass.Root.Add(MenuClass.Spells);

            /// <summary>
            ///     Sets the miscellaneous menu.
            /// </summary>
            MenuClass.Miscellaneous = new Menu("miscellaneous", "Miscellaneous");
            {
                MenuClass.Miscellaneous.Add(new MenuBool("focusw", "Focus enemies with 2 W stacks"));
                MenuClass.Miscellaneous.Add(new MenuSlider("stealthtime", "Minimum stealth time: x (ms) [1000 ms = 1 second]", 0, 0, 1000));

                if (GameObjects.EnemyHeroes.Any())
                {
                    MenuClass.Miscellaneous.Add(new MenuSlider("stealthcheck", "Don't break stealth if >= x enemies in AA Range", 3, 0, GameObjects.EnemyHeroes.Count()));
                }
                else
                {
                    MenuClass.Miscellaneous.Add(new MenuSeperator("exseparator", "No enemies found, no need for stealth slider check."));
                }
            }
            MenuClass.Root.Add(MenuClass.Miscellaneous);

            /// <summary>
            ///     Sets the drawings menu.
            /// </summary>
            MenuClass.Drawings = new Menu("drawings", "Drawings");
            {
                MenuClass.Drawings.Add(new MenuBool("q", "Q Range"));
                MenuClass.Drawings.Add(new MenuBool("e", "E Range", false));
                MenuClass.Drawings.Add(new MenuBool("epred", "E Prediction Rectangles", false));
            }
            MenuClass.Root.Add(MenuClass.Drawings);
        }

        #endregion
    }
}