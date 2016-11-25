using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-panel-footer")]
    public class PanelFooterTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = (IBasicContext)context.Items[typeof(PanelTagHelper)];
            var content = await output.GetChildContentAsync();
            modalContext.Footer = content.GetContent();
            output.SuppressOutput();
        }
    }
}
