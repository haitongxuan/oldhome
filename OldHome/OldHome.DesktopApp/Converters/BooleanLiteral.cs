using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OldHome.DesktopApp.Converters
{
    public class BooleanLiteral : Literal<bool>
    {
        public BooleanLiteral(bool value)
            : base(value)
        {
        }
    }
}
