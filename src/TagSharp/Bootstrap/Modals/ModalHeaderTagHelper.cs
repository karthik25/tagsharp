using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-modal-header")]
    public class ModalHeaderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = (IBasicContext)context.Items[typeof(ModalTagHelper)];
            var awaiter = await output.GetChildContentAsync();
            contentModel.Heading = awaiter.GetContent();
            output.SuppressOutput();
        }
    }
}
