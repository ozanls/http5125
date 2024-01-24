using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{

    public class HostingCostController : ApiController
    {

        /// <summary>
        /// Return a hypothetical hosting cost, based on the parameters provided on the assignment sheet.
        /// </summary>
        /// <param name="id">Number of days serviced</param>
        /// <returns>Hosting cost before taxes, taxes, hosting cost with taxes</returns>
        /// <example>
        /// GET.../HostingCost/14 ->    “2 fortnights at $5.50/FN = $11.00 CAD”
        ///                             “HST 13% = $1.43 CAD”
        ///                             “Total = $12.43 CAD”
        /// </example>

        public IEnumerable<string> Get(int id)
        {
            //First, lets DIVIDE the ID by 14 to find the # of fortnights serviced.
            //Per the example, payment is requested at the beginning of each fortnight; lets add (1) to our result to account for this.
            //Lets assign this value to 'hostingDuration'.
            int hostingDuration = (id / 14) + 1;

            //Next, lets multiply hostingDuration by 5.50 (the cost per FN) to find the cost of hosting, before taxes. Lets assign this value to 'hostingCost'.
            double hostingCost = hostingDuration * 5.50;

            //Next, lets multiply hostingCost by 0.13 (the HST tax rate) to find the total amount of taxes for hosting. Lets assign this value to 'hostingTax'.
            double hostingTax = hostingCost * 0.13;

            //Next, lets add hostingCost and hostingTax to find the total cost of hosting after taxes. Lets assign this value to hostingTotal.
            double hostingTotal = hostingCost + hostingTax;

            //Next, lets round our results to the nearest decimal. Lets assign the rounded values to roundedCost, roundedTax and roundedTotal
            string roundedCost = String.Format("{0:0.00}", hostingCost);
            string roundedTax = String.Format("{0:0.00}", hostingTax);
            string roundedTotal = String.Format("{0:0.00}", hostingTotal);

            //Next, lets format and assign our results to outputCost, outputTax and outputTotal.
            string outputCost = hostingDuration + " fortnights at 5.50/FN = $" + roundedCost;
            string outputTax = "HST 13% = $" + roundedTax;
            string outputTotal = "Total = $" + roundedTotal;

            //Lastly, lets combine our 3 outputs to get the final result.
            return new string[]
            {
                outputCost,
                outputTax,
                outputTotal
            };

        }
        }
}
