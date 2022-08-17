using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomexAssesment.Services.Extension
{
    public static class DoubleExtension
    {
        public static double ConvertToRadian(this double degree)
        {
            return (degree * Math.PI / 180.0);
        }
    }
}
