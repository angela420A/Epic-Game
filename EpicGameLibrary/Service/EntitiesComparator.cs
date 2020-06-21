using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicGameLibrary.Service
{
    //var UpdateList = New.Where(x => Old.Any(y => y.Location == x.Location && y.Url == x.Url));
    public static class EntitiesComparator
    {
        public static IEnumerable<T> GetUpdateEntities<T>(this IEnumerable<T> source1, IEnumerable<T> source2, Func<T,T,bool> function)
        {
            foreach(var data1 in source1)
            {
                foreach(var data2 in source2)
                {
                    if(function(data1, data2))
                    {
                        yield return data1;
                    }
                }
            }
        }
    }
}
