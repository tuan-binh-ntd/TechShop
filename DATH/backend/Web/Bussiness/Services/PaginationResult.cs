﻿namespace Bussiness.Services
{
    public class PaginationResult<TList>
    {
        public ICollection<TList>? Content { get; set; }
        public long TotalCount { get; set; }
        public int TotalPage { get; set; }
    }
}
