using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using YG.Models;

namespace YG
{
    public class DataContext : FrameworkContext
    {
        public DbSet<Organ> Organs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<WorkKeyValue> TWorkKeyValues { get; set; }

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version=null)
             : base(cs, dbtype, version)
        {
        }

    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("server=127.0.0.1;userid=root;password=.a112358;database=yg;charset=UTF8;", DBTypeEnum.MySql);
        }
    }

}
