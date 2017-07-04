namespace AIO.Champions
{
    using Aimtec;
    using Aimtec.SDK.Prediction.Skillshots;

    using Utilities;

    using Spell = Aimtec.SDK.Spell;

    /// <summary>
    ///     The spells class.
    /// </summary>
    internal partial class Ahri
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Sets the spells.
        /// </summary>
        public static void Spells()
        {
            SpellClass.Q = new Spell(SpellSlot.Q, 880f);
            SpellClass.W = new Spell(SpellSlot.W);
            SpellClass.E = new Spell(SpellSlot.E, 975f);
            SpellClass.R = new Spell(SpellSlot.R, 450f);

            SpellClass.Q.SetSkillshot(0.25f, 90f, 1700f, false, SkillType.Line);
            SpellClass.E.SetSkillshot(0.25f, 60f, 1600f, true, SkillType.Line);
        }

        #endregion
    }
}