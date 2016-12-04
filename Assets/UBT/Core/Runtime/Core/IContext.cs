using System;

namespace UBT.Core.Runtime.Core
{
    public interface IContext
    {
        object GetVariable(string name);

        bool SetVariable(string name, object value);

        bool ClearVariable(string name);

        void Clear();
    }
}
