﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Context;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Panels
{
    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel")]
    public class PanelTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";
        private const string IdAttributeName = "bs-panel-id";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = context.SetItem<PanelTagHelper, BasicContext>();
            await output.GetChildContentAsync();

            var template = @"<div class=""panel {3}"" {4}>
                              {0}
                              {1}
                              {2}
                            </div>";

            output.TagName = "";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "panel-default";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";
            output.Content.AppendHtml(string.Format(template, 
                                                    modalContext.Heading.GetSectionContent("panel-heading"),
                                                    modalContext.Body.GetSectionContent("panel-body"),
                                                    modalContext.Footer.GetSectionContent("panel-footer"), 
                                                    cssClass,
                                                    idAttr));
        }
    }
}
