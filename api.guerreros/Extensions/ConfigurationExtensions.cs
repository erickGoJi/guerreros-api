using Microsoft.Extensions.DependencyInjection;
using api.guerreros.ActionFilter;
using biz.guerreros.Repository;
using biz.guerreros.Servicies;
using dal.guerreros.Repository;
using biz.guerreros.Repository.StudyCategory;
using biz.guerreros.Entities;
using biz.guerreros.Repository.AgeRange;
using dal.guerreros.Repository.StudyCategory;
using biz.guerreros.Repository.StudiesClinicians;
using dal.guerreros.Repository.StudiesClinicians;
using biz.guerreros.Repository.News;
using dal.guerreros.Repository.News;
using biz.guerreros.Repository.StudyType;
using dal.guerreros.Repository.StudyType;
using biz.guerreros.Repository.ClinicalStudy;
using dal.guerreros.Repository.ClinicalStudy;
using biz.guerreros.Repository.ResearchSite;
using dal.guerreros.Repository.ResearchSite;
using biz.guerreros.Repository.InclusionCriteria;
using dal.guerreros.Repository.InclusionCriteria;
using biz.guerreros.Repository.Contacts;
using dal.guerreros.Repository.Contacts;
using biz.guerreros.Repository.InformationGuerreros;
using dal.guerreros.Repository.InformationGuerreros;
using biz.guerreros.Repository.ContactGuerreros;
using dal.guerreros.Repository.ContactGuerreros;
using biz.guerreros.Repository.Notifications;
using dal.guerreros.Repository.Notifications;
using biz.guerreros.Repository.SupportPrograms;
using dal.guerreros.Repository.SupportPrograms;
using biz.guerreros.Repository.SupportProgramsDetail;
using dal.guerreros.Repository.SupportProgramsDetail;
using biz.guerreros.Repository.SponsorsGuerreros;
using dal.guerreros.Repository.SponsorsGuerreros;
using biz.guerreros.Repository.SponsorsGuerrerosDetail;
using dal.guerreros.Repository.SponsorsGuerrerosDetail;
using biz.guerreros.Repository.Users;
using dal.guerreros.Repository.Users;
using biz.guerreros.Repository.Specialty;
using dal.guerreros.Repository.Specialty;
using biz.guerreros.Repository.Postulation;
using dal.guerreros.Repository.Postulation;
using biz.guerreros.Repository.ShareClinicalStudies;
using dal.guerreros.Repository.AgeRange;
using dal.guerreros.Repository.ShareClinicalStudies;

namespace api.guerreros.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    //.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStudyCategory, StudyCategoryRepository>();
            services.AddTransient<IStudiesClinicians, StudiesCliniciansRepository>();
            services.AddTransient<INews, NewsRepository>();
            services.AddTransient<IStudyType, StudyTypeRepository>();
            services.AddTransient<IClinicalStudy, ClinicalStudyRepository>();
            services.AddTransient<IResearchSite, ResearchSiteRepository>();
            services.AddTransient<IinclusionCriteria, InclusionCriteriaRepository>();
            services.AddTransient<IContacts, ContactsRepository>();
            services.AddTransient<IinformationGuerreros, InformationGuerrerosRepository>();
            services.AddTransient<IcontactGuerreros, contactGuerrerosRepository>();
            services.AddTransient<INotifications, NotificationsRepository>();
            services.AddTransient<ISupportPrograms, SupportProgramsRepository>();
            services.AddTransient<ISupportProgramsDetail, SupportProgramsDetailRepository>();
            services.AddTransient<ISponsorsGuerreros, SponsorsGuerrerosRepository>();
            services.AddTransient<ISponsorsGuerrerosDetail, SponsorsGuerrerosDetailRepository>();
            services.AddTransient<IUsers, UsersRepository>();
            services.AddTransient<ISpecialty, SpecialtyRepository>();
            services.AddTransient<IPostulation, PostulationRepository>();
            services.AddTransient<IShareClinicalStudies, ShareClinicalStudiesRepository>();
            services.AddTransient<IAgeRangeRepository, AgeRangeRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }
    }
}
