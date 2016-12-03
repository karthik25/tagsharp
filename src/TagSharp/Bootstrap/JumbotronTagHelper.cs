using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-jumbotron")]
    public class JumbotronTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();            
            output.TagName = "div";
            output.Attributes.Add("class", "jumbotron");
            output.Content.SetHtmlContent(content);
        }
    }
}
