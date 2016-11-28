using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap.Panels
{
    [HtmlTargetElement("ts-bootstrap-panel-header")]
    public class PanelHeaderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = (IBasicContext)context.Items[typeof(PanelTagHelper)];
            var content = await output.GetChildContentAsync();
            modalContext.Heading = content.GetContent();
            output.SuppressOutput();
        }
    }
}
