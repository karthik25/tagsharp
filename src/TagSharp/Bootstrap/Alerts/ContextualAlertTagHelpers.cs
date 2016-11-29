using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Alerts
{
    [HtmlTargetElement("ts-alert-success")]
    public class AlertSuccessTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-success";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-alert-info")]
    public class AlertInfoTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-info";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-alert-warning")]
    public class AlertWarningTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-warning";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-alert-danger")]
    public class AlertDangerTagHelper : AlertTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "alert-danger";
            return base.ProcessAsync(context, output);
        }
    }
}
