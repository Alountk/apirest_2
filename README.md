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

## Kubernetes

// Install Kubernetes
[Install KUBERNETES](https://kubernetes.io/docs/tasks/tools/install-kubectl-linux/)

// Install minikube
curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64
sudo install minikube-linux-amd64 /usr/local/bin/minikube
minikube start

// set secret password mongodb
kubectl create secret generic skeletonapi-secrets --from-literal=mongodb-password='${Password}'

// Go to Kubernetes folder in proyects
kubectl apply -f api.yaml

// get deployments, pods and  logs
kubectl get deployment
kubectl get pods
kubectl logs skeletonapi-deployment-848bf9fd95-sbpzh




[Guide](https://www.youtube.com/watch?v=ZXdFisA_hOY&ab_channel=freeCodeCamp.org)