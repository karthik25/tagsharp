﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-alert")]
    public class AlertTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContentAwaiter = await output.GetChildContentAsync();
            var childContent = childContentAwaiter.GetContent();

            var template = @"<div class=""alert {0}"" role=""alert"">
                                {1}
                             </div>";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "alert-success";

            output.TagName = "";
            output.Content.AppendHtml(string.Format(template, cssClass, childContent));
        }
    }
}
