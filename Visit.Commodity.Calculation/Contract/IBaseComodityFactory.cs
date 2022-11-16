using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseComodityFactory
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="commodities">The commodities.</param>
        /// <returns></returns>
        IComodityService GetInstance(Commodities commodities);
    }
}
