using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-dropdown-seperator", ParentTag = "ts-dropdown-list")]
    public class DropdownItemSeperatorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<DropdownTagHelper, IMultipleItemsContext>();
            var seperator = @"<li role=""separator"" class=""divider""></li>";
            contentModel.Items.Add(seperator);
            output.SuppressOutput();
        }
    }
}
