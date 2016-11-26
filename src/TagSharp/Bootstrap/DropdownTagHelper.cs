using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagSharp.Abstract;
using TagSharp.Context;
using System.Collections.Generic;

namespace TagSharp.Bootstrap
{
    [HtmlTargetElement("ts-bootstrap-dropdown")]
    public class DropdownTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contentContext = new MultipleItemsContext();
            context.Items.Add(typeof(DropdownTagHelper), contentContext);

            await output.GetChildContentAsync();

            var template = @"<div class=""dropdown"">
                                {0}
                                <ul class=""dropdown-menu"">
                                 {1}
                                </ul>
                              </div>";
            var finalContent = string.Format(template, contentContext.Header, string.Join("", contentContext.Items.ToArray()));
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

            var template = @"<button class=""btn btn-default dropdown-toggle"" type=""button"" 
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
