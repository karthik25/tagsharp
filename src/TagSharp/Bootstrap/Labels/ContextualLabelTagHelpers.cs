using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagSharp.Bootstrap.Labels
{
    [HtmlTargetElement("ts-bootstrap-label-success")]
    public class LabelSuccessTagHelper : LabelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "label-success";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-label-primary")]
    public class LabelPrimaryTagHelper : LabelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "label-primary";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-label-info")]
    public class LabelInfoTagHelper : LabelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "label-info";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-label-warning")]
    public class LabelWarningTagHelper : LabelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "label-warning";
            return base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("ts-bootstrap-label-danger")]
    public class LabelDangerTagHelper : LabelTagHelper
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.CssClass = "label-danger";
            return base.ProcessAsync(context, output);
        }
    }
}
