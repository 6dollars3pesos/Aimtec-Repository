
using System.Linq;
using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using AIO.Utilities;

#pragma warning disable 1587

namespace AIO.Champions
{
    /// <summary>
    ///     The menu class.
    /// </summary>
    internal partial class KogMaw
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
                    MenuClass.Q.Add(new MenuBool("logical", "On Hard-CC'ed Enemies"));
                    MenuClass.Q.Add(new MenuBool("killsteal", "KillSteal"));
                    MenuClass.Q.Add(new MenuBool("gapcloser", "Anti-Gapcloser"));
                    MenuClass.Q.Add(new MenuSliderBool("harass", "Harass / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.Q.Add(new MenuSliderBool("jungleclear", "Jungleclear / if Mana >= x%", true, 50, 0, 99));

                    if (GameObjects.EnemyHeroes.Any())
                    {
                        /// <summary>
                        ///     Sets the menu for the Q Harass Whitelist.
                        /// </summary>
                        MenuClass.WhiteList = new Menu("whitelist", "Harass: Whitelist");
                        {
                            foreach (var target in GameObjects.EnemyHeroes)
                            {
                                MenuClass.WhiteList.Add(new MenuBool(target.ChampionName.ToLower(), "Harass: " + target.ChampionName));
                            }
                        }
                        MenuClass.Q.Add(MenuClass.WhiteList);
                    }
                    else
                    {
                        MenuClass.Q.Add(new MenuSeperator("exseparator", "No enemies found, no need for a Whitelist Menu."));
                    }
                }
                MenuClass.Spells.Add(MenuClass.Q);

                /// <summary>
                ///     Sets the menu for the W.
                /// </summary>
                MenuClass.W = new Menu("w", "Use W to:");
                {
                    MenuClass.W.Add(new MenuBool("combo", "Combo"));
                    MenuClass.W.Add(new MenuSliderBool("harass", "Harass / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.W.Add(new MenuSliderBool("laneclear", "Laneclear / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.W.Add(new MenuSliderBool("jungleclear", "Jungleclear / if Mana >= x%", true, 50, 0, 99));

                    if (GameObjects.EnemyHeroes.Any())
                    {
                        /// <summary>
                        ///     Sets the menu for the Q Harass Whitelist.
                        /// </summary>
                        MenuClass.WhiteList2 = new Menu("whitelist", "Harass: Whitelist");
                        {
                            foreach (var target in GameObjects.EnemyHeroes)
                            {
                                MenuClass.WhiteList2.Add(new MenuBool(target.ChampionName.ToLower(), "Harass: " + target.ChampionName));
                            }
                        }
                        MenuClass.W.Add(MenuClass.WhiteList2);
                    }
                    else
                    {
                        MenuClass.W.Add(new MenuSeperator("exseparator", "No enemies found, no need for a Whitelist Menu."));
                    }
                }
                MenuClass.Spells.Add(MenuClass.W);

                /// <summary>
                ///     Sets the menu for the E.
                /// </summary>
                MenuClass.E = new Menu("e", "Use E to:");
                {
                    MenuClass.E.Add(new MenuBool("combo", "Combo"));
                    MenuClass.E.Add(new MenuBool("logical", "On Hard-CC'ed Enemies"));
                    MenuClass.E.Add(new MenuBool("killsteal", "KillSteal"));
                    MenuClass.E.Add(new MenuBool("gapcloser", "Anti-Gapcloser"));
                    MenuClass.E.Add(new MenuSliderBool("harass", "Harass / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.E.Add(new MenuSliderBool("laneclear", "Laneclear / if Mana >= x%", true, 50, 0, 99));
                    MenuClass.E.Add(new MenuSliderBool("jungleclear", "Jungleclear / if Mana >= x%", true, 50, 0, 99));

                    /// <summary>
                    ///     Sets the customization menu for the E spell.
                    /// </summary>
                    MenuClass.E2 = new Menu("customization", "E Customization:");
                    {
                        //MenuClass.E2.Add(new MenuSeperator("separator1", "Laneclear settings:"));
                        MenuClass.E2.Add(new MenuSlider("laneclear", "Only Laneclear if hittable minions >= x%", 4, 1, 10));
                    }
                    MenuClass.E.Add(MenuClass.E2);

                    if (GameObjects.EnemyHeroes.Any())
                    {
                        /// <summary>
                        ///     Sets the menu for the E Harass Whitelist.
                        /// </summary>
                        MenuClass.WhiteList3 = new Menu("whitelist", "Harass: Whitelist");
                        {
                            foreach (var target in GameObjects.EnemyHeroes)
                            {
                                MenuClass.WhiteList3.Add(new MenuBool(target.ChampionName.ToLower(), "Harass: " + target.ChampionName));
                            }
                        }
                        MenuClass.E.Add(MenuClass.WhiteList3);
                    }
                    else
                    {
                        MenuClass.E.Add(new MenuSeperator("exseparator", "No enemies found, no need for a Whitelist Menu."));
                    }
                }
                MenuClass.Spells.Add(MenuClass.E);

                /// <summary>
                ///     Sets the menu for the R.
                /// </summary>
                MenuClass.R = new Menu("r", "Use R to:");
                {
                    MenuClass.R.Add(new MenuSliderBool("combo", "Combo / if Stacks <= x", true, 1, 2, 10));
                    MenuClass.R.Add(new MenuSliderBool("killsteal", "KillSteal / if Stacks <= x", true, 2, 2, 10));
                    MenuClass.R.Add(new MenuSliderBool("laneclear", "Laneclear / if Stacks <= x", true, 3, 2, 10));

                    /// <summary>
                    ///     Sets the customization menu for the R spell.
                    /// </summary>
                    MenuClass.R2 = new Menu("customization", "R Customization:");
                    {
                        //MenuClass.R2.Add(new MenuSeperator("separator1", "Laneclear settings:"));
                        MenuClass.R2.Add(new MenuSlider("laneclear", "Only Laneclear if hittable minions >= x%", 4, 1, 10));
                    }
                    MenuClass.R.Add(MenuClass.R2);

                    if (GameObjects.EnemyHeroes.Any())
                    {
                        /// <summary>
                        ///     Sets the menu for the R Whitelist.
                        /// </summary>
                        MenuClass.WhiteList4 = new Menu("whitelist", "Ultimate: Whitelist");
                        {
                            //MenuClass.WhiteList4.Add(new MenuSeperator("separator1", "WhiteList only works for Combo"));
                            //MenuClass.WhiteList4.Add(new MenuSeperator("separator2", "not Killsteal (Automatic)"));
                            foreach (var target in GameObjects.EnemyHeroes)
                            {
                                MenuClass.WhiteList4.Add(new MenuBool(target.ChampionName.ToLower(), "Use against: " + target.ChampionName));
                            }
                        }
                        MenuClass.R.Add(MenuClass.WhiteList4);
                    }
                    else
                    {
                        MenuClass.R.Add(new MenuSeperator("exseparator", "No enemies found, no need for a Whitelist Menu."));
                    }
                }
                MenuClass.Spells.Add(MenuClass.R);
            }
            MenuClass.Root.Add(MenuClass.Spells);

            /// <summary>
            ///     Sets the drawings menu.
            /// </summary>
            MenuClass.Drawings = new Menu("drawings", "Drawings");
            {
                MenuClass.Drawings.Add(new MenuBool("q", "Q Range", false));
                MenuClass.Drawings.Add(new MenuBool("w", "W Range", false));
                MenuClass.Drawings.Add(new MenuBool("e", "E Range", false));
                MenuClass.Drawings.Add(new MenuBool("r", "R Range", false));
            }
            MenuClass.Root.Add(MenuClass.Drawings);
        }

        #endregion
    }
}