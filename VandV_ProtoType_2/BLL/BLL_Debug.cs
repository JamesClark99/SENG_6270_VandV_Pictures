using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    class BLL_Debug
    {

        Int32 countOfTypes;
        
        Int32 countOfHourDelivery;
        Int32 countOfDayDelivery;
        Int32 countOfMatt;
        Int32 countTotal;

        Decimal price_per_temp;
        Decimal upcharge_per_temp;
        Decimal subtotal_temp;
        Decimal upchargeTotal_temp;

        Decimal calculation_temp;
        Boolean discountCodeUsed;

        public BLL.InterfaceToBLL Calculate(BLL.InterfaceToBLL iBLL)
        {

            //init clear
            countOfTypes = 0;
            countOfHourDelivery = 0;
            countOfDayDelivery = 0;

            countOfMatt = 0;

            countTotal = 0;
            discountCodeUsed = false;


            //----------------------------------------
            this.FirstPassAnalysis(iBLL);

            if (countOfTypes == 1)
            {
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------------------------";
                iBLL.Receipt = iBLL.Receipt + "\n" + "Order Is NON-Mixed ";
                iBLL.Receipt = iBLL.Receipt + "\n" + "Order Detail";
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------------------------";


            }
            else if (countOfTypes > 1)
            {
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------------------------";
                iBLL.Receipt = iBLL.Receipt + "\n" + "Order Is Mixed ";
                iBLL.Receipt = iBLL.Receipt + "\n" + "Order Detail";
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------------------------";

            }


                //----------------------------------------
                //4x6
                //----------------------------------------
            
            if (iBLL.Count_4_6_Gloss_Day > 0)
            {

                price_per_temp = this.Get_4_6_PriceBracket(iBLL.Count_4_6_Gloss_Day, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_4_6_Gloss_Day);
                iBLL.Price_4_6_Gloss_Day = (decimal)(price_per_temp * iBLL.Count_4_6_Gloss_Day);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("4x6 Gloss Next-Day Count: ", iBLL.Count_4_6_Gloss_Day, price_per_temp, subtotal_temp, iBLL.Price_4_6_Gloss_Day);


            }


            if (iBLL.Count_4_6_Gloss_Hour > 0)
            {


                price_per_temp = this.Get_4_6_PriceBracket(iBLL.Count_4_6_Gloss_Hour, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_4_6_Gloss_Hour);
                iBLL.Price_4_6_Gloss_Hour = (decimal)(price_per_temp * iBLL.Count_4_6_Gloss_Hour);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("4x6 Gloss 1-Hour Count: ", iBLL.Count_4_6_Gloss_Hour, price_per_temp, subtotal_temp, iBLL.Price_4_6_Gloss_Hour);



            }

            if (iBLL.Count_4_6_Matte_Day > 0)
            {

                price_per_temp = this.Get_4_6_PriceBracket(iBLL.Count_4_6_Matte_Day, countOfTypes);
                upcharge_per_temp = this.Get_4_6_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_4_6_Matte_Day);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_4_6_Matte_Day);

                iBLL.Price_4_6_Matte_Day = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("4x6 Matte Next Day Count: ", iBLL.Count_4_6_Matte_Day, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_4_6_Matte_Day);

            }


            if (iBLL.Count_4_6_Matte_Hour > 0)
            {
              
                price_per_temp = this.Get_4_6_PriceBracket(iBLL.Count_4_6_Matte_Hour, countOfTypes);
                upcharge_per_temp = this.Get_4_6_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_4_6_Matte_Hour);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_4_6_Matte_Hour);

                iBLL.Price_4_6_Matte_Hour = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("4x6 Matte 1-Hour Count: ", iBLL.Count_4_6_Matte_Hour, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_4_6_Matte_Hour);


            
            }
            //----------------------------------------
            //5x7
            //----------------------------------------

            if (iBLL.Count_5_7_Gloss_Day > 0)
            {


                price_per_temp = this.Get_5_7_PriceBracket(iBLL.Count_5_7_Gloss_Day, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_5_7_Gloss_Day);
                iBLL.Price_5_7_Gloss_Day = (decimal)(price_per_temp * iBLL.Count_5_7_Gloss_Day);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("5x7 Gloss Next-Day Count: ", iBLL.Count_5_7_Gloss_Day, price_per_temp, subtotal_temp, iBLL.Price_5_7_Gloss_Day);



            
            }

            if (iBLL.Count_5_7_Gloss_Hour > 0)
            {

                price_per_temp = this.Get_5_7_PriceBracket(iBLL.Count_5_7_Gloss_Hour, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_5_7_Gloss_Hour);
                iBLL.Price_5_7_Gloss_Hour = (decimal)(price_per_temp * iBLL.Count_5_7_Gloss_Hour);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("5x7 Gloss 1-Hour Count: ", iBLL.Count_5_7_Gloss_Hour, price_per_temp, subtotal_temp, iBLL.Price_5_7_Gloss_Hour);



               
            
            }


            if (iBLL.Count_5_7_Matte_Day > 0)
            {


                price_per_temp = this.Get_5_7_PriceBracket(iBLL.Count_5_7_Matte_Day, countOfTypes);
                upcharge_per_temp = this.Get_5_7_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_5_7_Matte_Day);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_5_7_Matte_Day);

                iBLL.Price_5_7_Matte_Day = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("5x7 Matte Next-Day Count: ", iBLL.Count_5_7_Matte_Day, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_5_7_Matte_Day);



             
            }

            if (iBLL.Count_5_7_Matte_Hour > 0)
            {


                price_per_temp = this.Get_5_7_PriceBracket(iBLL.Count_5_7_Matte_Hour, countOfTypes);
                upcharge_per_temp = this.Get_5_7_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_5_7_Matte_Hour);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_5_7_Matte_Hour);

                iBLL.Price_5_7_Matte_Hour = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("5x7 Matte 1-Hour Count: ", iBLL.Count_5_7_Matte_Hour, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_5_7_Matte_Hour);



            }

            //----------------------------------------
            //8x10
            //----------------------------------------

            if (iBLL.Count_8_10_Gloss_Day > 0)
            {

                price_per_temp = this.Get_8_10_PriceBracket(iBLL.Count_8_10_Gloss_Day, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_8_10_Gloss_Day);
                iBLL.Price_8_10_Gloss_Day = (decimal)(price_per_temp * iBLL.Count_8_10_Gloss_Day);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("8x10 Gloss Next-Day Count: ", iBLL.Count_8_10_Gloss_Day, price_per_temp, subtotal_temp, iBLL.Price_8_10_Gloss_Day);



                
            }

            if (iBLL.Count_8_10_Gloss_Hour > 0)
            {
                price_per_temp = this.Get_8_10_PriceBracket(iBLL.Count_8_10_Gloss_Hour, countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_8_10_Gloss_Hour);
                iBLL.Price_8_10_Gloss_Hour = (decimal)(price_per_temp * iBLL.Count_8_10_Gloss_Hour);

                iBLL.Receipt = iBLL.Receipt +
                        Format_Gloss("8x10 Gloss 1-Hour Count: ", iBLL.Count_8_10_Gloss_Hour, price_per_temp, subtotal_temp, iBLL.Price_8_10_Gloss_Hour);



                
            }

            if (iBLL.Count_8_10_Matte_Day > 0)
            {

                price_per_temp = this.Get_8_10_PriceBracket(iBLL.Count_8_10_Matte_Day, countOfTypes);
                upcharge_per_temp = this.Get_8_10_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_8_10_Matte_Day);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_8_10_Matte_Day);

                iBLL.Price_8_10_Matte_Day = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("8x10 Matte Next-Day Count: ", iBLL.Count_8_10_Matte_Day, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_8_10_Matte_Day);

           
            
            }

            if (iBLL.Count_8_10_Matte_Hour > 0)
            {

                price_per_temp = this.Get_8_10_PriceBracket(iBLL.Count_8_10_Matte_Hour, countOfTypes);
                upcharge_per_temp = this.Get_8_10_MattUpcharge(countOfTypes);

                subtotal_temp = (decimal)(price_per_temp * iBLL.Count_8_10_Matte_Hour);

                upchargeTotal_temp = (decimal)(upcharge_per_temp * iBLL.Count_8_10_Matte_Hour);

                iBLL.Price_8_10_Matte_Hour = subtotal_temp + upchargeTotal_temp;


                iBLL.Receipt = iBLL.Receipt +
                        Format_Matte("8x10 Matte 1-Hour Count: ", iBLL.Count_8_10_Matte_Hour, price_per_temp, upcharge_per_temp, subtotal_temp, upchargeTotal_temp, iBLL.Price_8_10_Matte_Hour);


            }


          


            //----------------------------------------
            //Total Count
            //----------------------------------------

            //iBLL.Total_Count = iBLL.G

            if (countTotal == this.GetTotalCount(iBLL))
            {
                iBLL.Total_Count = this.GetTotalCount(iBLL);
                iBLL.Receipt = iBLL.Receipt + "\n" + "Total Count: " + iBLL.Total_Count;
            }
            else
            {
                iBLL.Receipt = iBLL.Receipt + "\n" + "Total Count: MISMATCH COUNT  " + iBLL.Total_Count;
            }




            //----------------------------------------
            //Total Price
            //----------------------------------------
            iBLL.Total_Price = 0;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_4_6_Gloss_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_4_6_Gloss_Hour;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_4_6_Matte_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_4_6_Matte_Hour;

            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_5_7_Gloss_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_5_7_Gloss_Hour;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_5_7_Matte_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_5_7_Matte_Hour;

            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_8_10_Gloss_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_8_10_Gloss_Hour;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_8_10_Matte_Day;
            iBLL.Total_Price = iBLL.Total_Price + iBLL.Price_8_10_Matte_Hour;

            iBLL.Receipt = iBLL.Receipt + "\n" + "Total Price Pre-Adjustments: " + iBLL.Total_Price;



            //----------------------------------------
            // 1 hour next Day
            //----------------------------------------

            iBLL.Receipt = iBLL.Receipt + "\n" + "--------------------";
            iBLL.Receipt = iBLL.Receipt + "\n" + "Checking 1-Hour/Next-Day";
            iBLL.Receipt = iBLL.Receipt + "\n" + "--------------------";


            if (countOfHourDelivery > 0)
            {
                if (countOfTypes == 1)
                {
                    if (countTotal <= 60)
                    {

                        iBLL.Total_Price = iBLL.Total_Price + 1;
                        iBLL.Receipt = iBLL.Receipt + "\n" + "1-Hour <= 60 add 1$::     Total " + iBLL.Total_Price;

                    }
                    else if (countTotal > 60)
                    {
                        iBLL.Total_Price = iBLL.Total_Price + (Decimal)1.5;
                        iBLL.Receipt = iBLL.Receipt + "\n" + "1-Hour >= 60 add 1.50$::  Total " + iBLL.Total_Price;


                    }

                }
                else
                {
                    if (countTotal <= 60)
                    {

                        iBLL.Total_Price = iBLL.Total_Price + 2;
                        iBLL.Receipt = iBLL.Receipt + "\n" + "1-Hour <= 60 add 2$::     Total " + iBLL.Total_Price;

                    }
                    else if (countTotal > 60)
                    {
                        iBLL.Total_Price = iBLL.Total_Price + (Decimal)2.5;
                        iBLL.Receipt = iBLL.Receipt + "\n" + "1-Hour >= 60 add 2.50$::  Total " + iBLL.Total_Price;

                    }
                }
            }

            //----------------------------------------
            //Discount Code
            //----------------------------------------
            //iBLL.Total_Discount = (decimal).5;

            iBLL.Receipt = iBLL.Receipt + "\n" + "--------------------";
            iBLL.Receipt = iBLL.Receipt + "\n" + "Checking Discounts";
            iBLL.Receipt = iBLL.Receipt + "\n" + "--------------------";


            if ((iBLL.Discount_Code == "N56M2") & (countOfTypes == 1) & (iBLL.Total_Count == 100))
            {
                iBLL.Total_Discount = (decimal)2.0;
                iBLL.Receipt = iBLL.Receipt + "\n" + "Discount $2:  " + iBLL.Discount_Code;
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- Discount Code:  " + iBLL.Discount_Code;
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- All Same Type:   True";
                iBLL.Receipt = iBLL.Receipt + "\n" + "-------- Count = 100:     True:: " + iBLL.Total_Count;
                iBLL.Total_Price = iBLL.Total_Price - 2;

                iBLL.Receipt = iBLL.Receipt + "\n" + "Discount - 2$::   Total : " + iBLL.Total_Discount.ToString();
                iBLL.Receipt = iBLL.Receipt + "\n" + "Total::                   " + iBLL.Total_Price.ToString();

                discountCodeUsed = true;

            }
            else if (iBLL.Discount_Code.Length > 0)
            {
                iBLL.Total_Discount = (decimal)0.0;
                iBLL.Receipt = iBLL.Receipt + "\n" + "INVALID Discount Requirements: " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();

            }


