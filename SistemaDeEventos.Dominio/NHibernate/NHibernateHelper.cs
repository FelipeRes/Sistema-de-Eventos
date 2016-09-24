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

        //Configuração dessa classe como singleton
        private static ISessionFactory session;
        public static ISessionFactory sessionFactory {
            get {
                if(session == null) {
                    session = CreateSessionFactoryAndSchema();
                }
                return session;
            }
        }

        //cria uma sessão de conexão com o banco de dados
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

        //cria uma sessão de conexão com o banco de dados e cria o  proprio banco de dados com um esquema
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
        //Deleta o banco e cria um novo
        public static void BuildSchema(Configuration config) {
            if (File.Exists("Banco.db"))
                File.Delete("Banco.db");
            new SchemaExport(config).Create(false, true);
        }
        //Função que salva os dados no banco
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
