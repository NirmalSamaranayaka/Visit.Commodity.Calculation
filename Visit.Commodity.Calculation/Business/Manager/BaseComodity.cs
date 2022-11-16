namespace Visit.Commodity.Calculation.Business.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseComodity
    {
        /// <summary>
        /// Runs the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        public abstract TInput Run<TInput>(TInput input);
    }
}
