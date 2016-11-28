using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Labels
{
    [HtmlTargetElement("ts-bootstrap-label")]
    public class LabelTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<span class=""{0}"">{1}</span>";
            var childContentAwaiter = await output.GetChildContentAsync();
            var childContent = childContentAwaiter.GetContent();

            var cssClass = !string.IsNullOrEmpty(CssClass) ? string.Format("label {0}", CssClass) : "label label-default";

            output.TagName = "";
            output.Content.AppendHtml(string.Format(template, cssClass, childContent));
        }
    }
}
