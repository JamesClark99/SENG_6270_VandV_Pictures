using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    class InterfaceToBLL
    {
         
        //----------------------------------------
        //4x6
        //----------------------------------------

        private int count_4_6_Matte_Day;

        public int Count_4_6_Matte_Day
        {
            get { return count_4_6_Matte_Day; }
            set { count_4_6_Matte_Day = value; }
        }
        private int count_4_6_Gloss_Day;

        public int Count_4_6_Gloss_Day
        {
            get { return count_4_6_Gloss_Day; }
            set { count_4_6_Gloss_Day = value; }
        }
        private int count_4_6_Matte_Hour;

        public int Count_4_6_Matte_Hour
        {
            get { return count_4_6_Matte_Hour; }
            set { count_4_6_Matte_Hour = value; }
        }
        private int count_4_6_Gloss_Hour;

        public int Count_4_6_Gloss_Hour
        {
            get { return count_4_6_Gloss_Hour; }
            set { count_4_6_Gloss_Hour = value; }
        }



        //----------------------------------------
        //5x7
        //----------------------------------------

        private int count_5_7_Matte_Day;

        public int Count_5_7_Matte_Day
        {
            get { return count_5_7_Matte_Day; }
            set { count_5_7_Matte_Day = value; }
        }
        private int count_5_7_Gloss_Day;

        public int Count_5_7_Gloss_Day
        {
            get { return count_5_7_Gloss_Day; }
            set { count_5_7_Gloss_Day = value; }
        }
        private int count_5_7_Matte_Hour;

        public int Count_5_7_Matte_Hour
        {
            get { return count_5_7_Matte_Hour; }
            set { count_5_7_Matte_Hour = value; }
        }
        private int count_5_7_Gloss_Hour;

        public int Count_5_7_Gloss_Hour
        {
            get { return count_5_7_Gloss_Hour; }
            set { count_5_7_Gloss_Hour = value; }
        }



        //----------------------------------------
        //8x10
        //----------------------------------------

        private int count_8_10_Matte_Day;

        public int Count_8_10_Matte_Day
        {
            get { return count_8_10_Matte_Day; }
            set { count_8_10_Matte_Day = value; }
        }
        private int count_8_10_Gloss_Day;

        public int Count_8_10_Gloss_Day
        {
            get { return count_8_10_Gloss_Day; }
            set { count_8_10_Gloss_Day = value; }
        }
        private int count_8_10_Matte_Hour;

        public int Count_8_10_Matte_Hour
        {
            get { return count_8_10_Matte_Hour; }
            set { count_8_10_Matte_Hour = value; }
        }
        private int count_8_10_Gloss_Hour;

        public int Count_8_10_Gloss_Hour
        {
            get { return count_8_10_Gloss_Hour; }
            set { count_8_10_Gloss_Hour = value; }
        }



        //----------------------------------------
        // Discount Code
        //----------------------------------------

        private string discount_Code;
        public string Discount_Code
        {
          get { return discount_Code; }
          set { discount_Code = value; }
        }



        //----------------------------------------
        //----------------------------------------
        // Return Values
        //----------------------------------------
        //----------------------------------------


        //----------------------------------------
        // 4x6
        //----------------------------------------
        
        //private int price_4_6_Matte_Day;




        private decimal price_4_6_Matte_Day;

        public decimal Price_4_6_Matte_Day
        {
            get { return price_4_6_Matte_Day; }
            set { price_4_6_Matte_Day = value; }
        }
        private decimal price_4_6_Gloss_Day;

        public decimal Price_4_6_Gloss_Day
        {
            get { return price_4_6_Gloss_Day; }
            set { price_4_6_Gloss_Day = value; }
        }
        private decimal price_4_6_Matte_Hour;

        public decimal Price_4_6_Matte_Hour
        {
            get { return price_4_6_Matte_Hour; }
            set { price_4_6_Matte_Hour = value; }
        }
        private decimal price_4_6_Gloss_Hour;

        public decimal Price_4_6_Gloss_Hour
        {
            get { return price_4_6_Gloss_Hour; }
            set { price_4_6_Gloss_Hour = value; }
        }



        //----------------------------------------
        //5x7
        //----------------------------------------

        private decimal price_5_7_Matte_Day;

        public decimal Price_5_7_Matte_Day
        {
            get { return price_5_7_Matte_Day; }
            set { price_5_7_Matte_Day = value; }
        }
        private decimal price_5_7_Gloss_Day;

        public decimal Price_5_7_Gloss_Day
        {
            get { return price_5_7_Gloss_Day; }
            set { price_5_7_Gloss_Day = value; }
        }
        private decimal price_5_7_Matte_Hour;

        public decimal Price_5_7_Matte_Hour
        {
            get { return price_5_7_Matte_Hour; }
            set { price_5_7_Matte_Hour = value; }
        }
        private decimal price_5_7_Gloss_Hour;

        public decimal Price_5_7_Gloss_Hour
        {
            get { return price_5_7_Gloss_Hour; }
            set { price_5_7_Gloss_Hour = value; }
        }



        //----------------------------------------
        //8x10
        //----------------------------------------

        private decimal price_8_10_Matte_Day;

        public decimal Price_8_10_Matte_Day
        {
            get { return price_8_10_Matte_Day; }
            set { price_8_10_Matte_Day = value; }
        }
        private decimal price_8_10_Gloss_Day;

        public decimal Price_8_10_Gloss_Day
        {
            get { return price_8_10_Gloss_Day; }
            set { price_8_10_Gloss_Day = value; }
        }
        private decimal price_8_10_Matte_Hour;

        public decimal Price_8_10_Matte_Hour
        {
            get { return price_8_10_Matte_Hour; }
            set { price_8_10_Matte_Hour = value; }
        }
        private decimal price_8_10_Gloss_Hour;

        public decimal Price_8_10_Gloss_Hour
        {
            get { return price_8_10_Gloss_Hour; }
            set { price_8_10_Gloss_Hour = value; }
        }

        //----------------------------------------
        // Total Count
        //----------------------------------------

        private int total_Count;

        public int Total_Count
        {
            get { return total_Count; }
            set { total_Count = value; }
        }


        //----------------------------------------
        // Total Price
        //----------------------------------------

        private decimal total_Price;

        public decimal Total_Price
        {
            get { return total_Price; }
            set { total_Price = value; }
        }


        //----------------------------------------
        // Total Applied Discount
        //----------------------------------------

        private decimal total_Discount;
        public decimal Total_Discount
        {
            get { return total_Discount; }
            set { total_Discount = value; }
        }




        //----------------------------------------
        // Reciept String of transactions
        //----------------------------------------

        private string receipt;

        public string Receipt
        {
            get { return receipt; }
            set { receipt = value; }
        }


        private string logstatements;

        public string LogStatements
        {
            get { return logstatements; }
            set { logstatements = value; }
        }

    }
}
