using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim
{
    public static class Utill
    {
        public static int StringToInt(this string str) {
            int.TryParse(str, out int num);
            return num;
        }
    }
}
