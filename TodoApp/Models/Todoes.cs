using Microsoft.AspNetCore.Http;

namespace TodoApp.Models
{
    public partial class Todoes
    {
        public int TodoId { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
        public string Documento { get; set; }


    }
}
