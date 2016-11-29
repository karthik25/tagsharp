using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Wells
{
    [HtmlTargetElement("ts-well-sm")]
    public class WellSmallTagHelper : WellTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "well-sm";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-well-lg")]
    public class WellLargeTagHelper : WellTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "well-lg";
            return base.ProcessAsync(context, output);
        }
    }
}
