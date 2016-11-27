using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Context;
using TagSharp.Abstract;
using System.Collections.Generic;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-tabs")]
    public class TabsTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = new MultipleItemsContext();
            context.Items.Add(typeof(TabsTagHelper), contentModel);

            await output.GetChildContentAsync();

            var template = @"<ul class=""nav nav-tabs"" data-tabs=""tabs"">
                                {0}
                            </ul>
                            <div class=""tab-content"">
                                {1}
                            </div>";
            var finalContent = string.Format(template,
                                             string.Join("", contentModel.Items.ToArray()),
                                             string.Join("", contentModel.Contents.ToArray()));

            output.TagName = "";
            output.Content.AppendHtml(finalContent);
        }
    }

    [HtmlTargetElement("ts-bootstrap-tab-items")]
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

    [HtmlTargetElement("ts-bootstrap-tab-item")]
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

    [HtmlTargetElement("ts-bootstrap-tab-content")]
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
