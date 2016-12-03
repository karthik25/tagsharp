using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-badge")]
    public class BadgeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            output.TagName = "span";
            output.Attributes.Add("class", "badge");
            output.Content.SetHtmlContent(content);
        }
    }
}
