namespace TagSharp.Abstract
{
    public interface IBasicContext
    {
        string Header { get; set; }
        string Footer { get; set; }
        string Body { get; set; }
    }
}
