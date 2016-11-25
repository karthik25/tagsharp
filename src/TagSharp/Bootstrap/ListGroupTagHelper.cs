using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-list-group")]
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
                var listContentAwaiter = await output.GetChildContentAsync();
                listContent = listContentAwaiter.GetContent();
            }

            output.Content.AppendHtml(listContent);
        }
    }

    [HtmlTargetElement("ts-bootstrap-list-group-item")]
    public class ListGroupItemTagHelper : TagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.ProcessAsync(context, output);
        }
    }
}
