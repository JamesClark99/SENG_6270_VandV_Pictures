using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    //======================================================================================================
    public struct TempResult
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

        public int GrossTotal;

        public string Mode;

        public string Size;
    }
    //======================================================================================================
    //Begin Class def:
    public class BLL_Final
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


            priceAndReceipt = applyDiscount(priceAndReceipt, gotResult, iBLL);







            //-----------------------------------------------------------
            var resultBLL=new BLL.InterfaceToBLL();
            //-----------------------------------------------------------
            //do assignments... and return the computed price, receipt, and discount.
            resultBLL.Total_Count = gotResult.GrossTotal;
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

                // james  Console.WriteLine("Proceeding with analysis. Gross Homogeneous Order Count: " + grossHomogeneousCount.ToString() + ".\n");
                // james  not garanteed to be homogenous at this point, this line is being printed for heterogenous orders also  
                Console.WriteLine("Proceeding with analysis. Gross Order Count: " + grossHomogeneousCount.ToString() + ".\n");

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

            toReturn.GrossTotal = grossHomogeneousCount;

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



        //======================================================================================================
        public KeyValuePair<decimal,string> applyDiscount(KeyValuePair<decimal,string> tempResult, TempResult got, InterfaceToBLL iBLL)
        {

            
            Decimal upchargeTotal_temp;
            Decimal upcharge_per_temp;
            iBLL.Receipt = tempResult.Value;
            iBLL.Total_Price = tempResult.Key;
            Decimal tempTotalDiscountCode = 0;
            Decimal tempTotalOver35 = 0;

            //----------------------------------------
            //Discount Code
            //----------------------------------------
            //iBLL.Total_Discount = (decimal).5;

            iBLL.Receipt = iBLL.Receipt + "\n" + "----------------------";
            iBLL.Receipt = iBLL.Receipt + "\n" + "Checking For Discounts";
            iBLL.Receipt = iBLL.Receipt + "\n" + "----------------------";

           
            // check code conditions 
            // charect discount code
            // homogenous order
            // max count 100 is required.

            // James - Bug-7 - convert to upper case
            iBLL.Discount_Code = iBLL.Discount_Code.ToUpper();  //james Bug-7

            if ((iBLL.Discount_Code == "N56M2") & (got.Mode == "Homogeneous") & (got.GrossTotal == 100))
            {
                iBLL.Receipt = iBLL.Receipt + "\n" + "Discount $2:  ";// +iBLL.Discount_Code;
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- Discount Code:  " + iBLL.Discount_Code;
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- All Same Type:   True";
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- Count = 100:     True:: " + iBLL.Total_Count;
                tempTotalDiscountCode = 2;
                iBLL.Receipt = iBLL.Receipt + "\n" + "Potential Discount from Code::    2$";

            }
            else if (iBLL.Discount_Code.Length > 0)
            {
                iBLL.Total_Discount = (decimal)0.0;
                iBLL.Receipt = iBLL.Receipt + "\n" + "INVALID Discount Code Requirements: " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();
                
            }



            //----------------------------------------
            //Discount > 35$
            // check if the 35$ discount applies
            //----------------------------------------

            if ((iBLL.Total_Price > (Decimal)35.0))
            {

                upcharge_per_temp = iBLL.Total_Price * (Decimal).05;
                tempTotalOver35 = upcharge_per_temp;
                iBLL.Receipt = iBLL.Receipt + "\n" + "Potential Discount > 35$, 5%: " + upcharge_per_temp;// +"  Total: " + tempTotalOver35;

            }


            //---------------
            //pick largest discount
            //between the two options

            iBLL.Receipt = iBLL.Receipt + "\n" + "---Picking Largest Discount---";


            if ((tempTotalDiscountCode == 0)&&(tempTotalOver35==0))
            {
                iBLL.Total_Price = Math.Round(iBLL.Total_Price, 2, MidpointRounding.AwayFromZero);
                iBLL.Receipt = iBLL.Receipt + "\n" + "No Discount, Total: " + iBLL.Total_Price;
            }
            else if ((tempTotalDiscountCode > tempTotalOver35))
            {

                iBLL.Total_Price = iBLL.Total_Price - tempTotalDiscountCode;
                iBLL.Total_Price = Math.Round(iBLL.Total_Price, 2, MidpointRounding.AwayFromZero);
                iBLL.Receipt = iBLL.Receipt + "\n" + "Applying Discount Code Total: " + iBLL.Total_Price;

            }
            else if ((tempTotalOver35 >= tempTotalDiscountCode))
            {

                iBLL.Total_Price = iBLL.Total_Price - tempTotalOver35;
                iBLL.Total_Price = Math.Round(iBLL.Total_Price, 2, MidpointRounding.AwayFromZero); 
                iBLL.Receipt = iBLL.Receipt + "\n" + "Applying Discount 35$, 5%, Total: " + iBLL.Total_Price;
            }
            else
            {


//                iBLL.Receipt = iBLL.Receipt + "\n" + "No Discount, Total: " + iBLL.Total_Price;
                iBLL.Receipt = iBLL.Receipt + "\n" + "wut";

            }

            iBLL.Receipt = iBLL.Receipt + "\n" + "---------------------";
            iBLL.Receipt = iBLL.Receipt + "\n" + "Total :: " + iBLL.Total_Price;
            iBLL.Receipt = iBLL.Receipt + "\n" + "---------------------";

            //iBLL.Total_Price = Math.Round(iBLL.Total_Price, 2, MidpointRounding.AwayFromZero);

            

            return new KeyValuePair<decimal, string>(iBLL.Total_Price, iBLL.Receipt);
            
        }


    }
}
