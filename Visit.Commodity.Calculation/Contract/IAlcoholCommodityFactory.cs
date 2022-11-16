
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlcoholCommodityFactory
    {
        /// <summary>
        /// Gets the standard tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        double GetStandardTaxRate(Commodities commodity);
      
    }
}
