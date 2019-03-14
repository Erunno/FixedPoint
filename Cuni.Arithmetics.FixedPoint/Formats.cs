using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class QFormat
    {
        public abstract int GetNumOfFractionalBits();
    }

    public class Q24_8 : QFormat
    {
        public override int GetNumOfFractionalBits() => 8;
    }
    public class Q16_16 : QFormat
    {
        public override int GetNumOfFractionalBits() => 16;
    }
    public class Q8_24 : QFormat
    {
        public override int GetNumOfFractionalBits() => 24;
    }
}
