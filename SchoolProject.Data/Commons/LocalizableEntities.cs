﻿using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class LocalizableEntities
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string GetLocalized()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return NameAr;
            }
            else
            {
                return NameEn;
            }
        }

    }
}
