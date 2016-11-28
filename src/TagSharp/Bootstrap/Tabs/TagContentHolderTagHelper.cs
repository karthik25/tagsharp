using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Tabs
{
    [HtmlTargetElement("ts-bootstrap-tab-contents")]
    public class TagContentHolderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IMultipleItemsContext)context.Items[typeof(TabsTagHelper)];
            contentModel.Contents = new List<string>();

            await output.GetChildContentAsync();

            output.SuppressOutput();
        }
    }
}
