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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_Calculate_Click(object sender, RoutedEventArgs e)
        {

            if (c_Debug_Mode.IsChecked == true)
            {

                 
                BLL.InterfaceToBLL iBLL = new BLL.InterfaceToBLL();
                BLL.InterfaceToBLL returnIBLL = new BLL.InterfaceToBLL();

                BLL.BLL_Debug testBLL = new BLL.BLL_Debug();


                iBLL.Count_4_6_Gloss_Day = Convert.ToInt32(t_Count_4_6_Gloss_Day.Text);
                iBLL.Count_4_6_Gloss_Hour = Convert.ToInt32(t_Count_4_6_Gloss_Hour.Text);
                iBLL.Count_4_6_Matte_Day = Convert.ToInt32(t_Count_4_6_Matte_Day.Text);
                iBLL.Count_4_6_Matte_Hour = Convert.ToInt32(t_Count_4_6_Matte_Hour.Text);


                iBLL.Count_5_7_Gloss_Day = Convert.ToInt32(t_Count_5_7_Gloss_Day.Text);
                iBLL.Count_5_7_Gloss_Hour = Convert.ToInt32(t_Count_5_7_Gloss_Hour.Text);
                iBLL.Count_5_7_Matte_Day = Convert.ToInt32(t_Count_5_7_Matte_Day.Text);
                iBLL.Count_5_7_Matte_Hour = Convert.ToInt32(t_Count_5_7_Matte_Hour.Text);


                iBLL.Count_8_10_Gloss_Day = Convert.ToInt32(t_Count_8_10_Gloss_Day.Text);
                iBLL.Count_8_10_Gloss_Hour = Convert.ToInt32(t_Count_8_10_Gloss_Hour.Text);
                iBLL.Count_8_10_Matte_Day = Convert.ToInt32(t_Count_8_10_Matte_Day.Text);
                iBLL.Count_8_10_Matte_Hour = Convert.ToInt32(t_Count_8_10_Matte_Hour.Text);

                iBLL.Discount_Code = t_Discount_Code.Text;

                returnIBLL = testBLL.Calculate(iBLL);

                t_Receipt_Area.Document = new FlowDocument();
                t_Receipt_Area.AppendText(returnIBLL.Receipt);

                t_Total_Count.Text = iBLL.Total_Count.ToString();
                t_Total_Price.Text = iBLL.Total_Price.ToString();
            }

            else
            {

                BLL.InterfaceToBLL iBLL = new BLL.InterfaceToBLL();
                BLL.InterfaceToBLL returnIBLL = new BLL.InterfaceToBLL();

                BLL.BLL_Final testBLL = new BLL.BLL_Final();

                /// the final logic
                returnIBLL = testBLL.Calculate(iBLL);
                /// 
                t_Receipt_Area.Document = new FlowDocument();
                t_Receipt_Area.AppendText(returnIBLL.Receipt);

                t_Total_Count.Text = iBLL.Total_Count.ToString();
                t_Total_Price.Text = iBLL.Total_Price.ToString();


            }

        }

        private void b_Finish_Click(object sender, RoutedEventArgs e)
        {
            t_Receipt_Area.Document = new FlowDocument();

            t_Count_4_6_Gloss_Day.Text = "0";

            t_Total_Count.Text = "0";
            t_Total_Price.Text = "0";

        }

        private void b_Start_Order_Click(object sender, RoutedEventArgs e)
        {

            t_Receipt_Area.Document = new FlowDocument();

            t_Count_4_6_Gloss_Day.Text = "0";

            t_Total_Count.Text = "0";
            t_Total_Price.Text = "0";

        }



      
    }
}
