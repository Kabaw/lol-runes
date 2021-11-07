namespace LoLRunes.Utils.Math
{
    public static class MathUtils
    {
        /// <summary>
        /// A is to B as C is to X
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>X</returns>
        public static float RuleOfThree(float a, float b, float c)
        {
            return (b * c) / a;
        }
    }
}
