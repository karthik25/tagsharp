using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Panels
{
    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel-success")]
    public class PanelSuccessTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-success";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel-warning")]
    public class PanelWarningTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-warning";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel-danger")]
    public class PanelDangerTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-danger";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel-primary")]
    public class PanelPrimaryTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-primary";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("ts-panel-header", "ts-panel-body", "ts-panel-footer")]
    [HtmlTargetElement("ts-panel-info")]
    public class PanelInfoTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-info";
            return base.ProcessAsync(context, output);
        }
    }
}
