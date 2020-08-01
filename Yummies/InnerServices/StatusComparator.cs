using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummies.InnerServices
{
    public class StatusComparator
    {
        public static int GetStatusPosition(string status)
        {
            var names = Enum.GetNames(typeof(Statuses));

            for (int i = 0; i < names.Length; i++)
            {
                if (status==names[i])
                {
                    return (int)Enum.Parse(typeof(Statuses), names[i]);
                }
            }
            return -1;
        }
    }
}
