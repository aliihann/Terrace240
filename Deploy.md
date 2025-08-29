# How to deploy

## Ensure you have docker running
```
docker ps -a
```

## Run building
```
docker build -t terrace240:1 .
```

## Run in verbose mode
```
docker run -p 5000:8080 -e PORT=8080 terrace240:1
```