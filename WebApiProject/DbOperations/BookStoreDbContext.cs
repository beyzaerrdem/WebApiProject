﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using WebApiProject.Entities;

namespace WebApiProject.DbOperations
{
   public class BookStoreDbContext : DbContext 
    {

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }      
        public DbSet<Book> Books { get; set; }



    }

}
       
    
