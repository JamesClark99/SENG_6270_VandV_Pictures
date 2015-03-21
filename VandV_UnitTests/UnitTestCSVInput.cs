using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VandV_ProtoType_2;
using VandV_ProtoType_2.BLL;

namespace VandV_UnitTests
{
    [TestClass]
    public class UnitTestCSVInput
    {
        [TestMethod]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\JamesWorkingFolders\VisualStudio2013\t\VandV_ProtoType_2\VandV_UnitTests\VandVTestCases.csv", "VandVTestCases#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"VandVTestCases.csv", "VandVTestCases#csv", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            String errorMessage = "";
            VandV_ProtoType_2.BLL.InterfaceToBLL b = new InterfaceToBLL();
            VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();

            b.Count_4_6_Gloss_Day = Convert.ToInt32(TestContext.DataRow["4_6_Gloss_NextDay"]);
            b.Count_4_6_Gloss_Hour = Convert.ToInt32(TestContext.DataRow["4_6_Gloss_Hour"]);
            b.Count_4_6_Matte_Day = Convert.ToInt32(TestContext.DataRow["4_6_Matte_NextDay"]);
            b.Count_4_6_Matte_Hour = Convert.ToInt32(TestContext.DataRow["4_6_Matte_Hour"]);

            Decimal expected_result = Convert.ToDecimal(TestContext.DataRow["Expected_Total"]);
            Decimal test_result = 0;

            test_result = d.Calculate(b).Total_Price;
            Assert.AreEqual(test_result, expected_result);

            TestContext.WriteLine(string.Format("test_result: {0}, expected_result: {1}, AssertResult: {2}", test_result, expected_result, errorMessage));

        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


    }
}
