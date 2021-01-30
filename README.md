### Build Docker image

```
docker build -t imdb:1.0 -f Dockerfile .
```

### Running Docker image
```
docker run -it -p 8080:80 imdb:1.0 
```