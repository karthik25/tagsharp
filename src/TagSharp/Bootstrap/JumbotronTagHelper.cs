using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-jumbotron")]
    public class JumbotronTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();

            var template = @"<div class=""jumbotron"">{0}</div>";

            output.TagName = "";
            output.Content.AppendHtml(string.Format(template, content));
        }
    }
}
