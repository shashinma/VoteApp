
namespace VoteApp.DAL
{

    /*
     * Класс Students содержит поля из таблицы students
     * 
     * Id - id в базе данных
     * Name - имя пользователя на русском
     * Username - юзернейм пользователя
     * Password - пароль
     * Contact - номер телефона
     * CVFileName - 
     * PictureFileName - имя фотографии профиля
     * GroupsId - id группы к которой был отнесен пользователь
     * Groups - группы в которые был включен пользователь
     * 
     */

    public class Students
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Contact { get; set; }

        public string CVFileName { get; set; }

        public string PictureFileName { get; set; }

        public int? GroupsId { get; set; }
        
        public Groups Groups { get; set; }

        public ICollection<ExamResults> ExamResults { get; set; } = new HashSet<ExamResults>();
    }
}