using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IMDb.Models
{
    [SwaggerSchemaFilter(typeof(FilmesSchemaFilter))]
    public class Filmes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]      
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeFilme { get; set; }
        public string Genero { get; set; }
        public string Duracao { get; set; }
        public string Atores { get; set; }
        public string Diretores { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser 0 na inserção")]
        public decimal Avaliacao { get; set; }    
    }
     public class FilmesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                [ "Id" ] = new OpenApiInteger(1),
                ["NomeFilme"] = new OpenApiString("Vingadores Ultimato"),
                ["Genero"] = new OpenApiString("Acao"),
                ["Duracao"] = new OpenApiString("3h 02m"),
                ["Atores"] = new OpenApiString("Chris Evans, Robert Downey Jr., Chris Hemsworth, Mark Ruffalo, Scarlett Johansson"),
                ["Diretores"] = new OpenApiString("Joe Russo, Anthony Russo"),
                ["Avaliacao"] = new OpenApiFloat(4),
            };
        }
    }
}