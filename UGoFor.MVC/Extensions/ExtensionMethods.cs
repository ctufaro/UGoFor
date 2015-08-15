using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        {
            while (!reader.IsClosed && reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}
