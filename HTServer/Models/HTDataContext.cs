﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTServer.Models
{
    public class HTDataContext : DbContext
    {
        public HTDataContext(DbContextOptions<HTDataContext> options)
            : base(options)
        {
        }
        //IMP: table name to be in lowercase as in the database the table name are in lowercase in RDS AWS
        public DbSet<UserMasterTB> usermastertb { get; set; }
        public DbSet<TokenManager> tokenmanager { get; set; }
        public DbSet<UserType> usertype { get; set; }
        public DbSet<EmpEntityType> empentitytype { get; set; }

         public DbSet<PrvProvider> prvprovider { get; set; }


        public DbSet<MbrFamilyHealthHx> mbrfamilyhealthhx { get; set; }
        public DbSet<MbrHealthHx> mbrhealthhx { get; set; }
        public DbSet<MbrHealthLevel> mbrhealthlevel { get; set; }
        public DbSet<MbrPremPMPM> mbrprempmpm { get; set; }
    }
}