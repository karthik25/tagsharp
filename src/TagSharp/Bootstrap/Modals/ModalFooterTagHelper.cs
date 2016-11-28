using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-bootstrap-modal-footer")]
    public class ModalFooterTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IBasicContext)context.Items[typeof(ModalTagHelper)];
            var awaiter = await output.GetChildContentAsync();
            contentModel.Footer = awaiter.GetContent();
            output.SuppressOutput();
        }
    }
}
