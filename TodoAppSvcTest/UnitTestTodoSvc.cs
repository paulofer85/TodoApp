using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp;
using TodoApp.Models;
using Xunit;

namespace TodoApp
{
    public class UnitTestTodoSvc
    {
        [Fact]
        public async Task IsGetTodoStatusOk()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTodoesDbContext("TodoApp");
            var controller = new TodoesController(dbContext);

            // Act
            var response = await controller.GetTodoes(1);
            var value = (ObjectResult)response;

            //dbContext.Dispose();

            // Assert
            Assert.True(value.StatusCode.Value == 200 );
        }

        [Fact]
        public async Task IsCrearTodoOk()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTodoesDbContext("TodoApp");
            var controller = new TodoesController(dbContext);

            // Act
            TodoParameters todo = new TodoParameters();
            todo.descripcion = "HOLA IsCrearTodo";
            //Microsoft.AspNetCore.Http.IFormFile formFile;
            //formFile.CopyToAsync()
            todo.documento = null;
            todo.estatus = "PENDIENTE";

            var response = await controller.PostTodoes(todo);
            var value = (ObjectResult)response;

            //dbContext.Dispose();

            // Assert
            Assert.True(value.StatusCode.Value == 201 );
        }
    }
}
