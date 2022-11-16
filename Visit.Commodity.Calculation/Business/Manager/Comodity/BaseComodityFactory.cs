using Visit.Commodity.Calculation.Contract;
using Visit.Commodity.Calculation.Entities.Enum;
using System.Linq;

namespace Visit.Commodity.Calculation.Business.Manager.Comodity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Visit.Commodity.Calculation.Contract.IBaseComodityFactory" />
    public class BaseComodityFactory: IBaseComodityFactory
    {
        //public void Run<TFactory, TInput>(TInput input) where TFactory : TaxCalculator, new()
        //{
        //    TaxCalculator factory = new TFactory(); ;
        //    BaseComodity comodityTyle = factory.GetCurrentTaxRate();
        //    comodityTyle.Run(input);
        //}

        /// <summary>
        /// The comodity service
        /// </summary>
        private IEnumerable<IComodityService> _comodityService;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseComodityFactory"/> class.
        /// </summary>
        /// <param name="comodityService">The comodity service.</param>
        public BaseComodityFactory(IEnumerable<IComodityService> comodityService)
        {
            _comodityService = comodityService;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="commodities">The commodities.</param>
        /// <returns></returns>
        public IComodityService GetInstance(Commodities commodities) {

            var service = _comodityService.FirstOrDefault(x => x.GetCommodities.Contains(commodities));

            return service;
        }

    }
}
