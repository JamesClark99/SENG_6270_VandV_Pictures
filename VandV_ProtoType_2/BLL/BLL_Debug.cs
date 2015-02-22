using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    class BLL_Debug
    {
         


        public BLL.InterfaceToBLL Calculate(BLL.InterfaceToBLL iBLL)
        {

            //----------------------------------------
            //4x6
            //----------------------------------------
           
            
            iBLL.Price_4_6_Gloss_Day = (decimal)(.14 * iBLL.Count_4_6_Gloss_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 4x6 Gloss Day: " + iBLL.Count_4_6_Gloss_Day.ToString() + " total : " + iBLL.Price_4_6_Gloss_Day.ToString();

            iBLL.Price_4_6_Gloss_Hour = (decimal)(.14 * iBLL.Count_4_6_Gloss_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 4x6 Gloss Hour: " + iBLL.Count_4_6_Gloss_Hour.ToString() + " total : " + iBLL.Price_4_6_Gloss_Hour.ToString();

            iBLL.Price_4_6_Matte_Day = (decimal)(.16 * iBLL.Count_4_6_Matte_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 4x6 Matte Day: " + iBLL.Count_4_6_Matte_Day.ToString() + " total : " + iBLL.Price_4_6_Matte_Day.ToString();

            iBLL.Price_4_6_Matte_Hour = (decimal)(.16 * iBLL.Count_4_6_Matte_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 4x6 Matte Hour: " + iBLL.Count_4_6_Matte_Hour.ToString() + " total : " + iBLL.Price_4_6_Matte_Hour.ToString();

            //----------------------------------------
            //5x7
            //----------------------------------------

            iBLL.Price_5_7_Gloss_Day = (decimal)(.34 * iBLL.Count_5_7_Gloss_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 5x7 Gloss Day: " + iBLL.Count_5_7_Gloss_Day.ToString() + " total : " + iBLL.Price_5_7_Gloss_Day.ToString();

            iBLL.Price_5_7_Gloss_Hour = (decimal)(.14 * iBLL.Count_5_7_Gloss_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 5x7 Gloss Hour: " + iBLL.Count_5_7_Gloss_Hour.ToString() + " total : " + iBLL.Price_5_7_Gloss_Hour.ToString();

            iBLL.Price_5_7_Matte_Day = (decimal)(.17 * iBLL.Count_5_7_Matte_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 5x7 Matte Day: " + iBLL.Count_5_7_Matte_Day.ToString() + " total : " + iBLL.Price_5_7_Matte_Day.ToString();

            iBLL.Price_5_7_Matte_Hour = (decimal)(.17 * iBLL.Count_5_7_Matte_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 5x7 Matte Hour: " + iBLL.Count_5_7_Matte_Hour.ToString() + " total : " + iBLL.Price_5_7_Matte_Hour.ToString();



            //----------------------------------------
            //8x10
            //----------------------------------------

            iBLL.Price_8_10_Gloss_Day = (decimal)(.68 * iBLL.Count_8_10_Gloss_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 8x10 Gloss Day: " + iBLL.Count_8_10_Gloss_Day.ToString() + " total : " + iBLL.Price_8_10_Gloss_Day.ToString();

            iBLL.Price_8_10_Gloss_Hour = (decimal)(.14 * iBLL.Count_8_10_Gloss_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 8x10 Gloss Hour: " + iBLL.Count_8_10_Gloss_Hour.ToString() + " total : " + iBLL.Price_8_10_Gloss_Hour.ToString();

            iBLL.Price_8_10_Matte_Day = (decimal)(.18 * iBLL.Count_8_10_Matte_Day);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 8x10 Matte Day: " + iBLL.Count_8_10_Matte_Day.ToString() + " total : " + iBLL.Price_8_10_Matte_Day.ToString();

            iBLL.Price_8_10_Matte_Hour = (decimal)(.18 * iBLL.Count_8_10_Matte_Hour);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Count 8x10 Matte Hour: " + iBLL.Count_8_10_Matte_Hour.ToString() + " total : " + iBLL.Price_8_10_Matte_Hour.ToString();



            //----------------------------------------
            //Total Count
            //----------------------------------------

            //iBLL.Total_Count = iBLL.G
            iBLL.Total_Count = this.GetTotalCount(iBLL);
            iBLL.Receipt = iBLL.Receipt + "\n" + "Total Count: " + iBLL.Total_Count;


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

            iBLL.Receipt = iBLL.Receipt + "\n" + "Total Price: " + iBLL.Total_Price;


            //----------------------------------------
            //Discount
            //----------------------------------------
            //iBLL.Total_Discount = (decimal).5;

            if (iBLL.Discount_Code == "N56M2")
            {
                iBLL.Total_Discount = (decimal)2.0;
                iBLL.Receipt = iBLL.Receipt + "\n" + "Discount Code:  " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();

            }
            else
            {
                iBLL.Total_Discount = (decimal)0.0;
                iBLL.Receipt = iBLL.Receipt + "\n" + "INVALID Code: " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();

            }


//            iBLL.Receipt = iBLL.Receipt + "\n" + "Discount Code: " + iBLL.Discount_Code + " total : " + iBLL.Total_Discount.ToString();
            

            return iBLL;
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

    }
}
