using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Abstract;
using TagSharp.Context;
using System.Collections.Generic;

namespace TagSharp.Bootstrap.Dropdowns
{
    [HtmlTargetElement("ts-bootstrap-dropdown")]
    public class DropdownTagHelper : TagHelper
    {
        private const string TypeAttributeName = "bs-type";
        private const string CssClassAttributeName = "bs-css-class";
        private const string IdAttributeName = "bs-dropdown-id";

        [HtmlAttributeName(TypeAttributeName)]
        public string Type { get; set; }

        [HtmlAttributeName(CssClassAttributeName)]
        public string CssClass { get; set; }

        [HtmlAttributeName(IdAttributeName)]
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = new MultipleItemsContext();
            context.Items.Add(typeof(DropdownTagHelper), contentContext);

            await output.GetChildContentAsync();

            var template = @"<div class=""{2}"" {3}>
                                {0}
                                <ul class=""dropdown-menu"">
                                 {1}
                                </ul>
                              </div>";
            var type = !string.IsNullOrEmpty(Type) ? Type : "dropdown";
            var cssClass = !string.IsNullOrEmpty(CssClass) ? CssClass : "btn-default";
            var idAttr = !string.IsNullOrEmpty(Id) ? string.Format(@"id=""{0}""", Id) : "";

            var items = string.Join("", contentContext.Items.ToArray());
            var finalContent = string.Format(template,
                                             contentContext.Header.Replace("[addOn]", cssClass), 
                                             items,
                                             type,
                                             idAttr);

            output.TagName = "";
            output.Content.AppendHtml(finalContent);
        }
    }

    [HtmlTargetElement("ts-bootstrap-button")]
    public class DropdownLauncherTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = (IMultipleItemsContext)context.Items[typeof(DropdownTagHelper)];
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();

            var template = @"<button class=""btn [addOn] dropdown-toggle"" type=""button"" 
                                     data-toggle=""dropdown"" aria-haspopup=""true"" 
                                     aria-expanded=""true"">
                               {0}
                               <span class=""caret""></span>
                             </button>";
            var launcher = string.Format(template, content);

            contentContext.Header = launcher;
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("ts-bootstrap-dropdown-list")]
    public class DropdownListTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = (IMultipleItemsContext)context.Items[typeof(DropdownTagHelper)];
            contentContext.Items = new List<string>();

            await output.GetChildContentAsync();

            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("ts-bootstrap-dropdown-item", ParentTag = "ts-bootstrap-dropdown-list")]
    public class DropdownItemTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = (IMultipleItemsContext)context.Items[typeof(DropdownTagHelper)];
            var awaiter = await output.GetChildContentAsync();
            var content = awaiter.GetContent();

            var template = @"<li>{0}</li>";
            contentContext.Items.Add(string.Format(template, content));
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("ts-bootstrap-dropdown-seperator", ParentTag = "ts-bootstrap-dropdown-list")]
    public class DropdownItemSeperatorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = (IMultipleItemsContext)context.Items[typeof(DropdownTagHelper)];
            var seperator = @"<li role=""separator"" class=""divider""></li>";

            contentContext.Items.Add(seperator);
            output.SuppressOutput();
        }
    }
}
