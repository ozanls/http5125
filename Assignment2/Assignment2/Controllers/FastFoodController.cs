using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class FastFoodController : ApiController
    {
        /// <summary>
        /// J1 - Calculates the total calories of a meal, based on user choices.
        /// </summary>
        /// <param name="burger">Burger Choice</param>
        /// <param name="drink">Drink Choice</param>
        /// <param name="side">Side Choice</param>
        /// <param name="dessert">Dessert Choice</param>
        /// <returns> {burger}+{drink}+{side}+{dessert} </returns>
        /// <example>
        /// GET localhost:x/api/J1/Menu/1/2/3/4 -> 691
        /// </example>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public int Get(int burger, int drink, int side, int dessert)
        {
            int[] burgerArray = {461,431,420,0};
            int[] drinkArray = {130,160,118,0};
            int[] sideArray = {100,57,70,0};
            int[] dessertArray = {167,266,75,0};

            int calorieTotal = burgerArray[burger-1]+drinkArray[drink-1]+sideArray[side-1]+dessertArray[dessert-1];

            return calorieTotal;
        }

    }

}


