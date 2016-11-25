﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-alert-info")]
    public class AlertInfoTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-info";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-alert-warning")]
    public class AlertWarningTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-warning";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-alert-danger")]
    public class AlertDangerTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-danger";
            return base.ProcessAsync(context, output);
        }
    }
}