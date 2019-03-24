using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class QFormat<T>
    {
        public static int FractionalBits;
    }

    public sealed class Q24_8 : QFormat<Q24_8>
    {
        static Q24_8() => FractionalBits = 8;
    }
    public sealed class Q16_16 : QFormat<Q16_16>
    {
        static Q16_16() => FractionalBits = 16;
    }
    public sealed class Q8_24 : QFormat<Q8_24>
    {
        static Q8_24() => FractionalBits = 24;
    }
}
