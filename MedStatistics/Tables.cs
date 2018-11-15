﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedStatistics
{
    static class Tables
    {
        public static string ConvertTable(int type)
        {
            switch (type)
            {
                case 1 : return "Procedures";
                case 2 : return "Diseases";
                case 3 : return "Metrics";
            }

            return "";
        }
    }
}
