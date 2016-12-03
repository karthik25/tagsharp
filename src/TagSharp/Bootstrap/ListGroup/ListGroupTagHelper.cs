using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagSharp.Context;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.ListGroup
{
    [HtmlTargetElement("ts-list-group")]
    public class ListGroupTagHelper : TagHelper
    {
        private const string ListSourceAttributeName = "bs-list-items";

        [HtmlAttributeName(ListSourceAttributeName)]
        public List<string> ListItems { get; set; }        

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<ul class=""list-group"">{0}</ul>";
            var itemTemplate = @"<li class=""list-group-item"">{0}</li>";

            var listContent = string.Empty;
            if (ListItems != null && ListItems.Any())
            {
                var builder = new StringBuilder();
                foreach (var item in ListItems)
                {
                    builder.AppendLine(string.Format(itemTemplate, item));
                }
                listContent = string.Format(template, builder);
            }
            else
            {
                var contentModel = context.SetItem<ListGroupTagHelper, MultipleItemsContext>();
                contentModel.Items = new List<string>();

                await output.GetChildContentAsync();

                listContent = string.Join("", contentModel.Items);
            }

            output.TagName = "";
            output.Content.AppendHtml(listContent);
        }
    }
}
