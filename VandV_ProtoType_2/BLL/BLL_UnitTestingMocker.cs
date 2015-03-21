using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting; //james

namespace VandV_ProtoType_2.BLL
{
    public struct TestCase
    {
        public int[] inputs;
        public decimal expectTotalPrice;
        public string discountCode;
        public string id;
    }
    [TestClass]                                     //james
    public class BLL_UnitTestingMocker
    {
        //static void Main(string[] args)
        //{
        //    new BLL_UnitTestingMocker().runTests();
        //}
        //=====================================================================
        [TestMethod]                                        //james
        public void runTests()
        {
           bool passedAllTest = true;

           //define list of test cases
           List<TestCase> myTestCases = new List<TestCase>();

           //add your test case in the list.
           myTestCases.Add(testAA());
           myTestCases.Add(testBB());
           myTestCases.Add(testCC());

           //Implement some kind of enumerating structure.. so that you can do
           
           foreach (TestCase aTest in myTestCases)
           {
               bool success = runTest(aTest);
               if (!success)
                   passedAllTest = false;

               Assert.AreEqual(success, true);

           }
             
            
           
           if(!passedAllTest)
           {
               Console.WriteLine("*********** One or more tests failed. Please review. **********");

           }else
           {
               Console.WriteLine("------------ All tests passed. -------------");
           }

        }

       //=====================================================================
       public bool runTest(TestCase aTest)
       {

           //map from TestCase to InterfaceToBLL object
           InterfaceToBLL aCase = new InterfaceToBLL();
           aCase.Count_4_6_Gloss_Day = aTest.inputs[0];
           aCase.Count_4_6_Gloss_Hour = aTest.inputs[3];
           aCase.Count_4_6_Matte_Day = aTest.inputs[6];
           aCase.Count_4_6_Matte_Hour = aTest.inputs[9];

           aCase.Count_5_7_Gloss_Day = aTest.inputs[1];
           aCase.Count_5_7_Gloss_Hour = aTest.inputs[4];
           aCase.Count_5_7_Matte_Day = aTest.inputs[7];
           aCase.Count_5_7_Matte_Hour = aTest.inputs[10];

           aCase.Count_8_10_Gloss_Day = aTest.inputs[2];
           aCase.Count_8_10_Gloss_Hour = aTest.inputs[5];
           aCase.Count_8_10_Matte_Day = aTest.inputs[8];
           aCase.Count_8_10_Matte_Hour = aTest.inputs[11];

           aCase.Discount_Code = aTest.discountCode;

           //process the BLL object.
           var returnedBLL = new BLL_Final().Calculate(aCase);

           //now check for the results..
           
           //check total price is equal to expected
           if (!(returnedBLL.Total_Price == aTest.expectTotalPrice))
           {

               Console.WriteLine("***********Failed Test***********");
               Console.WriteLine("Expected final price: " + aTest.expectTotalPrice.ToString("0.00"));
               Console.WriteLine("Resulted final price: " + returnedBLL.Total_Price);
               Console.WriteLine("Test id: " + aTest.id);
               return false;
           }
           else
           {
               Console.WriteLine("---------- Passed Test-----------");
               Console.WriteLine("Test id: " + aTest.id);
               return true;
           }
               

       }
       //=====================================================================
       //unit test methodA
       public TestCase testAA()
       {
           int[] arr=
           {
                1,  1,  1,
                2,  2,  2,
                3,  3,  3,
                4,  5,  6
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "AA";
           aCase.inputs = arr;
           aCase.expectTotalPrice= 19.15m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testBB()
       {
           int[] arr =
           {
                10,  11,  2,
                9,  2,  5,
                13,  3,  3,
                4,  12,  9
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "BB";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 37.31m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testCC()
       {
           int[] arr =
           {
                10,  11,  2,
                9,  2,  5,
                13,  3,  3,
                4,  12,  9
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "CC";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 47.31m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

    }
}
