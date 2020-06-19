using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("sr-pagination", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PaginationTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IUrlHelper urlHelper;
        public PaginationTagHelper(
            IHttpContextAccessor httpContextAccessor,
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.actionContextAccessor = actionContextAccessor;
            this.urlHelperFactory = urlHelperFactory;
            urlHelper =
                urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }


        public string Id { get; set; } = "sr-pagination";
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }


        object BuildRoute(string page)
        {
            bool keyAdded = false;
            var route = new Dictionary<string, object>();
            foreach (var query in httpContextAccessor.HttpContext.Request.Query)
            {
                if (query.Key == "page")
                {
                    route.Add(query.Key, page);
                    keyAdded = true;
                }
                else
                {
                    route.Add(query.Key, query.Value);
                }
            }
            if (!keyAdded) route.Add("page", page);
            return route;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var previousPageIsEllipsis = false;


            output.TagName = "div";
            if (TotalPages > 1)
            {
                output.Content.AppendHtml($"<ul class=\"pagination\" id=\"{Id}\">");
                for (int p = 1; p <= TotalPages; p++)
                {
                    // Add left arrow
                    if (p == 1)
                    {
                        if (p == CurrentPage)
                        {
                            output.Content.AppendHtml("<li class=\"page-item\">");
                            output.Content.AppendHtml("<span class=\"page-link\" aria-hidden=\"true\">« Prev</span>");
                            output.Content.AppendHtml("<span class=\"sr-only page-link\">Previous</span>");
                            output.Content.AppendHtml("</li>");
                        }
                        else
                        {
                            output.Content.AppendHtml("<li class=\"page-item\">");
                            output.Content.AppendHtml($"<a class=\"page-link\" href=\"{urlHelper.Action(Action, Controller, BuildRoute((CurrentPage - 1).ToString()))}\" aria-label=\"Previous page\">");
                            output.Content.AppendHtml("<span aria-hidden=\"true\">« Prev</span>");
                            output.Content.AppendHtml("<span class=\"sr-only\">Previous</span>");
                            output.Content.AppendHtml("</a>");
                            output.Content.AppendHtml("</li>");
                        }
                    }

                    if (p == CurrentPage ||
                        p == 1 ||
                        p == CurrentPage - 1 ||
                        p == CurrentPage + 1 ||

                        p == CurrentPage - 2 ||
                        p == CurrentPage + 2 ||

                        p == CurrentPage - 3 ||
                        p == CurrentPage + 3 ||


                        p == TotalPages)
                    {
                        string active = (p == CurrentPage) ? " active" : String.Empty;
                        output.Content.AppendHtml($"<li class=\"page-item{active}\">");
                        output.Content.AppendHtml($"<a class=\"page-link\" href=\"{urlHelper.Action(Action, Controller, BuildRoute((p).ToString()))}\" title=\"Go to page {p.ToString()}\">");
                        output.Content.Append($"{p.ToString()}");
                        output.Content.AppendHtml("</a>");
                        output.Content.AppendHtml("</li>");
                        previousPageIsEllipsis = false;
                    }
                    else
                    {
                        if (previousPageIsEllipsis)
                        {
                            continue;
                        }
                        else
                        {
                            output.Content.AppendHtml("<li class=\"page-item\">");
                            output.Content.AppendHtml("<span class=\"page-link\">...</span>");
                            output.Content.AppendHtml("</li>");
                            previousPageIsEllipsis = true;
                        }
                    }

                    //Add right arrow /
                    if (p == TotalPages)
                    {
                        if (p == CurrentPage)
                        {
                            output.Content.AppendHtml("<li class=\"page-item\">");
                            output.Content.AppendHtml("<span class=\"page-link\" aria-hidden=\"true\">Next »</span>");
                            output.Content.AppendHtml("<span class=\"sr-only page-link\">Next</span>");
                            output.Content.AppendHtml("</li>");
                        }
                        else
                        {
                            output.Content.AppendHtml("<li class=\"page-item\">");
                            output.Content.AppendHtml($"<a class=\"page-link\" href=\"{urlHelper.Action(Action, Controller, BuildRoute((CurrentPage + 1).ToString()))}\" title=\"Next page\">");
                            output.Content.AppendHtml("<span aria-hidden=\"true\">Next »</span>");
                            output.Content.AppendHtml("<span class=\"sr-only\">Next</span>");
                            output.Content.AppendHtml("</a>");
                            output.Content.AppendHtml("</li>");
                        }
                    }
                }
                output.Content.AppendHtml("</ul>");
            }

        }
    }
}
