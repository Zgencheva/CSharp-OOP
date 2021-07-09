using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePatternShallowAndDeepCopyExample
{
    interface IPrototype<T>
    {
        public T ShallowCopy();
        public T DeepCopy();
    }
}
