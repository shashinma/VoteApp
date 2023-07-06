using System;
namespace VoteApp.ViewModels
{
	public class ResultViewModel
	{
        public int StudentId { get; set; }

        public string ExamName { get; set; }

        public int TotalQuestion { get; set; }

        public int CorrectAnswer { get; set; }

        public int WrongAnswer { get; set; }
    }
}

