using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Tests;

namespace TodoApp.Models
{

    public static class DbContextMocker
    {
        public static TodoAppContext GetTodoesDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<TodoAppContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new TodoAppContext(options);

            // Add entities in memory
            DbContextExtensions.Seed(dbContext);

            return dbContext;
        }
    }
}
