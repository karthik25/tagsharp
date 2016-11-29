using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-dropdown-list")]
    public class DropdownListTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = (IMultipleItemsContext)context.Items[typeof(DropdownTagHelper)];
            contentContext.Items = new List<string>();

            await output.GetChildContentAsync();

            output.SuppressOutput();
        }
    }
}
