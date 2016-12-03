using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.ListGroup
{
    [HtmlTargetElement("ts-list-group-item", ParentTag = "ts-list-group")]
    public class ListGroupItemTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var itemTemplate = @"<li class=""list-group-item"">{0}</li>";
            var contentModel = context.GetItem<ListGroupTagHelper, IMultipleItemsContext>();
            contentModel.Items.Add(await GetContentAsync(context, output, itemTemplate));
            output.SuppressOutput();
        }
    }
}
