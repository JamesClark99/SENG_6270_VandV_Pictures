﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VandV_ProtoType_2;
using VandV_ProtoType_2.BLL;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            VandV_ProtoType_2.BLL.InterfaceToBLL b = new InterfaceToBLL();
            VandV_ProtoType_2.BLL.BLL_Debug d = new BLL_Debug();

            b.Count_4_6_Gloss_Day = 3;

            Assert.AreEqual(d.Calculate(b).Total_Price, 3.0);

        }
    }
}
