using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Tabs
{
    [HtmlTargetElement("ts-tab-content")]
    public class TabContentTagHelper : TagHelper
    {
        private const string LinkAttributeName = "bs-item-link";

        [HtmlAttributeName(LinkAttributeName)]
        public string Link { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IMultipleItemsContext)context.Items[typeof(TabsTagHelper)];

            var template = @"<div class=""tab-pane {0}"" id=""{1}"">
                                {2}
                            </div>";

            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();
            var cssClass = contentModel.Contents.Count == 0 ? "active" : "";
            var contentContent = string.Format(template, cssClass, Link, content);

            contentModel.Contents.Add(contentContent);

            output.SuppressOutput();
        }
    }
}
