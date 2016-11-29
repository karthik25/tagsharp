using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Tabs
{
    [HtmlTargetElement("ts-tab-items")]
    public class TabItemHolderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IMultipleItemsContext)context.Items[typeof(TabsTagHelper)];
            contentModel.Items = new List<string>();

            await output.GetChildContentAsync();

            output.SuppressOutput();
        }
    }
}
