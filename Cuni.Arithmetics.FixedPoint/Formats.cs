using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class QFormat
    {
        public static int FractionalBitsCount { get; protected set; }
    }

    public class Q24_8 : QFormat
    {
        static Q24_8()
        {
            FractionalBitsCount = 8;
        }
    }
    public class Q16_16 : QFormat
    {
        static Q16_16()
        {
            FractionalBitsCount = 16;
        }
    }
    public class Q8_24 : QFormat
    {
        static Q8_24()
        {
            FractionalBitsCount = 24;
        }
    }
}
