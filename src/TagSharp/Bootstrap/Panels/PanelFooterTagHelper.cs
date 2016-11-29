using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Panels
{
    [HtmlTargetElement("ts-panel-footer")]
    public class PanelFooterTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<PanelTagHelper, IBasicContext>();
            contentModel.Footer = await GetContentAsync(context, output);
            output.SuppressOutput();
        }
    }
}
