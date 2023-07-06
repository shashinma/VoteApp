using System;
namespace VoteApp.ViewModels
{
	public class AttendExamViewModel
	{
		public int StudentId { get; set; }

		public string ExamName { get; set; }

		public List<QnAsViewModel> QnAs { get; set; }

		public string Message { get; set; }
	}
}

