using System.Collections.Generic;

namespace Domain.Core.Utils
{
    public static class MapperUtils
    {
        public static List<T> IfMapList<T>(this List<T> list, T adicionar)
        {
            if (list == null) list = new List<T>();
            if (adicionar != null) list.Add(adicionar);
            return list;
        }
    }
}
