using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Sistema_de_Eventos.Map.Cupons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Eventos.NHibernateHelp {
    public class NHibernateHelper {

        private static ISessionFactory session;
        public static ISessionFactory sessionFactory {
            get {
                if(session == null) {
                    session = CreateSessionFactoryAndSchema();
                }
                return session;
            }
        }

        public static ISessionFactory CreateSessionFactory() {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile("Banco.db")
              )
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CupomMap>())
              //.ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }
        public static ISessionFactory CreateSessionFactoryAndSchema() {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile("Banco.db")
              )
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CupomMap>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        public static void BuildSchema(Configuration config) {
            if (File.Exists("Banco.db"))
                File.Delete("Banco.db");
            new SchemaExport(config).Create(false, true);
        }

        public static void SaveOrUpdate<T>(ref T i) {
            using (var session = sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    session.SaveOrUpdate(i);
                    transaction.Commit();
                }
            }
        }
    }
}
