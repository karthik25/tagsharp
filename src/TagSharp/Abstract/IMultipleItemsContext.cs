using System.Collections.Generic;

namespace TagSharp.Abstract
{
    public interface IMultipleItemsContext
    {
        string Header { get; set; }
        List<string> Items { get; set; }
        List<string> Contents { get; set; }
    }
}
