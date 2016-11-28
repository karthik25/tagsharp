﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Context;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap
{    
    [RestrictChildren("ts-bootstrap-panel-header", "ts-bootstrap-panel-body", "ts-bootstrap-panel-footer")]
    [HtmlTargetElement("ts-bootstrap-panel")]
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
            var modalContext = new BasicContext();
            context.Items.Add(typeof(PanelTagHelper), modalContext);

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
