using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButlerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ButlerApp.Data
{
    public class ButlerAppContext : DbContext
    {
        public ButlerAppContext(DbContextOptions<ButlerAppContext> options) : base(options)
        {
        }

        public DbSet<Checkin> tbl_CheckinTimes { get; set; }
    }
}
