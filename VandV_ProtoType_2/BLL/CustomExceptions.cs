using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandV_ProtoType_2.BLL
{
    //begin new exception class def
    class OrderGT100Error: System.Exception
    {
        public OrderGT100Error() 
        {
            ;
        }

        public OrderGT100Error(string message):base(message)
        {
            ;
        }
    }//end class def

    //begin new exception class def
    class OrderLEQ0Error: System.Exception
    {
        public OrderLEQ0Error()
        {
            ;
        }

        public OrderLEQ0Error(string message):base(message)
        {
            ;
        }
    }//end class def



}
