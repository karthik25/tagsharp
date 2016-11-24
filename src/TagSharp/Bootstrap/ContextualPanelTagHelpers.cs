using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap
{
    [RestrictChildren("bootstrap-panel-header", "bootstrap-panel-body", "bootstrap-panel-footer")]
    [HtmlTargetElement("bootstrap-panel-success")]
    public class PanelSuccessTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-success";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("bootstrap-panel-header", "bootstrap-panel-body", "bootstrap-panel-footer")]
    [HtmlTargetElement("bootstrap-panel-warning")]
    public class PanelWarningTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-warning";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("bootstrap-panel-header", "bootstrap-panel-body", "bootstrap-panel-footer")]
    [HtmlTargetElement("bootstrap-panel-danger")]
    public class PanelDangerTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-danger";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("bootstrap-panel-header", "bootstrap-panel-body", "bootstrap-panel-footer")]
    [HtmlTargetElement("bootstrap-panel-primary")]
    public class PanelPrimaryTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-primary";
            return base.ProcessAsync(context, output);
        }
    }

    [RestrictChildren("bootstrap-panel-header", "bootstrap-panel-body", "bootstrap-panel-footer")]
    [HtmlTargetElement("bootstrap-panel-info")]
    public class PanelInfoTagHelper : PanelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "panel-info";
            return base.ProcessAsync(context, output);
        }
    }
}
