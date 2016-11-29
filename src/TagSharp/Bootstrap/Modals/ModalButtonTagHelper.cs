using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-modal-launcher")]
    public class ModalButtonTagHelper : TagHelper
    {
        private const string IdentifierAttributeName = "bs-modal-id";
        private const string CssClassAttributeName = "bs-css-class";
        private const string LauncherTypeAttributeName = "bs-launcher-type";

        [HtmlAttributeName(IdentifierAttributeName)]
        public string Identifier { get; set; }

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(LauncherTypeAttributeName)]
        public LauncherType? LauncherType { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (LauncherType == null)
                LauncherType = Bootstrap.LauncherType.Button;

            var awaiter = await output.GetChildContentAsync();
            var linkContent = awaiter.GetContent();

            var launcherContent = string.Empty;
            if (LauncherType == Bootstrap.LauncherType.Anchor)
            {
                var template = @"<a href=""javascript:void(0)"" class=""{0}"" data-toggle=""modal"" data-target=""#{1}"">
                                  {2}
                                </button>";
                launcherContent = string.Format(template, CssClass, Identifier, linkContent);
            }
            else if (LauncherType == Bootstrap.LauncherType.Button)
            {
                var template = @"<button type=""button"" class=""{0}"" data-toggle=""modal"" data-target=""#{1}"">
                                  {2}
                                </button>";
                launcherContent = string.Format(template, CssClass, Identifier, linkContent);
            }

            output.TagName = "";
            output.Content.AppendHtml(launcherContent);
        }
    }
}
