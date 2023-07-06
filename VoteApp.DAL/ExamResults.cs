
namespace VoteApp.DAL
{
	public class ExamResults
	{
		public int Id { get; set; }

		public int StudentId { get; set; }

		public Students Students { get; set; }

		public int? ExamsId { get; set; }

		public Exams Exams { get; set; }

		public int QnAsId { get; set; }

		public QnAs QnAs { get; set; }

		public int Answer { get; set; }
    }
}

