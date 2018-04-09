using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCart.Shared
{
    public static class CustomHelpers
    {
        public static MvcHtmlString CustomPaging(this HtmlHelper helper, int page, double totalPages)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("pagination-container");

            builder.InnerHtml += "<ul class='pagination'>";

            //RouteValueDictionary o = new RouteValueDictionary(extra);
            //string sortString = "";
            //string filterString = "";

            //if (o["sortOrder"] != null && o["sortOrder"].ToString() != "")
            //{
            //    sortString = "&sortOrder=" + o["sortOrder"].ToString();
            //}
            //if (o["currentFilter"] != null && o["currentFilter"].ToString() != "")
            //{
            //    filterString = "&currentFilter=" + o["currentFilter"].ToString();
            //}
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == page)
                    builder.InnerHtml += String.Format("<li class='active'><a>{0}</a></li>", i);
                else
                    builder.InnerHtml += String.Format("<li><a href='/Product?page={0}'>{0}</a></li>", i);
            }

            builder.InnerHtml += "</ul>";
            return MvcHtmlString.Create(builder.ToString());
        }

    }
}