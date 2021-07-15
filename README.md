# API Rest DOTNET

## Secrets

dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password ###PASSWORD###

## Docker

// Create a img
docker build -t skeletonapi:v${number version} .
// Create a network
docker network create ${network name}
//build mongodb img
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=${Password} --network=${network name} mongo
//show image in desktop
docker images
//mount img dotnet apirest
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=${Password} --network=${network name} skeletonapi:v1
//push image to docker hub
docker push alountk/skeletonapi:v1
