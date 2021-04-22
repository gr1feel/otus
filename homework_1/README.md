
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
- kubectl apply -f service.yml
- kubectl apply -f ingress.yml
- или все: kubectl apply -f .

# temp
- docker run gr1feel/delicious-service:v2 -p 8000:8000
- kubectl delete daemonsets,replicasets,services,deployments,pods,rc --all


#результат Ingress
- kubectl describe ingress delicious-ingress
- curl -H'Host: arch.homework' http://192.168.64.3/otusapp/ivanov/
- curl -H'Host: arch.homework' http://192.168.64.3/otusapp/ivanov/version
curl -H'Host: arch.homework' http://192.168.64.3/otusapp/ivanov/health

#результат Service (NodePort)
- kubectl describe svc delicious-service
- minikube ssh
- curl http://10.103.73.107:8000/