using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Cfg;
using NHibernate.Context;
using MySql;
using NHibernate;

namespace TrainerPalBuddyFriend3
{
    static public class SessionFactory
    {
        static public ISessionFactory _SF = null;

        static public ISessionFactory GetSF()
        {
            try
            {
                if (_SF == null)
                {
                    var nhCnfig = new NHibernate.Cfg.Configuration();

                    nhCnfig.DataBaseIntegration(delegate (NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties abc)
                    {
                        abc.ConnectionString = "Database=rides;Data Source=localhost;Port=3306;User Id=root;Password=<K%F!1?qsYt0";
                        abc.Dialect<NHibernate.Dialect.MySQL55Dialect>();
                        abc.Driver<NHibernate.Driver.MySqlDataDriver>();
                        abc.LogSqlInConsole = true;
                        abc.Timeout = 60;
                    });

                    nhCnfig.AddAssembly(typeof(Segments).Assembly);
                    //nhCnfig.AddAssembly(typeof(Tips).Assembly);
                    //nhCnfig.AddAssembly(typeof(Types).Assembly);
                    //nhCnfig.AddAssembly(typeof(Wkseg).Assembly);
                    //nhCnfig.AddAssembly(typeof(Workouts).Assembly);
                    nhCnfig.CurrentSessionContext<WebSessionContext>();

                    _SF = nhCnfig.BuildSessionFactory();
                }

            }

            catch (Exception ex)
            { }

            return _SF;

        }
    }
}