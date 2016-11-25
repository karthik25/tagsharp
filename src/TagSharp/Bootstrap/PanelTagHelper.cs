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
                              <div class=""panel-heading"">
                                <h3 class=""panel-title"">{0}</h3>
                              </div>
                              <div class=""panel-body"">
                                {1}
                              </div>
                              <div class=""panel-footer"">
                                <h3 class=""panel-title"">{2}</h3>
                              </div>
                            </div>";

            output.TagName = "";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "panel-default";
            output.Content.AppendHtml(string.Format(template, modalContext.Header, modalContext.Body, modalContext.Footer, cssClass));
        }
    }
}
