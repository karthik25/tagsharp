using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Alerts
{
    [HtmlTargetElement("ts-alert")]
    public class AlertTagHelper : BaseTagHelper
    {
        private const string CssClassAttributeName = "bs-css-class";
        private const string IdAttributeName = "bs-alert-id";

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var template = @"<div class=""alert {1}"" role=""alert"" {2}>
                                {0}
                             </div>";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "alert-success";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";
            var childContent = await GetContentAsync(context, output, template, cssClass, idAttr);
            output.TagName = "";
            output.Content.AppendHtml(childContent);
        }
    }
}
