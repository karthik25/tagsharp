using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Modals
{
    [HtmlTargetElement("ts-modal-body")]
    public class ModalBodyTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<ModalTagHelper, IBasicContext>();
            contentModel.Body = await GetContentAsync(context, output);
            output.SuppressOutput();
        }
    }
}
