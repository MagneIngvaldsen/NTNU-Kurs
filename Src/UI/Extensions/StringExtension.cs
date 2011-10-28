using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITVerket.FinalCut.UI.Extensions
{
    public static class StringExtension
    {
        public static string ToUrlText(this string text)
        {
            text = text.Replace(' ', '_');
            return text;
        }

        public static string FromUrlText(this string text)
        {
            text = text.Replace('_', ' ');
            return text;
        }
    }
}