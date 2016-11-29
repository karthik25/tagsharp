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
    }
}
