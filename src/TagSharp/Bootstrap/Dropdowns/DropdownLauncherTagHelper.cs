using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-button")]
    public class DropdownLauncherTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<button class=""btn [addOn] dropdown-toggle"" type=""button"" 
                                     data-toggle=""dropdown"" aria-haspopup=""true"" 
                                     aria-expanded=""true"">
                               {0}
                               <span class=""caret""></span>
                             </button>";
            var contentModel = context.GetItem<DropdownTagHelper, IMultipleItemsContext>();
            contentModel.Header = await GetContentAsync(context, output, template);
            output.SuppressOutput();
        }
    }
}
