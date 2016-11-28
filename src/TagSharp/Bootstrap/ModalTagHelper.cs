using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Context;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-modal")]
    public class ModalTagHelper : TagHelper
    {
        private const string IdentifierAttributeName = "bs-modal-id";

        [HtmlAttributeName(IdentifierAttributeName)]
        public string Identifier { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = new BasicContext();
            context.Items.Add(typeof(ModalTagHelper), contentModel);

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
                                        GetSectionContent("modal-header", contentModel.Header),
                                        GetSectionContent("modal-body", contentModel.Body),
                                        GetSectionContent("modal-footer", contentModel.Footer));

            output.Content.AppendHtml(content);
        }

        private static string GetSectionContent(string sectionClass, string sectionContent)
        {
            if (string.IsNullOrEmpty(sectionContent))
                return string.Empty;
            return string.Format(sectionTemplate, sectionClass, sectionContent);
        }

        private const string sectionTemplate = @"<div class=""{0}"">
                                                    {1}
                                                 </div>";
    }
}
