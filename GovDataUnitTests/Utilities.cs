using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GovDataUnitTests
{
    /// <summary>
    /// I like the way it looks, but it doesn't seem to work.
    /// </summary>
    public static class Utilities
    {
        
        public static List<Type> GetTypeImplementing(Type T)
        {
            return Assembly.GetAssembly(T).GetTypes().Where(t => T.IsAssignableFrom(t) && !t.IsInterface).ToList();
        }
    }
}
