using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBUtility
{
    public class DbContext<T> where T : class, new()
    {
        public SqlSugarClient Db;

        public DbContext() {
            Db = new SqlSugarClient(new ConnectionConfig() {
                ConnectionString = "Server=.;Database=test;Trusted_Connection=True;",//连接符字串
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true //不设成true要手动close
            });
            Db.Aop.OnLogExecuting = (sql, pars) => {
                Console.WriteLine(sql);//输出sql
                Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
            };
        }

        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }

        public virtual List<T> GetList() {
            return CurrentDb.GetList();
        }
    }
}
