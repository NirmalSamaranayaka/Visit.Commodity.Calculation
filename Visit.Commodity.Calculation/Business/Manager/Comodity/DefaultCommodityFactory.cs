using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Business.Manager.Comodity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Visit.Commodity.Calculation.Business.Manager.TaxCalculator" />
    public class DefaultCommodityFactory : TaxCalculator
    {

        /// <summary>
        /// Get the standard tax rate for a specific commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        public override double GetStandardTaxRate(Commodities commodity)
        {
            return 0.25;
        }
    }

}
