using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-modal-footer")]
    public class ModalFooterTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<ModalTagHelper, IBasicContext>();
            contentModel.Footer = await GetContentAsync(context, output);
            output.SuppressOutput();
        }
    }
}
