using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagSharp.Abstract;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("bootstrap-panel-body")]
    public class PanelBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = (IBasicContext)context.Items[typeof(PanelTagHelper)];
            var content = await output.GetChildContentAsync();
            modalContext.Body = content.GetContent();
            output.SuppressOutput();
        }
    }
}
