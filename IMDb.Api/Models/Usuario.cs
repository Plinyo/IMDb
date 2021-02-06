using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IMDb.Models
{
    [SwaggerSchemaFilter(typeof(UsuarioSchemaFilter))]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório, ao inserir um novo, valor deve ser 'true'")]
        public bool Ativo { get; set; }
    }
    public class UsuarioSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                [ "Id" ] = new OpenApiInteger(1),
                ["NomeUsuario"] = new OpenApiString("nick fury"),
                ["Senha"] = new OpenApiString("shield"),
                ["DataNascimento"] = new OpenApiDateTime(DateTime.Now.AddYears(-40)),
                ["Sexo"] = new OpenApiString("M"),
                ["Ativo"] = new OpenApiBoolean(true)
            };
        }
    }
}