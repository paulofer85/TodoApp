using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this TodoAppContext dbContext)
        {

            dbContext.Todoes.Add(new Todoes
            {
                TodoId = 1,
                Descripcion = "Test 1",
                Estatus = "PENDIENTE",
                Documento = "C:/prueba.jpg"
            });
            dbContext.Todoes.Add(new Todoes
            {
                TodoId = 2,
                Descripcion = "Test 2",
                Estatus = "PENDIENTE",
                Documento = "C:/prueba.jpg"
            });

            dbContext.SaveChanges();
        }
    }
}
