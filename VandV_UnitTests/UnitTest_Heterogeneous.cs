using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VandV_ProtoType_2;
using VandV_ProtoType_2.BLL;

namespace VandV_UnitTests
{
    [TestClass]
    public class UnitTest_Heterogeneous
    {
        [TestMethod]
        public void TestMethod1()
        {

            VandV_ProtoType_2.BLL.InterfaceToBLL b = new InterfaceToBLL();
            VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();

            b.Count_4_6_Gloss_Day = 3;
            b.Count_4_6_Gloss_Hour = 4;
            Assert.AreEqual(d.Calculate(b).Total_Price, 3.0);

        }
    }
}
