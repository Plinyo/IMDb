Linux:

### Running MSSQL Server image

```
docker run --name imdbsqlserver -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=a1b2c3d4e5." -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
export IMDBSQLSERVER=`docker inspect imdbsqlserver --format {{.NetworkSettings.IPAddress}}`
echo $IMDBSQLSERVER
```

### Build Docker IMDb image

```
cd IMDb
docker build -t imdb:1.0 -f Dockerfile .
```

### Running Docker IMDb image
```
docker run -it --add-host sqlserver.imdb.com:$IMDBSQLSERVER -p 5001:80 imdb:1.0 
```

### Run Migrations

Para carregar os dados no banco de dados utilize o comando abaixo.

```
dotnet ef database update
```
### Login Administrador
```
http://localhost:5001/v1/account/login
{
            "NomeUsuario": "nick fury",
            "senha": "shield"
}
```
### Login Usuario 
```
http://localhost:5001/v1/account/login
{
            "NomeUsuario": "tony stark",
            "senha": "ironman"
}
```

### Consultas do Postman

Todos os testes foram realizados no postman, o swagger foi instalado, porém não foi configurado, até essa versão do código.

Obs: Sempre utilizar schema HTTP quando for ler do docker
```
https://documenter.getpostman.com/view/2627280/TW6zG7Tn
```

### Swagger

```
http://localhost:5001/swagger/
```

### Pendências

- A função de filtros por diretor, nome, gênero e/ou atores também não foi implementada.
- Lembrete: criar tabelas para organizar atores, diretores e gêneros.
