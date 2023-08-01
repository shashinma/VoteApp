namespace VoteApp.DAL
{

	/*
	 * Класс Users содержит поля из таблицы users
	 * 
	 * Id - id в базе данных
	 * Name - имя пользователя на русском
	 * Username - юзернейм пользователя
	 * Password - пароль
	 * Role - роль пользователя
	 * Groups - группа к которой был отнесен пользователь (категория, отдел)
	 * 
	 */

	public class Users
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; } 

        public int Role { get; set; }

		public ICollection<Groups> Groups { get; set; } = new HashSet<Groups>();
	}
}