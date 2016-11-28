using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Alerts
{
    [HtmlTargetElement("ts-bootstrap-alert")]
    public class AlertTagHelper : TagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";
        private const string IdAttributeName = "bs-alert-id";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContentAwaiter = await output.GetChildContentAsync();
            var childContent = childContentAwaiter.GetContent();

            var template = @"<div class=""alert {0}"" role=""alert"" {2}>
                                {1}
                             </div>";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "alert-success";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";

            output.TagName = "";
            output.Content.AppendHtml(string.Format(template, cssClass, childContent, idAttr));
        }
    }
}
