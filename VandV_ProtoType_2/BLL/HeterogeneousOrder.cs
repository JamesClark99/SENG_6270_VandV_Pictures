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
        public static decimal processResult(TempResult got)
        {
            return calculateTotalPrice(
                got.GrossCount4x6, got.GrossMatteCount4x6, got.Gross1HourCount4x6,
                    got.GrossCount5x7, got.GrossMatteCount5x7, got.Gross1HourCount5x7,
                        got.GrossCount8x10, got.GrossMatteCount8x10, got.Gross1HourCount8x10);
        }
        //===============================================================================================
        private static decimal calculateTotalPrice(            
                int countTotal4x6,int countMatte4x6,int count1Hour4x6,
                    int countTotal5x7,int countMatte5x7,int count1Hour5x7,
                        int countTotal8x10,int countMatte8x10,int count1Hour8x10)
        {

            //It is assumed that the validity of the entry has already been done.
            decimal totalPrice=
                //evaluate base price for prints
                evalSubTotal(countTotal4x6,ratePer4x6)+
                    evalSubTotal(countTotal5x7,ratePer5x7)+
                        evalSubTotal(countTotal8x10,ratePer8x10) +
                        //now evaluate additional amount for matte prints
                        evalSubTotal(countMatte4x6,ratePerMatte4x6)+                        
                            evalSubTotal(countMatte5x7,ratePerMatte5x7)+
                                evalSubTotal(countMatte8x10,ratePerMatte8x10);
            
            //calculate the gross total number of prints
            int grossTotal1HourPrints =
                count1Hour5x7 + count1Hour8x10 + count1Hour4x6;

            //calculate the total price added as a result of 1-hour processing
            if (grossTotal1HourPrints < 0)
            {
                //just sanity check
                throw new Exception("Total price evaluated for heterogeneous order was less than zero. Something went wrong. Error@loc 197310-7611.");

            }
            else if(grossTotal1HourPrints==0)
            {
                ;
            }
            else if (grossTotal1HourPrints <= 60)
            {
                totalPrice += price1HourProcessLEQ60;
            }
                
            else
            {
                totalPrice += price1HourProcessGT60;
            }
                

            //now that everything is done, return the evauated price.
            return totalPrice;
        }

        //===============================================================================================
        public static decimal evalSubTotal(int nPrints,decimal rate)
        {
            return (decimal)nPrints*rate;
        }
        //===============================================================================================
        
    }
}
