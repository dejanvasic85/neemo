using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Neemo.Web.Infrastructure
{
    public static class BootstrapExtensions
    {
        public static MvcHtmlString BootstrapLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.LabelFor(expression, new {@class = "control-label"});
        }
    }
}