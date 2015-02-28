using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    class HomogeneousOrder
    {

        //======================================================================================================
        public static decimal processResult(TempResult gotResult) 
        {
            //declare some local variables
            decimal rateLEQ50 = 0.0M;
            decimal rateLEQ75 = 0.0M;
            decimal rateLEQ100 = 0.0M;
            decimal pricePerMatteFinish = 0.0M;
            decimal price1HourLEQ60 = 0.0M;
            decimal price1HourGT60 = 0.0M;

            
            int countTotal = 0;
            int countMatte = 0;
            int count1Hour = 0;

            decimal totalPrice;
            //end local var declarations

            //-----------------------------------------------------------
            //initialize local var based on mode.
            //-----------------------------------------------------------
            if (gotResult.Size.Equals("4x6"))
            {
                rateLEQ50 = 0.14M;
                rateLEQ75 = 0.12M;
                rateLEQ100 = 0.10M;
                pricePerMatteFinish = 0.02M;

                countMatte = gotResult.GrossMatteCount4x6;
                count1Hour = gotResult.Gross1HourCount4x6;
                countTotal = gotResult.GrossCount4x6;

            }
            else if (gotResult.Size.Equals("5x7"))
            {
                rateLEQ50 = 0.34M;
                rateLEQ75 = 0.31M;
                rateLEQ100 = 0.28M;
                pricePerMatteFinish = 0.03M;

                countMatte = gotResult.GrossMatteCount5x7;
                count1Hour = gotResult.Gross1HourCount5x7;
                countTotal = gotResult.GrossCount8x10;
            }
            else if (gotResult.Size.Equals("8x10"))
            {
                rateLEQ50 = 0.68M;
                rateLEQ75 = 0.64M;
                rateLEQ100 = 0.60M;
                pricePerMatteFinish = 0.04M;

                countMatte = gotResult.GrossMatteCount8x10;
                count1Hour = gotResult.Gross1HourCount8x10

                countTotal = gotResult.GrossCount8x10;

            } //end if (mode.equals(...))

            //set rates for 1 hour processing
            price1HourLEQ60 = 1.0M;
            price1HourGT60 = 1.50M;

            totalPrice = HomogeneousOrder.calculateTotalPrice(
                countTotal, countMatte, count1Hour,
                    rateLEQ50, rateLEQ75, rateLEQ100,
                        pricePerMatteFinish, price1HourLEQ60, price1HourGT60);

            return totalPrice;

        }
        //======================================================================================================
        private static decimal calculateTotalPrice(
            int countTotal, int countMatte, int count1Hour,
                decimal rateLEQ50, decimal rateLEQ75, decimal rateLEQ100,
                    decimal pricePerMatteFinish, decimal price1HourLEQ60, decimal price1HourGT60)
        {
            decimal totalPrice = 0.0M;
            //-----------------------------------------------------------
            //calculate the base price based on number of prints alone..
            //-----------------------------------------------------------
            if (countTotal <= 0)
                throw new Exception("Total Prints is less than or equal to 0. Abort. Error @loc 109491890.");
            else if (countTotal <= 50)
                totalPrice =
                    (decimal)countTotal * rateLEQ50;
            else if (countTotal <= 75)
                totalPrice =
                    (decimal)(countTotal - 50) * rateLEQ75 + (decimal)50 * rateLEQ50;
            else if (countTotal <= 100)
                totalPrice =
                    (decimal)(countTotal - 75) * rateLEQ100 + (decimal)75 * rateLEQ75 + (decimal)50 * rateLEQ50;
            else
                throw new Exception("Total Prints  is greater than 100. Error@loc: 89719823.");

            //make an assertion
            if (totalPrice <= 0)
                throw new Exception("Total Price is <= 0. Invalid state. Error@loc: 761093874.");
            
            //-----------------------------------------------------------
            //Now account for any matte finish..
            //-----------------------------------------------------------
            if (countMatte >= 0)
                totalPrice = (decimal)countMatte * pricePerMatteFinish + totalPrice;
            else
                //countMatte <0
                throw new Exception("Total Matte Counts is less than zero. Invalid state. Aborting calculations. Error@loc 098173879.");

            //-----------------------------------------------------------
            //Now account for prints with 1 hour order processing..
            //-----------------------------------------------------------
            if (count1Hour < 0)
                throw new Exception("Total 1 Hour Counts is less than zero. Invalid state. Aborting calculations. Error@loc -0187487145.");

            else if (count1Hour == 0)
            {
                ;
            }
            else if (count1Hour < 60)
                totalPrice = totalPrice + price1HourLEQ60;
            else
                totalPrice = totalPrice + price1HourGT60;

            //-----------------------------------------------------------
            //return total price
            //-----------------------------------------------------------
            return totalPrice;
        }
        //======================================================================================================

    }
}
