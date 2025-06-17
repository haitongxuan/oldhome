using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Core.Attributes
{
    public class TimesPerDayAttribute : Attribute
    {
        public TimesPerDayAttribute(int times)
        {
            Times = times;
        }

        public int Times { get; }
    }
}
