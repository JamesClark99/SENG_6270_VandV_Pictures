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
    //[TestClass]                                     //james
    public class BLL_UnitTestingMocker
    {
        
        //static void Main(string[] args)
        //{
        //    new BLL_UnitTestingMocker().runTests();
            //var a = new BLL_UnitTestingMocker();
            //a.runTest(a.testTC_6());
        //}
         
        //=====================================================================
        //[TestMethod]                                        //james
        public void runTests()
        {
           bool passedAllTest = true;

           //define list of test cases
           List<TestCase> myTestCases = new List<TestCase>();

           //add your test case in the list.
           myTestCases.Add(testTC_2());
           myTestCases.Add(testTC_3());
           myTestCases.Add(testTC_4());
           myTestCases.Add(testTC_5());
           myTestCases.Add(testTC_6());
           myTestCases.Add(testTC_7());
           myTestCases.Add(testTC_10());
           myTestCases.Add(testTC_11());
           myTestCases.Add(testTC_12());
           myTestCases.Add(testTC_13());
           myTestCases.Add(testTC_14());
           myTestCases.Add(testTC_15());
           myTestCases.Add(testTC_18());
           myTestCases.Add(testTC_19());
           myTestCases.Add(testTC_20());
           myTestCases.Add(testTC_21());
           myTestCases.Add(testTC_22());
           myTestCases.Add(testTC_23());
           myTestCases.Add(testTC_26());
           myTestCases.Add(testTC_27());
           myTestCases.Add(testTC_28());
           myTestCases.Add(testTC_29());
           myTestCases.Add(testTC_30());
           myTestCases.Add(testTC_31());
           myTestCases.Add(testTC_34());
           myTestCases.Add(testTC_35());
           myTestCases.Add(testTC_36());
           myTestCases.Add(testTC_37());
           myTestCases.Add(testTC_38());
           myTestCases.Add(testTC_39());
           myTestCases.Add(testTC_42());
           myTestCases.Add(testTC_43());
           myTestCases.Add(testTC_44());
           myTestCases.Add(testTC_45());
           myTestCases.Add(testTC_46());
           myTestCases.Add(testTC_47());
           //Implement some kind of enumerating structure.. so that you can do
           
           foreach (TestCase aTest in myTestCases)
           {
               bool success = runTest(aTest);
               if (!success)
                   passedAllTest = false;

               //Assert.AreEqual(success, true);

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
           Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ Starting Test ~~~~~~~~~~~~~~~~");
           Console.WriteLine("Test id: " + aTest.id);
           var returnedBLL = new BLL_Final().Calculate(aCase);

           //now check for the results..
           
           //check total price is equal to expected
           if (!(returnedBLL.Total_Price == aTest.expectTotalPrice))
           {

               Console.WriteLine("****************Failed Test***************");
               Console.WriteLine("Test id: " + aTest.id);
               Console.WriteLine("Expected final price: " + aTest.expectTotalPrice.ToString("0.00"));
               Console.WriteLine("Resulted final price: " + returnedBLL.Total_Price);               
               Console.WriteLine("Receipt: " + returnedBLL.Receipt);
               Console.WriteLine("************** End of Message ************");
               return false;
           }
           else
           {
               Console.WriteLine("---------------Passed Test----------------");
               Console.WriteLine("Test id: " + aTest.id);
               Console.WriteLine("------------- End of Message--------------");
               return true;
           }
               

       }
       //=====================================================================
       //unit test method
       public TestCase testTC_2()
       {
           int[] arr =
           {
                1,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0,
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_2";
           aCase.inputs = arr;
           aCase.expectTotalPrice = .14m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_3()
       {
           int[] arr =
           {
                50,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_3";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 7.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testTC_4()
       {
           int[] arr =
           {
                51,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_4";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 7.12m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testTC_5()
       {
           int[] arr =
           {
                75,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_5";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 10.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testTC_6()
       {
           int[] arr =
           {
                76,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_6";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 10.10m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
       public TestCase testTC_7()
       {
           int[] arr =
           {
                100,  0,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_7";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 12.50m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_10()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                1,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_10";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 0.16m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

       //=====================================================================
       //unit test method

       public TestCase testTC_11()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                50,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_11";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 8.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_12()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                51,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_12";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 8.14m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_13()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                75,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_13";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 11.50m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_14()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                76,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_14";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 11.62m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_15()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                100,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_15";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 12.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_18()
       {
           int[] arr =
           {
                0,  1,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_18";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 0.34m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_19()
       {
           int[] arr =
           {
                0,  50,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_19";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 17.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_20()
       {
           int[] arr =
           {
                0,  51,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_20";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 17.31m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_21()
       {
           int[] arr =
           {
                0,  75,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_21";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 24.75m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_22()
       {
           int[] arr =
           {
                0,  76,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_22";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 25.03m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_23()
       {
           int[] arr =
           {
                0,  100,  0,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_18";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 29.25m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_26()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  1,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_26";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 0.37m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_27()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  50,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_27";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 18.50m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

       //=====================================================================
       //unit test method

       public TestCase testTC_28()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  51,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_28";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 18.83m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

       //=====================================================================
       //unit test method

       public TestCase testTC_29()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  75,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_29";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 26.75m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_30()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  76,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_30";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 28.07m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_31()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  100,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_31";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 32.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method
        
       public TestCase testTC_34()
       {
           int[] arr =
           {
                0,  0,  1,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_34";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 0.68m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_35()
       {
           int[] arr =
           {
                0,  0,  50,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_35";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 34.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

       //=====================================================================
       //unit test method

       public TestCase testTC_36()
       {
           int[] arr =
           {
                0,  0,  51,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_36";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 34.64m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }       //=====================================================================
       //unit test method

       public TestCase testTC_37()
       {
           int[] arr =
           {
                0,  0,  75,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_37";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 50.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }       //=====================================================================
       //unit test method

       public TestCase testTC_38()
       {
           int[] arr =
           {
                0,  0,  76,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_38";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 50.60m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }       
       //=====================================================================
       //unit test method

       public TestCase testTC_39()
       {
           int[] arr =
           {
                0,  0,  100,
                0,  0,  0,
                0,  0,  0,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_39";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 62.50m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_42()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  1,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_42";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 0.72m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }        
        //=====================================================================
       //unit test method

       public TestCase testTC_43()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  50,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_43";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 36.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_44()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  51,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_44";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 36.68m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_45()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  75,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_45";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 53.00m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_46()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  76,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_46";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 53.64m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }
       //=====================================================================
       //unit test method

       public TestCase testTC_47()
       {
           int[] arr =
           {
                0,  0,  0,
                0,  0,  0,
                0,  0,  100,
                0,  0,  0
           };

           //declare a test case
           TestCase aCase;

           //initialize values
           aCase.id = "TC_47";
           aCase.inputs = arr;
           aCase.expectTotalPrice = 66.50m;
           aCase.discountCode = "HELLO_KITTIE";

           //return test case
           return aCase;
       }

    }
}
