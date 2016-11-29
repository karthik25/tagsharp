using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Context;

namespace TagSharp.Bootstrap.Tabs
{
    [HtmlTargetElement("ts-tabs")]
    public class TabsTagHelper : TagHelper
    {
        private const string IdAttributeName = "bs-tabs-id";

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = new MultipleItemsContext();
            context.Items.Add(typeof(TabsTagHelper), contentModel);

            await output.GetChildContentAsync();

            var template = @"<ul class=""nav nav-tabs"" data-tabs=""tabs"" {2}>
                                {0}
                            </ul>
                            <div class=""tab-content"">
                                {1}
                            </div>";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";
            var finalContent = string.Format(template,
                                             string.Join("", contentModel.Items.ToArray()),
                                             string.Join("", contentModel.Contents.ToArray()),
                                             idAttr);

            output.TagName = "";
            output.Content.AppendHtml(finalContent);
        }
    }
}
