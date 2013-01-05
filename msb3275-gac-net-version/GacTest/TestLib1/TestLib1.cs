using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLib2;

namespace TestLib1
{
    public static class TestLib1
    {
        public static String GetString()
        {
            return "testlib1 " + TestLib2.TestLib2.GetString();
        }
    }
}
