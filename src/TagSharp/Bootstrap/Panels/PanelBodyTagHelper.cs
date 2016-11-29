using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;
using TagSharp.Extensions;

namespace TagSharp.Bootstrap.Panels
{
    [HtmlTargetElement("ts-panel-body")]
    public class PanelBodyTagHelper : BaseTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentModel = context.GetItem<PanelTagHelper, IBasicContext>();
            contentModel.Body = await GetContentAsync(context, output);
            output.SuppressOutput();
        }
    }
}
