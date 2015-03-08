﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    //======================================================================================================
    struct TempResult
    {
        public int GrossCount4x6;
        public int GrossCount5x7;
        public int GrossCount8x10;

        public int Gross1HourCount4x6;
        public int Gross1HourCount5x7;
        public int Gross1HourCount8x10;

        public int GrossMatteCount4x6;
        public int GrossMatteCount5x7;
        public int GrossMatteCount8x10;

        public string Mode;

        public string Size;
    }
    //======================================================================================================
    //Begin Class def:
    class BLL_Final
    {

        //======================================================================================================
        public BLL.InterfaceToBLL Calculate(BLL.InterfaceToBLL iBLL)
        {
            //get the mode of calculation
            TempResult gotResult = getModeAndGrossCounts(iBLL);

            KeyValuePair<decimal, string> priceAndReceipt;
            //-----------------------------------------------------------
            //evaluate the total price by calling the specific methods..
            //-----------------------------------------------------------
            if(gotResult.Mode.Equals("Homogeneous"))
            {
                //returns a <Key,Value> pair. Key: price, Value: receipt
                priceAndReceipt=HomogeneousOrder.processResult(gotResult);//process order
                
            }
            else if(gotResult.Mode.Equals("Heterogeneous"))
            {
                //returns a <Key,Value> pair. Key: price, Value: receipt
                priceAndReceipt=HeterogeneousOrder.processResult(gotResult);//process order
            }
            else
            {
                //just for sanity check
                throw new Exception("Invalid value obtained! Error @ loc 184-194871-9.");
            }

            //-----------------------------------------------------------
            //evaluate the dicounted price here.
            //skipping for now...
            //....
            //..
            //-----------------------------------------------------------

            //-----------------------------------------------------------
            var resultBLL=new BLL.InterfaceToBLL();
            //-----------------------------------------------------------
            //do assignments... and return the computed price, receipt, and discount.
            
            resultBLL.Total_Price = priceAndReceipt.Key;
            resultBLL.Receipt = priceAndReceipt.Value;
            //When ready, assign discount here.

            //return the final result
            return resultBLL;
        }
        //======================================================================================================
        public TempResult getModeAndGrossCounts(BLL.InterfaceToBLL iBLL)
        {
            //This method throws exception: OrderGT100Error(message)

            var grossCount4x6 = iBLL.Count_4_6_Gloss_Day + iBLL.Count_4_6_Gloss_Hour +
                                iBLL.Count_4_6_Matte_Day + iBLL.Count_4_6_Matte_Hour;

            var grossMatteCount4x6 = iBLL.Count_4_6_Matte_Day + iBLL.Count_4_6_Matte_Hour;

            var gross1HourCount4x6 = iBLL.Count_4_6_Gloss_Hour + iBLL.Count_4_6_Matte_Hour;

            var grossCount5x7 = iBLL.Count_5_7_Gloss_Day + iBLL.Count_5_7_Gloss_Hour +
                              iBLL.Count_5_7_Matte_Day + iBLL.Count_5_7_Matte_Hour;

            var grossMatteCount5x7 = iBLL.Count_5_7_Matte_Day + iBLL.Count_5_7_Matte_Hour;

            var gross1HourCount5x7 = iBLL.Count_5_7_Gloss_Hour + iBLL.Count_5_7_Matte_Hour;

            var grossCount8x10 = iBLL.Count_8_10_Gloss_Day + iBLL.Count_8_10_Gloss_Hour +
                              iBLL.Count_8_10_Matte_Day + iBLL.Count_8_10_Matte_Hour;

            var grossMatteCount8x10 = iBLL.Count_8_10_Matte_Day + iBLL.Count_8_10_Matte_Hour;

            var gross1HourCount8x10 = iBLL.Count_8_10_Gloss_Hour + iBLL.Count_8_10_Matte_Hour;

            var mode = "";
            var size = "";
            
            int grossHomogeneousCount=101;
            //Begin the actual sorting process..
            if (grossCount4x6 == 0 && grossCount5x7 == 0 && grossCount8x10 >= 0)
            {
                if (isTrulyHomogeneous(iBLL.Count_8_10_Gloss_Day, iBLL.Count_8_10_Gloss_Hour,
                        iBLL.Count_8_10_Matte_Day, iBLL.Count_8_10_Matte_Hour))
                {

                    mode = "Homogeneous";
                }
                else
                {
                    mode = "Heterogeneous";

                }

                grossHomogeneousCount = grossCount8x10;
                size = "8x10";
            }
            else if (grossCount4x6 == 0 && grossCount8x10 == 0 && grossCount5x7 >= 0)
            {
                if (isTrulyHomogeneous(iBLL.Count_5_7_Gloss_Day, iBLL.Count_5_7_Gloss_Hour,
                    iBLL.Count_5_7_Matte_Day, iBLL.Count_5_7_Matte_Hour))
                {
                    mode = "Homogeneous";
                }
                else
                {
                    mode = "Heterogeneous";
                }

                size = "5x7";
                grossHomogeneousCount = grossCount5x7;
            }
            else if (grossCount5x7 == 0 && grossCount8x10 == 0 && grossCount4x6 >= 0)
            {
                if (isTrulyHomogeneous(iBLL.Count_4_6_Gloss_Day, iBLL.Count_4_6_Gloss_Hour,
                    iBLL.Count_4_6_Matte_Day, iBLL.Count_4_6_Matte_Hour))
                {
                    mode = "Homogeneous";
                }
                else
                {
                    mode = "Heterogeneous";
                }

                grossHomogeneousCount = grossCount4x6;
                size = "4x6";
            }
            else
            {
                //throw new Exception("Unable to determine a suited Mode and Size. Error@loc 109837428.");
                mode = "Heterogeneous";
                grossHomogeneousCount = grossCount4x6 + grossCount5x7+grossCount8x10;
                size = "Does Not Matter";
            }

            //Check and see that the order is less than or equal to 100
            if (grossHomogeneousCount > 100)
                throw new OrderGT100Error("Total Homogeneous Gross Count >100!");
            else if (grossHomogeneousCount == 0)
                throw new OrderLEQ0Error("Total Homogeneous Gross Count = 0 !");
            else if (grossHomogeneousCount < 0)
                throw new Exception(" This is an internal application logic error. I shouldn't be here.");
            else
                Console.WriteLine("Proceeding with analysis. Gross Homogeneous Order Count: " + grossHomogeneousCount.ToString() + ".\n");

            TempResult toReturn;
            toReturn.GrossCount4x6 = grossCount4x6;
            toReturn.GrossCount5x7 = grossCount5x7;
            toReturn.GrossCount8x10 = grossCount8x10;

            toReturn.Gross1HourCount4x6 = gross1HourCount4x6;
            toReturn.Gross1HourCount5x7 = gross1HourCount5x7;
            toReturn.Gross1HourCount8x10 = gross1HourCount8x10;

            toReturn.GrossMatteCount4x6 = grossMatteCount4x6;
            toReturn.GrossMatteCount5x7 = grossMatteCount5x7;
            toReturn.GrossMatteCount8x10 = grossMatteCount8x10;

            toReturn.Mode = mode;
            toReturn.Size = size;

            return toReturn;
        }//end method getMode
        //======================================================================================================
        public bool isTrulyHomogeneous(int countGlossDay, int countGlossHour, int countMatteDay, int countMatteHour )
        {
            

            //i just have to make sure that only one of them is non-zero, while 
            //all else is zero individually
            if (countGlossDay >= 0)
                if(assertAllElseAreZeros(countGlossHour, countMatteDay, countMatteHour))
                    return true;
            if (countGlossHour >= 0)
                if (assertAllElseAreZeros(countGlossDay, countMatteDay, countMatteHour))
                    return true;
            if (countMatteDay >= 0)
                if (assertAllElseAreZeros(countGlossDay, countGlossHour, countMatteHour))
                    return true;
            if (countMatteHour >= 0)
                if (assertAllElseAreZeros(countGlossDay, countGlossHour, countMatteDay))
                    return true;

            //if none of the above are true, then the order is NOT truly homogeneous.
            return false;

        }
        //======================================================================================================
        public bool assertAllElseAreZeros(int int1, int int2, int int3)
        {
            if (int1 == 0 && int2 == 0 && int3 == 0)
                return true;
            else
                return false;
        }
        //======================================================================================================
        public bool validateData()
        {
            return false;
        }
    }
}
