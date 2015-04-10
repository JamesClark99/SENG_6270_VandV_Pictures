using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    class HeterogeneousOrder
    {
        static decimal price1HourProcessLEQ60 = 2.0M;
        static decimal price1HourProcessGT60 = 2.5M;

        static decimal ratePer4x6 = 0.19M;
        static decimal ratePerMatte4x6=0.04M;

        static decimal ratePer5x7=0.39M;
        static decimal ratePerMatte5x7=0.06M;

        static decimal ratePer8x10=0.79M;
        static decimal ratePerMatte8x10=0.08M;

        //===============================================================================================
        public static KeyValuePair<decimal,string> processResult(TempResult got)
        {
            return calculateTotalPrice(
                got.GrossCount4x6, got.GrossMatteCount4x6, got.Gross1HourCount4x6,
                    got.GrossCount5x7, got.GrossMatteCount5x7, got.Gross1HourCount5x7,
                        got.GrossCount8x10, got.GrossMatteCount8x10, got.Gross1HourCount8x10);
        }
        //===============================================================================================
        private static KeyValuePair<decimal, string> calculateTotalPrice(
                int countTotal4x6, int countMatte4x6, int count1Hour4x6,
                    int countTotal5x7, int countMatte5x7, int count1Hour5x7,
                        int countTotal8x10, int countMatte8x10, int count1Hour8x10)
        {
            string receipt = "";

            string formatter = "00.00";
            //It is assumed that the validity of the entry has already been done.
            decimal totalPrice =
                //evaluate base price for prints
                evalSubTotal(countTotal4x6, ratePer4x6) +
                    evalSubTotal(countTotal5x7, ratePer5x7) +
                        evalSubTotal(countTotal8x10, ratePer8x10) +
                //now evaluate additional amount for matte prints
                        evalSubTotal(countMatte4x6, ratePerMatte4x6) +
                            evalSubTotal(countMatte5x7, ratePerMatte5x7) +
                            evalSubTotal(countMatte8x10, ratePerMatte8x10);

            //update receipt 
            receipt += "Total  4x6 prints counts: " + countTotal4x6.ToString() + " priced @ " + ratePer4x6.ToString(formatter) + "/print cost: " + evalSubTotal(countTotal4x6, ratePer4x6).ToString(formatter) + "\n";

            receipt += "Total  5x7 prints counts: " + countTotal5x7.ToString() + " priced @ " + ratePer5x7.ToString(formatter) + "/print cost: " + evalSubTotal(countTotal5x7, ratePer5x7).ToString(formatter) + "\n";

            receipt += "Total 8x10 prints counts: " + countTotal8x10.ToString() + " priced @ " + ratePer8x10.ToString(formatter) + "/print cost: " + evalSubTotal(countTotal4x6, ratePer8x10).ToString(formatter) + "\n";

            receipt += "Adjustment for Matte  4x6 prints: " + evalSubTotal(countMatte4x6, ratePerMatte4x6).ToString() + "\n";
            receipt += "Adjustment for Matte  5x7 prints: " + evalSubTotal(countMatte5x7, ratePerMatte5x7).ToString() + "\n";
            receipt += "Adjustment for Matte 8x10 prints:" + evalSubTotal(countMatte8x10, ratePerMatte8x10).ToString() + "\n";
            //calculate the gross total number of prints
            int grossTotal1HourPrints =
                count1Hour5x7 + count1Hour8x10 + count1Hour4x6;
            int totalcount = countTotal4x6 + countTotal5x7 + countTotal8x10;

            //put this information in the receipt
            receipt += "Total 1 hour prints: " + grossTotal1HourPrints.ToString() + "\n";


            //calculate the total price added as a result of 1-hour processing
            //if (grossTotal1HourPrints < 0)//james  Bug_Fix#-5  

            if (grossTotal1HourPrints > 0)  //james find 2  Bug_Fix#-6
            {
                if (totalcount < 0) //james  Bug_Fix#-5
                {
                    //just sanity check
                    throw new Exception("Total price evaluated for heterogeneous order was less than zero. Something went wrong. Error@loc 197310-7611.");

                }
                //else if (grossTotal1HourPrints == 0)
                else if (totalcount == 0)//james  Bug_Fix#-5  
                {
                    receipt += "Added amount: 0.00 for processing 1 hour prints.";
                }
                else if (totalcount < 60)
                {
                    totalPrice += price1HourProcessLEQ60;
                    receipt += "Added amount: " + price1HourProcessLEQ60.ToString(formatter) + " for processing 1 hour prints.";


                }

                 //else if (grossTotal1HourPrints > 60 && grossTotal1HourPrints <= 100)
                else if (totalcount > 60 && totalcount <= 100)//james  Bug_Fix#-5
                {
                    totalPrice += price1HourProcessGT60;
                    receipt += "Added amount: " + price1HourProcessGT60.ToString(formatter) + " for processing 1 hour prints.\n";
                }

                else
                {
                    throw new Exception("I should not be here..");
                }
            }//james - find 2 Bug Fix 6
            receipt += "Total final price: " + totalPrice.ToString(formatter);
            //now that everything is done, return the evauated price.
            return new KeyValuePair<decimal, string>(totalPrice, receipt);
        }
        

        //===============================================================================================
        public static decimal evalSubTotal(int nPrints,decimal rate)
        {
            return (decimal)nPrints*rate;
        }
        //===============================================================================================
        
    }
}
