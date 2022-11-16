using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Commodity.Calculation.Common.Helper;
using Visit.Commodity.Calculation.Contract;
using Visit.Commodity.Calculation.Entities.Enum;

namespace Visit.Commodity.Calculation.Business.Manager
{
    //The focus should be on clean, simple and easy to read code 
    //Everything but the public interface may be changed
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Visit.Commodity.Calculation.Contract.ITaxCalculator" />
    public abstract class TaxCalculator : ITaxCalculator
    {
        /// <summary>
        /// Get the standard tax rate for a specific commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        public abstract double GetStandardTaxRate(Commodities commodity);


        /// <summary>
        /// This method allows the client to remotely set new custom tax rates.
        /// When they do, we save the commodity/rate information as well as the UTC timestamp of when it was done.
        /// NOTE: Each instance of this object supports a different set of custom rates, since we run one thread per customer.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="rate">The rate.</param>
        public void SetCustomTaxRate(Commodities commodity, double rate)
        {
            try
            {
                var currentTime = DateTime.Now;
                //support saving multiple custom rates for different combinations of Commodity/DateTime
                var dicKey = UniqueGeneration(commodity, rate, DateFormatHandler.GetUTCTimeStamp(currentTime));

                // make sure we never save duplicates, in case of e.g. clock resets, DST etc - overwrite old values if this happens
                if (!_customRates.ContainsKey(dicKey))
                {
                    _customRates.Add(dicKey, Tuple.Create(currentTime, rate));
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //Below dictionary cannot use due to same Key 
        //static Dictionary<Commodity, Tuple<DateTime, double>> _customRates = new Dictionary<Commodity, Tuple<DateTime, double>>();
        /// <summary>
        /// The custom rates
        /// </summary>
        static Dictionary<string, Tuple<DateTime, double>> _customRates = new Dictionary<string, Tuple<DateTime, double>>();



        /// <summary>
        /// Gets the tax rate that is active for a specific
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public double GetTaxRateForDateTime(Commodities commodity, DateTime date)
        {
            try
            {
                var key = String.Format("{0}_{1}", commodity, DateFormatHandler.GetUTCTimeStamp(date).ToString());
                /// A custom tax rate is seen as the currently active rate for a period from its starting timestamp until a new custom rate is set.
                var currentRates = _customRates.Where(p => p.Key.ToLowerInvariant().StartsWith(key.ToLowerInvariant()) && (p.Value.Item1 >= date)).OrderByDescending(p=>p.Value.Item1).Select(p => p.Value.Item2).FirstOrDefault();
                // If there is no custom tax rate for the specified date, use the standard tax rate.
                var emptyCheckRates = (currentRates <= 0) ? ((double)commodity / 100) : currentRates;
                return emptyCheckRates;
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        /// <summary>
        /// Gets the tax rate that is active for the current point in time.
        /// A custom tax rate is seen as the currently active rate for a period from its starting timestamp until a new custom rate is set.
        /// If there is no custom tax currently active, use the standard tax rate.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns></returns>
        public double GetCurrentTaxRate(Commodities commodity)
        {
            try
            {
                /// A custom tax rate is seen as the currently active rate for a period from its starting timestamp until a new custom rate is set.
                var currentRates = _customRates.Where(p=>p.Key.StartsWith(commodity.ToString()) && (p.Value.Item1 >= DateTime.Now)).OrderByDescending(p => p.Value.Item1).Select(p => p.Value.Item2).FirstOrDefault();
                var emptyCheckRates = (currentRates <= 0) ? ((double)commodity / 100) : currentRates;
                 return emptyCheckRates;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Uniques the generation.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        private string UniqueGeneration(Commodities commodity, double rate, int dateTime)
        {
            try
            {
                var getUniqueKey = String.Format("{0}_{1}_{2}", commodity, dateTime.ToString(), rate);
                return getUniqueKey;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }


}
