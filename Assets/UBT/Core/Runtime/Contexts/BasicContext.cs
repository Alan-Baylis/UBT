using System.Collections.Generic;
using UBT.Core.Runtime.Core;

namespace UBT.Core.Runtime.Contexts
{
    public class BasicContext : IContext
    {
        private Dictionary<string, object> variablesByName;

        public BasicContext()
        {
            this.variablesByName = new Dictionary<string, object>();
        }

        public void Clear()
        {
            this.variablesByName.Clear();
        }

        public bool ClearVariable(string name)
        {
            return this.variablesByName.Remove(name);
        }

        public object GetVariable(string name)
        {
            object value;
            this.variablesByName.TryGetValue(name, out value);

            return value;
        }

        public bool SetVariable(string name, object value)
        {
            bool overwritten = this.variablesByName.ContainsKey(name);
            this.variablesByName[name] = value;

            return overwritten;
        }
    }
}
