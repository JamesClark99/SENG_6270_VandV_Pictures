using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VandV_ProtoType_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BLL.InterfaceToBLL tempiBLL = new BLL.InterfaceToBLL();

        public MainWindow()
        {
            InitializeComponent();

            clearTextAreas();
        }

        private void b_Calculate_Click(object sender, RoutedEventArgs e)
        {

            Int32 totalcount = 0;
            /// Create the object that will be passed to Business Logic
            BLL.InterfaceToBLL iBLL = new BLL.InterfaceToBLL();

            /// Populate business logic
            iBLL.Count_4_6_Gloss_Day = ValidateInput(t_Count_4_6_Gloss_Day);
            iBLL.Count_4_6_Gloss_Hour = ValidateInput(t_Count_4_6_Gloss_Hour);
            iBLL.Count_4_6_Matte_Day = ValidateInput(t_Count_4_6_Matte_Day);
            iBLL.Count_4_6_Matte_Hour = ValidateInput(t_Count_4_6_Matte_Hour);


            iBLL.Count_5_7_Gloss_Day = ValidateInput(t_Count_5_7_Gloss_Day);
            iBLL.Count_5_7_Gloss_Hour = ValidateInput(t_Count_5_7_Gloss_Hour);
            iBLL.Count_5_7_Matte_Day = ValidateInput(t_Count_5_7_Matte_Day);
            iBLL.Count_5_7_Matte_Hour = ValidateInput(t_Count_5_7_Matte_Hour);


            iBLL.Count_8_10_Gloss_Day = ValidateInput(t_Count_8_10_Gloss_Day);
            iBLL.Count_8_10_Gloss_Hour = ValidateInput(t_Count_8_10_Gloss_Hour);
            iBLL.Count_8_10_Matte_Day = ValidateInput(t_Count_8_10_Matte_Day);
            iBLL.Count_8_10_Matte_Hour = ValidateInput(t_Count_8_10_Matte_Hour);

            iBLL.Discount_Code = t_Discount_Code.Text;

            totalcount = 0;
            totalcount = totalcount + iBLL.Count_4_6_Gloss_Day;
            totalcount = totalcount + iBLL.Count_4_6_Gloss_Hour;
            totalcount = totalcount + iBLL.Count_4_6_Matte_Day;
            totalcount = totalcount + iBLL.Count_4_6_Matte_Hour;


            totalcount = totalcount + iBLL.Count_5_7_Gloss_Day;
            totalcount = totalcount + iBLL.Count_5_7_Gloss_Hour;
            totalcount = totalcount + iBLL.Count_5_7_Matte_Day;
            totalcount = totalcount + iBLL.Count_5_7_Matte_Hour;


            totalcount = totalcount + iBLL.Count_8_10_Gloss_Day;
            totalcount = totalcount + iBLL.Count_8_10_Gloss_Hour;
            totalcount = totalcount + iBLL.Count_8_10_Matte_Day;
            totalcount = totalcount + iBLL.Count_8_10_Matte_Hour;

            /// If checked then perform calculations with Debug Version of Business Logic
            /// 
            if ((totalcount > 0) & (totalcount <= 100))
            {
                if (c_Debug_Mode.IsChecked == true)
                {
                    BLL.InterfaceToBLL returnIBLL = new BLL.InterfaceToBLL();
                    BLL.BLL_Debug testBLL = new BLL.BLL_Debug();

                    try
                    {
                        returnIBLL = testBLL.Calculate(iBLL);

                        t_Receipt_Area.Document = new FlowDocument();
                        t_Receipt_Area.AppendText(returnIBLL.Receipt);

                        t_Total_Count.Text = returnIBLL.Total_Count.ToString();
                        t_Total_Price.Text = returnIBLL.Total_Price.ToString();
                    }
                    catch (Exception ex)
                    {
                        t_log_area.Document = new FlowDocument();
                        t_log_area.AppendText(ex.Message);


                    }
                }

                else
                {
                    BLL.InterfaceToBLL returnIBLL = new BLL.InterfaceToBLL();
                    BLL.BLL_Final testBLL = new BLL.BLL_Final();


                    try
                    {
                        returnIBLL = testBLL.Calculate(iBLL);
                        /// 
                        t_Receipt_Area.Document = new FlowDocument();
                        t_Receipt_Area.AppendText(returnIBLL.Receipt);

                        t_Total_Count.Text = returnIBLL.Total_Count.ToString();
                        t_Total_Price.Text = returnIBLL.Total_Price.ToString();
                    }
                    catch (Exception ex)
                    {
                        t_log_area.Document = new FlowDocument();
                        t_log_area.AppendText(ex.Message);


                    }


                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputtext"></param>
        /// <returns></returns>
        private Int32 ValidateInput(TextBox inputtext)
        {
            Int32 number;
            Int32 returnValue;

            bool result = Int32.TryParse(inputtext.Text, out number);
            if (result)
            {
                returnValue = number;
                //Console.WriteLine("Converted '{0}' to {1}.", value, number);
            }
            else
            {
                returnValue = 0;
                inputtext.Text = "";
                //            if (value == null) value = ""; 
                //Console.WriteLine("Attempted conversion of '{0}' failed.",
                //                   value == null ? "<null>" : value);
            }

            return returnValue;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_Finish_Click(object sender, RoutedEventArgs e)
        {
            t_Receipt_Area.Document = new FlowDocument();

            t_Count_4_6_Gloss_Day.Text = "0";

            t_Total_Count.Text = "0";
            t_Total_Price.Text = "0";

            clearTextAreas();
        }

        private void b_Start_Order_Click(object sender, RoutedEventArgs e)
        {

            clearTextAreas();
           

        }


        /// <summary>
        /// 
        /// </summary>
        private void clearTextAreas()
        {

            t_Receipt_Area.Document = new FlowDocument();
            t_log_area.Document = new FlowDocument();

            t_Count_4_6_Gloss_Day.Text = "";
            t_Count_4_6_Gloss_Hour.Text = "";
            t_Count_4_6_Matte_Day.Text = "";
            t_Count_4_6_Matte_Hour.Text = "";

            t_Count_5_7_Gloss_Day.Text = "";
            t_Count_5_7_Gloss_Hour.Text = "";
            t_Count_5_7_Matte_Day.Text = "";
            t_Count_5_7_Matte_Hour.Text = "";

            t_Count_8_10_Gloss_Day.Text = "";
            t_Count_8_10_Gloss_Hour.Text = "";
            t_Count_8_10_Matte_Day.Text = "";
            t_Count_8_10_Matte_Hour.Text = "";

            t_Discount_Code.Text = "";


            t_Total_Count.Text = "0";
            t_Total_Price.Text = "0";


        }

        private void ManageTotalCount()
        {
            Int32 totalcount;
            totalcount = 0;

            totalcount = totalcount + tempiBLL.Count_4_6_Gloss_Day;
            totalcount = totalcount + tempiBLL.Count_4_6_Gloss_Hour;
            totalcount = totalcount + tempiBLL.Count_4_6_Matte_Day;
            totalcount = totalcount + tempiBLL.Count_4_6_Matte_Hour;


            totalcount = totalcount + tempiBLL.Count_5_7_Gloss_Day;
            totalcount = totalcount + tempiBLL.Count_5_7_Gloss_Hour;
            totalcount = totalcount + tempiBLL.Count_5_7_Matte_Day;
            totalcount = totalcount + tempiBLL.Count_5_7_Matte_Hour;


            totalcount = totalcount + tempiBLL.Count_8_10_Gloss_Day;
            totalcount = totalcount + tempiBLL.Count_8_10_Gloss_Hour;
            totalcount = totalcount + tempiBLL.Count_8_10_Matte_Day;
            totalcount = totalcount + tempiBLL.Count_8_10_Matte_Hour;
            //l_input_count.Content = new object();

            if (t_input_count != null)
            {
                t_input_count.Text = totalcount.ToString();

                if ((totalcount > 100)||(totalcount<=0)){
                    t_input_count.Background = Brushes.Red;
                }
                else
                {
                    t_input_count.Background = Brushes.LightGreen;

                }


            }
        }


        //private void t_Count_4_6_Gloss_Day_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    ManageTotalCount();
            
        //}

      

        private void t_Count_4_6_Gloss_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_4_6_Gloss_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_4_6_Gloss_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_4_6_Gloss_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();
        }

        private void t_Count_4_6_Matte_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_4_6_Matte_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_4_6_Matte_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_4_6_Matte_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_5_7_Gloss_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_5_7_Gloss_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_5_7_Gloss_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_5_7_Gloss_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_5_7_Matte_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_5_7_Matte_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_5_7_Matte_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_5_7_Matte_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_8_10_Gloss_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_8_10_Gloss_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_8_10_Gloss_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_8_10_Gloss_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_8_10_Matte_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_8_10_Matte_Day = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }

        private void t_Count_8_10_Matte_Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempiBLL.Count_8_10_Matte_Hour = ValidateInput(sender as TextBox);
            ManageTotalCount();

        }
    }
}
