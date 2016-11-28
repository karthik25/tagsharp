using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-bootstrap-modal-body")]
    public class ModalBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IBasicContext)context.Items[typeof(ModalTagHelper)];
            var awaiter = await output.GetChildContentAsync();
            contentModel.Body = awaiter.GetContent();
            output.SuppressOutput();
        }
    }
}
