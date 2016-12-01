using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Context;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-modal")]
    public class ModalTagHelper : TagHelper
    {
        private const string IdentifierAttributeName = "bs-modal-id";

        [HtmlAttributeName(IdentifierAttributeName)]
        public string Identifier { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.SetItem<ModalTagHelper, BasicContext>();

            await output.GetChildContentAsync();

            var template = @"<div class=""modal fade"" id=""{0}"" tabindex=""-1"" role=""dialog"">
                              <div class=""modal-dialog"" role=""document"">
                                <div class=""modal-content"">
                                  {1}
                                  {2}
                                  {3}
                                </div>
                              </div>
                            </div>";
            var content = string.Format(template,
                                        Identifier,
                                        contentModel.Heading.GetSectionContent("modal-header"),
                                        contentModel.Body.GetSectionContent("modal-body"),
                                        contentModel.Footer.GetSectionContent("modal-footer"));

            output.Content.AppendHtml(content);
        }
    }
}
