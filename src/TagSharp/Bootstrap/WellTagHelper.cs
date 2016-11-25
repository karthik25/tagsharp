using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-well")]
    public class WellTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<div class=""{0}"">{1}</div>";
            var childContentAwaiter = await output.GetChildContentAsync();
            var childContent = childContentAwaiter.GetContent();

            var cssClass = !string.IsNullOrEmpty(CssClass) ? string.Format("well {0}", CssClass) : "well";

            output.TagName = "";
            output.Content.AppendHtml(string.Format(template, cssClass, childContent));
        }
    }    
}
