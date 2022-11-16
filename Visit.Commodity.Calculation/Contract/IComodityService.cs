using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IComodityService
    {
        /// <summary>
        /// Gets the get commodities.
        /// </summary>
        /// <value>
        /// The get commodities.
        /// </value>
        IEnumerable<Commodities> GetCommodities { get; }
       
    }
}
