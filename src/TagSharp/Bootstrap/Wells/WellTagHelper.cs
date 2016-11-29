using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Wells
{
    [HtmlTargetElement("ts-well")]
    public class WellTagHelper : BaseTagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<div class=""{1}"">{0}</div>";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? string.Format("well {0}", CssClass) : "well";
            var content = await GetContentAsync(context, output, template, cssClass);
            output.TagName = "";
            output.Content.AppendHtml(content);
        }
    }
}
