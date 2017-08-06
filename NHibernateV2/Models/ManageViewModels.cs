using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Data;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using NHibernateV2.Mappings;

namespace NHibernateV2.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
    public class NHibertnateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mapping\Employee.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
    public class AppContext
    {
        public static Configuration NHConfiguration { get; set; }
        public static ISessionFactory SessionFactory { get; set; }
        public static void AppConfigure()
        {
            #region NHibernate configuration

            NHConfiguration = ConfigureNHibernate();
            SessionFactory = NHConfiguration.BuildSessionFactory();
            #endregion
        }
        public AppContext() {
            AppConfigure();
        }
        private static Configuration ConfigureNHibernate()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("BuildIt");

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MySQL5Dialect>();
                db.Driver<MySqlDataDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionStringName = "NHV2";
                db.Timeout = 15;

                // enabled for testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });

            var mapping = GetMappings();
            configure.AddDeserializedMapping(mapping, "NHibernateV2");
            SchemaMetadataUpdater.QuoteTableAndColumns(configure);

            return configure;
        }

        private static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(Assembly.GetAssembly(typeof(MenuMap)).GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }
    }
}