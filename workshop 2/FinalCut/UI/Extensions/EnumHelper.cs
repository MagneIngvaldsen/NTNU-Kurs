using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcContrib.FluentHtml.Elements;
using MvcContrib.FluentHtml.Expressions;

namespace ITVerket.FinalCut.UI.Extensions
{
    public static class EnumHelper
    {
        public static IList<SelectListItem> ToList<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("T must be an Enum");

            var list = new List<SelectListItem>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                var listItem = new SelectListItem();
                var name = Enum.GetName(typeof(T), value);
                listItem.Text = name;
                listItem.Value = Convert.ToInt32(value).ToString();
                //listItem.Selected = value.ToString() == selected.ToString();
                list.Add(listItem);
            }

            return list;
        }      
    }

}