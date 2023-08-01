
namespace VoteApp.DAL
{
   /*
	* Класс QnAs содержит поля из таблицы qnas
	* 
	* Id - id в базе данных
	* ExamId - id экзамена к которому принадлежит данный вопрос
	* Exams - 
	* Question - Вопрос
	* Answer - ответ пользователя
	* Option1 - опция
	* Option1 - опция
	* Option1 - опция
	* Option1 - опция
	* ExamResult - результаты экзамена
	* 
	*/

    public class QnAs
	{
		public int Id { get; set; }

		public int ExamsId { get; set; }

		public Exams Exams { get; set; }

		public string Question { get; set; }

		public int Answer { get; set; }

		public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

		public ICollection<ExamResults> ExamResults { get; set; } = new HashSet<ExamResults>();
    }
}