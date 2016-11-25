using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-badge")]
    public class BadgeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            var html = string.Format(@"<span class=""badge"">{0}</span>", content);

            output.TagName = "";
            output.Content.AppendHtml(html);
        }
    }
}
