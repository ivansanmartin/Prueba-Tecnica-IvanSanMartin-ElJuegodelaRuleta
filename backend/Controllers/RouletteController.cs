using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RouletteController : ControllerBase
    {

        [HttpGet("spin-roulette")]
        public IActionResult SpinRoulette()
        {
            var random = new Random();
            int number = random.Next(0, 37);

            string color = GetColorOfNumber(number);
            string parity = VerifyParity(number);
            
            return Ok(new {number, color, parity});

        } 

        public static string GetColorOfNumber(int number) {

            var roulette = new Dictionary<int, string>
                {
                    { 0, "green" },
                    { 1, "red" },
                    { 2, "black" },
                    { 3, "red" },
                    { 4, "black" },
                    { 5, "red" },
                    { 6, "black" },
                    { 7, "red" },
                    { 8, "black" },
                    { 9, "red" },
                    { 10, "black" },
                    { 11, "black" },
                    { 12, "red" },
                    { 13, "black" },
                    { 14, "red" },
                    { 15, "black" },
                    { 16, "red" },
                    { 17, "black" },
                    { 18, "red" },
                    { 19, "red" },
                    { 20, "black" },
                    { 21, "red" },
                    { 22, "black" },
                    { 23, "red" },
                    { 24, "black" },
                    { 25, "red" },
                    { 26, "black" },
                    { 27, "red" },
                    { 28, "black" },
                    { 29, "black" },
                    { 30, "red" },
                    { 31, "black" },
                    { 32, "red" },
                    { 33, "black" },
                    { 34, "red" },
                    { 35, "black" },
                    { 36, "red" }
                };

            return roulette.TryGetValue(number, out string ?color) && color != null ? color : "no_color";

        }

        public static string VerifyParity(int number) {
            return number % 2 == 0 ? "pair" : "odd";
        }


    }
}