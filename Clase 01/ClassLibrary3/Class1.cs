using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Class105
    {
        private int myVariable = 5;

        public int MyProperty
        {
            get { return myVariable = 5; }
            set { myVariable = 5; }
        }

        ClassLibrary2.Class5 x = new ClassLibrary2.Class5();

    }
}
