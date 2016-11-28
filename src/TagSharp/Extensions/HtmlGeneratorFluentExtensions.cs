namespace TagSharp.Extensions
{
    public static class HtmlGeneratorFluentExtensions
    {
        public static string GetSectionContent(this string sectionContent, string sectionClass)
        {
            if (string.IsNullOrEmpty(sectionContent))
                return string.Empty;
            return string.Format(sectionTemplate, sectionClass, sectionContent);
        }

        private const string sectionTemplate = @"<div class=""{0}"">
                                                    {1}
                                                 </div>";
    }
}
