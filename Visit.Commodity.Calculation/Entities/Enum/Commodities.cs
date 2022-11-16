using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Commodity.Calculation.Entities.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum Commodities
    {
        //PLEASE NOTE: THESE ARE THE ACTUAL TAX RATES THAT SHOULD APPLY, WE JUST GOT THEM FROM THE CLIENT!
        /// <summary>
        /// The default
        /// </summary>
        Default,            //25%
        /// <summary>
        /// The alcohol
        /// </summary>
        Alcohol,            //25%
        /// <summary>
        /// The food
        /// </summary>
        Food,               //12%
        /// <summary>
        /// The food services
        /// </summary>
        FoodServices,       //12%
        /// <summary>
        /// The literature
        /// </summary>
        Literature,         //6%
        /// <summary>
        /// The transport
        /// </summary>
        Transport,          //6%
        /// <summary>
        /// The cultural services
        /// </summary>
        CulturalServices    //6%
    }

}
