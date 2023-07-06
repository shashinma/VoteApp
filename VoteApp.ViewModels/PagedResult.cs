using System;
namespace VoteApp.ViewModels
{
	public class PagedResult<T> where T : class
	{
        public List<T> Data { get; set; }

        public int TotalItems { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}

