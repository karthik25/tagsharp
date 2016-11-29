using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace TagSharp
{
    public class BaseTagHelper : TagHelper
    {
        public async Task<string> GetContentAsync(TagHelperContext context, 
                                                  TagHelperOutput output)
        {
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            return content;
        }
        
        public async Task<string> GetContentAsync(TagHelperContext context, 
                                                  TagHelperOutput output, 
                                                  string template, 
                                                  params string[] parameters)
        {
            var content = await GetContentAsync(context, output);
            var values = new[] { content }.Concat(parameters).ToArray();
            return string.Format(template, values);
        }
    }
}
