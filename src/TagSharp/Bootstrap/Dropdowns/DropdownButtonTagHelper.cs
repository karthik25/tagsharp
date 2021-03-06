﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-btn-dropdown")]
    public class DropdownButtonTagHelper : DropdownTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Type = "btn-group";
            this.CssClass = "btn-default";
            return base.ProcessAsync(context, output);
        }
    }
}
