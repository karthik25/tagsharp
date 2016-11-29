using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagSharp.Extensions
{
    public static class TagHelperFluentExtensions
    {
        public static TU GetItem<T, TU>(this TagHelperContext context)
            where T : TagHelper
            where TU : class
        {
            var instance = (TU)context.Items[typeof(T)];
            return instance;
        }
    }
}
