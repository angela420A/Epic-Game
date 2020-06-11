using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicGameLibrary.Service
{
    public static class OrderService
    {
        /// <summary>
        /// 以屬性名稱進行排序
        /// </summary>
        /// <typeparam name="T">表格、ViewModel、或Model類型</typeparam>
        /// <param name="set">要被排序的集合</param>
        /// <param name="key">按照哪個屬性作排序</param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> OrderByPropertyName<T>(this IEnumerable<T> set, string key)
        {
            return OrderByPropertyName(set, key, true);
        }

        /// <summary>
        /// 以屬性名稱進行排序
        /// </summary>
        /// <typeparam name="T">表格、ViewModel、或Model類型</typeparam>
        /// <param name="set">要被排序的集合</param>
        /// <param name="key">按照哪個屬性作排序</param>
        /// <param name="asc">true表示正序，false表示反序</param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> OrderByPropertyName<T>(this IEnumerable<T> set, string key, bool asc)
        {
            if(asc) return set.OrderBy(x => x.GetType().GetProperty(key).GetValue(x));
            else return set.OrderByDescending(x => x.GetType().GetProperty(key).GetValue(x));
        }
    }
}
