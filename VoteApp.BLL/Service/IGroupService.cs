using System;
using VoteApp.DAL;
using VoteApp.ViewModels;

namespace VoteApp.BLL.Service
{
	public interface IGroupService
	{
		PagedResult<GroupViewModel> GetAllGroups(int pageNumber, int pageSize);

		Task<GroupViewModel> AddGroupAsync(GroupViewModel groupVM);

		IEnumerable<Groups> GetAllGroups();

		GroupViewModel GetById(int groupId);
	}
}

