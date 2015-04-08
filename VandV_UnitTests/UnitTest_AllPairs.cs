using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VandV_ProtoType_2;
using VandV_ProtoType_2.BLL;


namespace VandV_UnitTests
{
    [TestClass]
    public class UnitTest_AllPairs
    {    

        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\JamesWorkingFolders\VisualStudio2013\t\VandV_ProtoType_2\VandV_UnitTests\VandVTestCases.csv", "VandVTestCases#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"VandVTestCases_AllPairs.csv", "VandVTestCases_AllPairs#csv", DataAccessMethod.Sequential)]
        public void TestMethod_Final_AllPairsCombinatorical()
        {
            String errorMessage = "";
            String testCaseReference = "";

            VandV_ProtoType_2.BLL.InterfaceToBLL b = new InterfaceToBLL();
            //VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();

            //VandV_ProtoType_2.BLL.BLL_Final d = new BLL_Final();


            b.Count_4_6_Gloss_Day = Convert.ToInt32(TestContext.DataRow["4_6_Gloss_NextDay"]);
            b.Count_4_6_Gloss_Hour = Convert.ToInt32(TestContext.DataRow["4_6_Gloss_Hour"]);
            b.Count_4_6_Matte_Day = Convert.ToInt32(TestContext.DataRow["4_6_Matte_NextDay"]);
            b.Count_4_6_Matte_Hour = Convert.ToInt32(TestContext.DataRow["4_6_Matte_Hour"]);

            b.Count_5_7_Gloss_Day = Convert.ToInt32(TestContext.DataRow["5_7_Gloss_NextDay"]);
            b.Count_5_7_Gloss_Hour = Convert.ToInt32(TestContext.DataRow["5_7_Gloss_Hour"]);
            b.Count_5_7_Matte_Day = Convert.ToInt32(TestContext.DataRow["5_7_Matte_NextDay"]);
            b.Count_5_7_Matte_Hour = Convert.ToInt32(TestContext.DataRow["5_7_Matte_Hour"]);

            b.Count_8_10_Gloss_Day = Convert.ToInt32(TestContext.DataRow["8_10_Gloss_NextDay"]);
            b.Count_8_10_Gloss_Hour = Convert.ToInt32(TestContext.DataRow["8_10_Gloss_Hour"]);
            b.Count_8_10_Matte_Day = Convert.ToInt32(TestContext.DataRow["8_10_Matte_NextDay"]);
            b.Count_8_10_Matte_Hour = Convert.ToInt32(TestContext.DataRow["8_10_Matte_Hour"]);

            b.Discount_Code = Convert.ToString(TestContext.DataRow["Discount Code"]);


            Decimal expected_result = Convert.ToDecimal(TestContext.DataRow["Expected_Total"]);
            testCaseReference = Convert.ToString(TestContext.DataRow["TestCaseReference"]);

            Decimal test_result = 0;
            //                test_result = WrapperOnFinal(b);
            b = WrapperOnFinal(b);
            test_result = b.Total_Price;
            //test_result = (Decimal)d.Calculate(b).Total_Price;

            //test_result = (Decimal)d.Calculate(b).Total_Price;

            TestContext.WriteLine(string.Format("Test Case: {0} -- test_result: {1}, expected_result: {2}, AssertResult: {3}", testCaseReference, test_result, expected_result, errorMessage));
            TestContext.WriteLine(string.Format("Test Case: {0} -- reciept: {1}", testCaseReference, b.Receipt));

///james april 8            Assert.AreEqual(test_result, expected_result);
            Assert.AreEqual(expected_result,test_result);
            
            TestContext.WriteLine(string.Format("Test Case: {0} -- test_result: {1}, expected_result: {2}, AssertResult: {3}", testCaseReference, test_result, expected_result, errorMessage));

        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        public InterfaceToBLL WrapperOnFinal(InterfaceToBLL b)
        {
            Decimal test_result;
            VandV_ProtoType_2.BLL.BLL_Final d = new BLL_Final();

            try
            {
                //test_result = (Decimal)d.Calculate(b).Total_Price;
                //b.Total_Price = (Decimal)d.Calculate(b).Total_Price;
                b = d.Calculate(b);
            }
            catch (Exception ex)
            {
                String wut = ex.Message;
                test_result = 0;

            }

            //                return test_result;
            return b;
        }


    }
}