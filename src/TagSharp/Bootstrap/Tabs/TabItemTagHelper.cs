using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Tabs
{
    [HtmlTargetElement("ts-tab-item")]
    public class TabItemTagHelper : TagHelper
    {
        private const string LinkAttributeName = "bs-item-link";
        private const string TextAttributeName = "bs-item-text";

        [HtmlAttributeName(LinkAttributeName)]
        public string Link { get; set; }

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IMultipleItemsContext)context.Items[typeof(TabsTagHelper)];

            var template = @" <li class=""{0}""><a href=""#{1}"" data-toggle=""tab"">{2}</a></li>";
            var cssClass = contentModel.Items.Count == 0 ? "active" : "";
            var itemContent = string.Format(template, cssClass, Link, Text);
            contentModel.Items.Add(itemContent);

            output.SuppressOutput();
        }
    }
}
