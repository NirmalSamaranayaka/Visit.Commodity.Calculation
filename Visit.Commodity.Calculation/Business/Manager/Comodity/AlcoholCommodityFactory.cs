using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Commodity.Calculation.Contract;
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Business.Manager.Comodity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Visit.Commodity.Calculation.Business.Manager.TaxCalculator" />
    /// <seealso cref="Visit.Commodity.Calculation.Contract.IAlcoholCommodityFactory" />
    public class AlcoholCommodityFactory :TaxCalculator, IComodityService,IAlcoholCommodityFactory
    {

        public AlcoholCommodityFactory()
        {
            GetCommodities = new[] { Commodities.Alcohol };
        }
        public IEnumerable<Commodities> GetCommodities { get; }

     
        public override double GetStandardTaxRate(Commodities commodity)
        {
            return 0.25;
        }

    }

}
