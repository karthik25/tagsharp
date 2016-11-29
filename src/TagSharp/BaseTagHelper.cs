using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp
{
    public class BaseTagHelper : TagHelper
    {
        public async Task<string> GetContentAsync(TagHelperContext context, TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            return content;
        }

        public async Task<string> GetContentAsync(TagHelperContext context, TagHelperOutput output, string template)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            return string.Format(template, content);
        }
    }
}
