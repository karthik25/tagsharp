using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Context;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-dropdown")]
    public class DropdownTagHelper : TagHelper
    {
        private const string TypeAttributeName = "bs-type";
        private const string CssClassAttributeName = "bs-css-class";
        private const string IdAttributeName = "bs-dropdown-id";

        [HtmlAttributeName(TypeAttributeName)]
        public string Type { get; set; }

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = new MultipleItemsContext();
            context.Items.Add(typeof(DropdownTagHelper), contentContext);

            await output.GetChildContentAsync();

            var template = @"<div class=""{2}"" {3}>
                                {0}
                                <ul class=""dropdown-menu"">
                                 {1}
                                </ul>
                              </div>";
            var type = !string.IsNullOrEmpty(Type) ? Type : "dropdown";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "btn-default";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";

            var items = string.Join("", contentContext.Items.ToArray());
            var finalContent = string.Format(template,
                                             contentContext.Header.Replace("[addOn]", cssClass), 
                                             items,
                                             type,
                                             idAttr);

            output.TagName = "";
            output.Content.AppendHtml(finalContent);
        }
    }
}
