using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class RotatingLettersController : ApiController
    {
        /// <summary>
        /// An artist wants to construct a sign whose letters will rotate freely in the breeze. 
        /// In order to do this, she must only use letters that are not changed by rotation of 180 degrees: I, O, S, H, Z, X, and N.
        /// Write a program that reads a word and determines whether the word can be used on the sign.
        /// </summary>
        /// <param name="inputWord">User inputted word</param>
        /// <returns> {"Yes"} || {"No"} </returns>
        /// <example>
        /// GET localhost:x/api/J2/RotatingLetters/SHINS -> Yes
        /// </example>
                [HttpGet]
        [Route("api/J2/RotatingLetters/{inputWord}")]
        public string Get(string inputWord)
        {
            string finalOutput = "";

            bool validator = System.Text.RegularExpressions.Regex.IsMatch(inputWord, "[^IOSHZXN]");

            if (validator == false) 
            {
            finalOutput = "Yes";
            }

            else
            {
            finalOutput = "No";
            }

            return finalOutput;
            }
        }

    }

