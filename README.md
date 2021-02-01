### Build Docker image

```
docker build -t imdb:1.0 -f Dockerfile .
```

### Running Docker image
```
docker run -it -p 8080:80 imdb:1.0 
```

### Run Migrations
dotnet ef database update

### Login Administrador

https://localhost:5001/v1/account/login
{
            "NomeUsuario": "nick fury",
            "senha": "shield"
}

### Login Usuario 

https://localhost:5001/v1/account/login
{
            "NomeUsuario": "tony stark",
            "senha": "ironman"
}

Todos os testes foram realizados no postman, o swagger foi instalado, porém não foi configurado, até essa versão do código.

A função de filtros por diretor, nome, gênero e/ou atores também não foi implementada.
