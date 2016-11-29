using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-dropdown-item", ParentTag = "ts-dropdown-list")]
    public class DropdownItemTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<li>{0}</li>";
            var contentModel = context.GetItem<DropdownTagHelper, IMultipleItemsContext>();
            contentModel.Items.Add(await GetContentAsync(context, output, template));
            output.SuppressOutput();
        }
    }
}
