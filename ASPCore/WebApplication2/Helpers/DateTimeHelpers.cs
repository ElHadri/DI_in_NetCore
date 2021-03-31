using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers
{
    public class DateTimeHelpers
    {
        public string LocalTime { get; private set; }

        public DateTimeHelpers()
        {
            LocalTime = DateTime.Now.TimeOfDay.ToString();
        }
    }
}
