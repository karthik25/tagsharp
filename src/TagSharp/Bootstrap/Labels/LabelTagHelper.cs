using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Labels
{
    [HtmlTargetElement("ts-label")]
    public class LabelTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContentAwaiter = await output.GetChildContentAsync();
            var childContent = childContentAwaiter.GetContent();

            var cssClass = !string.IsNullOrEmpty(CssClass) ? string.Format("label {0}", CssClass) : "label label-default";

            output.TagName = "span";
            output.Attributes.Add("class", cssClass);
            output.Content.SetHtmlContent(childContent);
        }
    }
}
