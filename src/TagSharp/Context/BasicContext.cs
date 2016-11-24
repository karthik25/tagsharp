using TagSharp.Abstract;

namespace TagSharp.Context
{
    public class BasicContext : IBasicContext
    {
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Body { get; set; }
    }
}
