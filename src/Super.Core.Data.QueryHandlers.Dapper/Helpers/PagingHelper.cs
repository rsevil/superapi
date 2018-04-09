using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Super.Core.Data.QueryHandlers.Dapper.Helpers
{
    public static class PagingHelper
    {
        public static string GetSQL(IPageParams pageParams, ISortParams sortParams, params string[] defaultSort)
        {
            var sql = string.Empty;

            if (sortParams != null && sortParams.SortBy != null)
                sql = GetOrdering(sortParams.SortBy, sortParams.SortDir);
            else
                sql = GetOrdering(defaultSort, defaultSort.Select(e => SortDirs.Desc).ToArray());

            return $"{sql} OFFSET {pageParams.StartIndex} ROWS FETCH NEXT {pageParams.Length} ROWS ONLY";
        }

        private static string GetOrdering(string[] sortBy, SortDirs[] sortDir)
        {
            var sql = string.Empty;

            for (int i = 0; i < sortBy.Length; i++)
            {
                var col = sortBy[i];
                var dir = sortDir[i];
                var text = $"[{col}] {dir.ToString().ToLowerInvariant()}";

                if (string.IsNullOrEmpty(sql))
                    sql += $"ORDER BY {text}";
                else
                    sql += $", {text}";
            }

            return sql;
        }
    }
}
