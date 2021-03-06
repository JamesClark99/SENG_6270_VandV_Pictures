﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VandV_ProtoType_2;
using VandV_ProtoType_2.BLL;

namespace VandV_UnitTests
{
    //[TestClass]
    public class UnitTestCSVInput_Debug
    {
        //[TestMethod]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\JamesWorkingFolders\VisualStudio2013\t\VandV_ProtoType_2\VandV_UnitTests\VandVTestCases.csv", "VandVTestCases#csv", DataAccessMethod.Sequential)]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"VandVTestCases.csv", "VandVTestCases#csv", DataAccessMethod.Sequential)]
        public void TestMethod_CSV_Test2()
        {
            String errorMessage = "";
            String testCaseReference = "";

            VandV_ProtoType_2.BLL.InterfaceToBLL b = new InterfaceToBLL();
//            VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();

            VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();


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

            Decimal expected_result = Convert.ToDecimal(TestContext.DataRow["Expected_Total"]);
            testCaseReference = Convert.ToString(TestContext.DataRow["TestCaseReference"]);

            Decimal test_result = 0;

            test_result = (Decimal)d.Calculate(b).Total_Price;

            TestContext.WriteLine(string.Format("Test Case: {0} -- test_result: {1}, expected_result: {2}, AssertResult: {3}", testCaseReference, test_result, expected_result, errorMessage));

            //Assert.AreEqual(test_result, expected_result);
            Assert.AreEqual(expected_result, test_result);

            TestContext.WriteLine(string.Format("Test Case: {0} -- test_result: {1}, expected_result: {2}, AssertResult: {3}", testCaseReference, test_result, expected_result, errorMessage));

        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


    }
}
