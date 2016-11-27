﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-btn-success-dropdown")]
    public class DropdownSuccessButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-success";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-btn-primary-dropdown")]
    public class DropdownPrimaryButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-primary";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-btn-info-dropdown")]
    public class DropdownInfoButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-info";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-btn-danger-dropdown")]
    public class DropdownDangerButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-danger";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-btn-warning-dropdown")]
    public class DropdownWarningButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-warning";
            return base.ProcessAsync(context, output);
        }
    }
}