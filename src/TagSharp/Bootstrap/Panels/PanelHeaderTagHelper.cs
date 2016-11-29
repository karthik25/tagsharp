using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Panels
{
    [HtmlTargetElement("ts-panel-header")]
    public class PanelHeaderTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<PanelTagHelper, IBasicContext>();
            contentModel.Heading = await GetContentAsync(context, output);
            output.SuppressOutput();
        }
    }
}
