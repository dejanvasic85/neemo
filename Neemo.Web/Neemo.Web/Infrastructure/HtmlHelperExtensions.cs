﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Neemo.Web.Infrastructure
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString BootstrapLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.LabelFor(expression, new { @class = "control-label" });
        }

        public static MvcHtmlString FilterLinkDropFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var value = (string)metaData.Model;
            if (string.IsNullOrEmpty(value))
            {
                // Render a dropdown list as we don't have a value
                return html.DropDownListFor(expression, selectList);
            }
            // Render a link to remove the filter
            return new MvcHtmlString("<a remove-filter='"
                + metaData.PropertyName + "'>"
                + value + "&nbsp; <i class='fa fa-times'></i></a>");
        }

        public static MvcHtmlString FilterTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            // We don't need to do too much work here 
            // Because textbox uses default model binding 
            // So we just add the class that will apply the filter automatically
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            return html.TextBoxFor(expression, new { @data_search_filter = metaData.PropertyName });
        }
    }
}