//            iBLL.Receipt = iBLL.Receipt + "\n" + "Discount Code: " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();

            //----------------------------------------
            //Discount > 35$
            //----------------------------------------

            if ((discountCodeUsed == false) & (iBLL.Total_Price > 35))
            {

                upcharge_per_temp = iBLL.Total_Price * (Decimal).05;
                iBLL.Total_Price = iBLL.Total_Price - upcharge_per_temp;

                iBLL.Receipt = iBLL.Receipt + "\n" + "Discount > 35$, 5%: " + upcharge_per_temp;

                iBLL.Receipt = iBLL.Receipt + "\n" + "Total ::            " + iBLL.Total_Price;
                    
            }

            iBLL.Receipt = iBLL.Receipt + "\n" + "---------------------";
            iBLL.Receipt = iBLL.Receipt + "\n" + "Total :: " + iBLL.Total_Price;
            iBLL.Receipt = iBLL.Receipt + "\n" + "---------------------";

            return iBLL;
        }


        public string Format_Gloss(String typedesc, Int32 count, Decimal price_print, Decimal sub_total, Decimal total)
        {
            String temp = "";

            temp = temp + "\n" + typedesc + count.ToString();
            temp = temp + "\n" + "    price/print:        " + price_print;// +" Sub-Total: " + sub_total;
            //temp = temp + "\n" + "............  Matte Upcharge:     " + upcharge_print + " Up Charge: " + upcharge_total;
            temp = temp + "\n" + "    Total:              " + total.ToString();

            return temp;

        }

       public string Format_Matte(String typedesc, Int32 count, Decimal price_print, Decimal upcharge_print, Decimal sub_total, Decimal upcharge_total, Decimal total)
        {
            String temp = "";

            temp = temp + "\n" + typedesc + count.ToString();
            temp = temp + "\n" + "    price/print:        " + price_print + "   Sub-Total: " + sub_total;
            temp = temp + "\n" + "    Matte Upcharge per/print: " + upcharge_print + "    Up Charge: " + upcharge_total;
            temp = temp + "\n" + "    Total:              " + total.ToString();

            return temp;

        }

        public int GetTotalCount(BLL.InterfaceToBLL iBLL)
        {
            //----------------------------------------
            //Total Count
            //----------------------------------------
            iBLL.Total_Count = 0;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_4_6_Gloss_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_4_6_Gloss_Hour;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_4_6_Matte_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_4_6_Matte_Hour;

            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_5_7_Gloss_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_5_7_Gloss_Hour;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_5_7_Matte_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_5_7_Matte_Hour;

            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_8_10_Gloss_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_8_10_Gloss_Hour;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_8_10_Matte_Day;
            iBLL.Total_Count = iBLL.Total_Count + iBLL.Count_8_10_Matte_Hour;

            return iBLL.Total_Count;

        }



        /// <summary>
        /// Do analysis to determine mixed or unmixed and sub counts
        /// </summary>
        /// <param name="iBLL"></param>
        /// <returns></returns>
        private bool FirstPassAnalysis(BLL.InterfaceToBLL iBLL)
        {

            //----------------------------------------
            //4x6
            //----------------------------------------

            if (iBLL.Count_4_6_Gloss_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_4_6_Gloss_Day;

            }


            if (iBLL.Count_4_6_Gloss_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_4_6_Gloss_Hour;

            }

            if (iBLL.Count_4_6_Matte_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_4_6_Matte_Day;

                countOfMatt = countOfMatt + iBLL.Count_4_6_Matte_Day;
            }

            if (iBLL.Count_4_6_Matte_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_4_6_Matte_Hour;
                countOfMatt = countOfMatt + iBLL.Count_4_6_Matte_Hour;
            }

            
            //----------------------------------------
            //5x7
            //----------------------------------------

            if (iBLL.Count_5_7_Gloss_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_5_7_Gloss_Day;
            }

            if (iBLL.Count_5_7_Gloss_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_5_7_Gloss_Hour;

            }


            if (iBLL.Count_5_7_Matte_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_5_7_Matte_Day;
                countOfMatt = countOfMatt + iBLL.Count_5_7_Matte_Day;


            }

            if (iBLL.Count_5_7_Matte_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_5_7_Matte_Hour;
                countOfMatt = countOfMatt + iBLL.Count_5_7_Matte_Hour;

            }

            //----------------------------------------
            //8x10
            //----------------------------------------

            if (iBLL.Count_8_10_Gloss_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_8_10_Gloss_Day;
            }

            if (iBLL.Count_8_10_Gloss_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_8_10_Gloss_Hour;

            }

            if (iBLL.Count_8_10_Matte_Day > 0)
            {
                countOfTypes++;
                countOfDayDelivery++;
                countTotal = countTotal + iBLL.Count_8_10_Matte_Day;
                countOfMatt = countOfMatt + iBLL.Count_8_10_Matte_Day;
            }

            if (iBLL.Count_8_10_Matte_Hour > 0)
            {
                countOfTypes++;
                countOfHourDelivery++;
                countTotal = countTotal + iBLL.Count_8_10_Matte_Hour;
                countOfMatt = countOfMatt + iBLL.Count_8_10_Matte_Hour;

            }


            //double check if total count here matches the function to find total count.
            if (countTotal == this.GetTotalCount(iBLL))
            {
                iBLL.Total_Count = this.GetTotalCount(iBLL);
                return true;
            }
            else
            {
                return false;
            }


        }



        /// <summary>
        /// Find 4x6 prices
        /// </summary>
        /// <param name="count"></param>
        /// <param name="numTypes"></param>
        /// <returns></returns>
        private Decimal Get_4_6_PriceBracket(Int32 count, Int32 numTypes)
        {

            //non-mixed
            if (numTypes == 1)
            {
                if (count < 50)
                {
                    return (Decimal).14;
                }
                else if ((count >= 50) & (count < 75))
                {
                    return (Decimal).12;
                }

                else if (count >= 75)
                {
                    return (Decimal).10;
                }
                else
                {
                    return 0;
                }
            }
            // mixed 
            else if (numTypes > 1)
            {
                return (Decimal).19;
            }
            else
            {
                return 0;
            }

        }

        private Decimal Get_4_6_MattUpcharge(Int32 numTypes)
        {
            //non-mixed
            if (numTypes == 1)
            {
                return (Decimal).02;

            }
            else
            {
                return (Decimal).04;
            }


        }

        /// <summary>
        /// find prices for 5x7
        /// </summary>
        /// <param name="count"></param>
        /// <param name="numTypes"></param>
        /// <returns></returns>
        private Decimal Get_5_7_PriceBracket(Int32 count, Int32 numTypes)
        {
            //non-mixed
            if (numTypes == 1)
            {
                if (count < 50)
                {
                    return (Decimal).34;
                }
                else if ((count >= 50) & (count < 75))
                {
                    return (Decimal).31;
                }

                else if (count >= 75)
                {
                    return (Decimal).28;
                }
                else
                {
                    return 0;
                }
            }
            //mixed
            else if (numTypes > 1)
            {
                return (Decimal).39;
            }
            else
            {
                return 0;
            }
        }

        private Decimal Get_5_7_MattUpcharge(Int32 numTypes)
        {
            //non-mixed
            if (numTypes == 1)
            {
                return (Decimal).03;

            }
            else
            {
                return (Decimal).06;
            }


        }


        /// <summary>
        /// find price of 8x10
        /// </summary>
        /// <param name="count"></param>
        /// <param name="numTypes"></param>
        /// <returns></returns>
        private Decimal Get_8_10_PriceBracket(Int32 count, Int32 numTypes)
        {
            //mixed
            if (numTypes == 1)
            {
                if (count < 50)
                {
                    return (Decimal).68;
                }
                else if ((count >= 50) & (count < 75))
                {
                    return (Decimal).64;
                }

                else if (count >= 75)
                {
                    return (Decimal).60;
                }
                else
                {
                    return 0;
                }
            }
            //non mixed
            else if (numTypes > 1)
            {
                return (Decimal).79;
            }
            else
            {
                return 0;
            }
        }



        private Decimal Get_8_10_MattUpcharge(Int32 numTypes)
        {
            //non-mixed
            if (numTypes == 1)
            {
                return (Decimal).04;

            }
            else
            {
                return (Decimal).08;
            }


        }

    }
}
