using Microsoft.AspNetCore.Mvc;
using Visit.Commodity.Calculation.Business.Manager.Comodity;
using Visit.Commodity.Calculation.Contract;
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculations.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComodityController : ControllerBase
    {
        /// <summary>
        /// The base comodity factory
        /// </summary>
        private IBaseComodityFactory _baseComodityFactory;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ComodityController> _logger;

        //Temparary hard corded Alchohol
        /// <summary>
        /// The factory
        /// </summary>
        AlcoholCommodityFactory _factory = new AlcoholCommodityFactory();


        /// <summary>
        /// Initializes a new instance of the <see cref="ComodityController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="baseComodityFactory">The base comodity factory.</param>
        public ComodityController(ILogger<ComodityController> logger, IBaseComodityFactory baseComodityFactory)
        {
            _logger = logger;
            _baseComodityFactory = baseComodityFactory;
        }

        /// <summary>
        /// Gets the standard tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public double GetStandardTaxRate(Commodities commodity)
        {
            try
            {
                //var output = _baseComodityFactory.GetInstance(commodity);
               return _factory.GetStandardTaxRate(commodity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }

        }

        /// <summary>
        /// Sets the custom tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="rate">The rate.</param>
        [HttpPost]
        [Route("[action]")]
        public void SetCustomTaxRate(Commodities commodity, double rate)
        {
            try
            {
                //var output = _baseComodityFactory.GetInstance(commodity);
                _factory.SetCustomTaxRate(commodity, rate);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
            } 

        }


        /// <summary>
        /// Gets the tax rate for date time.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="date">The date.</param>
        [HttpPost]
        [Route("[action]")]
        public void GetTaxRateForDateTime(Commodities commodity, DateTime date)
        {
            try
            {
                _factory.GetTaxRateForDateTime(commodity, date);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
            }


        }

        /// <summary>
        /// Gets the current tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        [HttpPost]
        [Route("[action]")]
        public void GetCurrentTaxRate(Commodities commodity)
        {
            try
            {
                _factory.GetCurrentTaxRate(commodity);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
            }

        }


    }
}