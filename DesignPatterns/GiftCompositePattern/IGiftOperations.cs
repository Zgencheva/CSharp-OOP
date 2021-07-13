using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCompositePattern
{
    interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remoce(GiftBase gift);
    }
}
