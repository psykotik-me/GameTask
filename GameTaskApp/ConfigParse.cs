﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTaskApp
{
    internal class ConfigParse
    {
        public int minValue;
        public int maxValue;
        public bool readRange()
        {
            string low = ConfigurationManager.AppSettings["Low"];
            string high = ConfigurationManager.AppSettings["High"];
            if (low == "" || high == "" || low == null || high == null)
            {
                throw new ConfigurationErrorsException("Межі діапазону не задані у конфігураційному файлі! Перевірте App.config");
            }

            if (!int.TryParse(low, out int m) || !int.TryParse(high, out int n))
            {
                throw new ConfigurationErrorsException("Межі діапазону задані не цілими числами у конфігураційному файлі! Перевірте App.config");
            }
            minValue = m;
            maxValue = n;
            return true;
        }
    }
}
