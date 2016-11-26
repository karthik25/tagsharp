using System.Collections.Generic;
using TagSharp.Abstract;

namespace TagSharp.Context
{
    public class MultipleItemsContext : IMultipleItemsContext
    {
        public string Header
        {
            get; set;
        }

        public List<string> Items
        {
            get; set;
        }
    }
}
