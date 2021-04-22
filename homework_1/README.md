
- minikube start --cpus=2 --memory=2g --vm-driver=hyperkit

# настройка
- kubectl create namespace myapp
- kubectl config set-context --current --namespace=myapp

# полезно
- brew install watch
- watch kubectl get all

# настройка docker 
- minikube docker-env
- скопировать export и выполнить в консоли

# инфо
- kubectl describe pod delicious-deployment
- kubectl describe svc delicious-service
- kubectl describe ingress delicious-ingress

# сборка контейнера
- docker build -t gr1feel/delicious-service:v4 -f ./Dockerfile .
- docker push gr1feel/delicious-service:v4

- kubectl apply -f deployment.yml
- kubectl apply -f ingress.yml



- docker run gr1feel/delicious-service:v2 -p 8000:8000
- kubectl delete daemonsets,replicasets,services,deployments,pods,rc --all