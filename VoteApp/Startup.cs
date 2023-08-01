using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using VoteApp.BLL.Service;
using VoteApp.DAL.Data;
using VoteApp.DAL.UnitOfWork;

namespace VoteApp
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IQnAService, QnAService>();
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}

