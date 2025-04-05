using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IRouletteService
    {

        (int Number, string Color, string Parity) SpinRoulette();
        string GetColorOfNumber(int number);
        string VerifyParity(int number);
        
    }
}