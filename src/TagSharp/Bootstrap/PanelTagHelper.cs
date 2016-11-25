using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Context;

namespace TagSharp.Bootstrap
{    
    [RestrictChildren("ts-bootstrap-panel-header", "ts-bootstrap-panel-body", "ts-bootstrap-panel-footer")]
    [HtmlTargetElement("ts-bootstrap-panel")]
    public class PanelTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = new BasicContext();
            context.Items.Add(typeof(PanelTagHelper), modalContext);

            await output.GetChildContentAsync();

            var template = @"<div class=""panel {3}"">
                              {0}
                              {1}
                              {2}
                            </div>";

            output.TagName = "";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "panel-default";
            output.Content.AppendHtml(string.Format(template, 
                                                    GetSectionContent("panel-heading", modalContext.Header), 
                                                    GetSectionContent("panel-body", modalContext.Body), 
                                                    GetSectionContent("panel-footer", modalContext.Footer), 
                                                    cssClass));
        }

        private static string GetSectionContent(string sectionClass, string sectionContent)
        {
            if (string.IsNullOrEmpty(sectionContent))
                return string.Empty;
            return string.Format(sectionTemplate, sectionClass, sectionContent);
        }

        private const string sectionTemplate = @"<div class=""{0}"">
                                                    {1}
                                                 </div>";
    }
}
