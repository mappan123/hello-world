using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.CCD.Common.Extension
{
    public static class StringExtension
    {
        private static CultureInfo ci = CultureInfo.GetCultureInfo("sl-SI");

        private static readonly string[] Formats =
        {
            "M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", "M/d/yyyy hh:mm tt",
            "M/d/yyyy hh tt", "M/d/yyyy h:mm", "M/d/yyyy h:mm",
            "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "yyyyMMdd", "yyyyMMdd HHmmss", "yyyyMMddHHmmss", "yyyyMMddHHmmK",
            "yyyyMMddHHmmssK", "yyyyMMdd HHmmssfff", "yyyyMMddHHmmssfff", "yyyyMM", "yyyy"
        };

        public static DateTime? ParseDateInternational(this string dbDate, DateTime? inputDate)
        {
            var tempDate = DateTime.MaxValue;

            return (DateTime.TryParseExact(dbDate, Formats, ci, DateTimeStyles.AdjustToUniversal, out tempDate))
                ? tempDate
                : inputDate;
        }

        public static Guid GetGuid(this string entityId)
        {
            var guid = Guid.NewGuid();
            if (entityId != null && entityId.Length >= 36)
            {
                Guid.TryParse(entityId.Substring(0, 36), out guid);
            }

            return guid;
        }
    }
}
