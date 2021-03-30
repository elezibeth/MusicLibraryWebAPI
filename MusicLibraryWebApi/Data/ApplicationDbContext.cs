using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicLibraryWebApi;
using MusicLibraryWebApi.Models;
using MusicLibraryWebApi.Data;

namespace MusicLibraryWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
       
        public DbSet<Song> Songs { get; set; }

    }
}
