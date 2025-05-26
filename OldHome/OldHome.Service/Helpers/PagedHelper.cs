using Microsoft.EntityFrameworkCore;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Service.Helpers
{
    public class PagedHelper<T>
    {
        public static IQueryable<T> GetPaged(IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public static async Task<(int, List<T>)> ToPagedResultAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await GetPaged(query, pageIndex, pageSize).ToListAsync();

            return (totalCount, items);
        }
    }
}
