using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Contract
{
    /// <summary>
    /// This is the public inteface used by our client and may not be changed
    /// </summary>
    public interface ITaxCalculator
    {
        /// <summary>
        /// Gets the standard tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        double GetStandardTaxRate(Commodities commodity);
        /// <summary>
        /// Sets the custom tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="rate">The rate.</param>
        void SetCustomTaxRate(Commodities commodity, double rate);
        /// <summary>
        /// Gets the tax rate for date time.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        double GetTaxRateForDateTime(Commodities commodity, DateTime date);
        /// <summary>
        /// Gets the current tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        double GetCurrentTaxRate(Commodities commodity);
    }
}
