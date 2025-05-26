using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Converters
{
    public class IntegerLiteral : Literal<int>
    {
        public IntegerLiteral(int value)
            : base(value)
        {
        }
    }
}
