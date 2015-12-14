using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeLogic
{
    public class IntChanger
    {
        public void Change(int x)
        {
            x += 1;
        }    
    
        public void Change(ref int x)
        {
            x += 1;
        }
    }
}
