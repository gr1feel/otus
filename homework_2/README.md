# Инструкция для проверки ДЗ.
- kubectl config set-context --current --namespace=myapp
- Установить PostgresSql
	- helm install pg bitnami/postgresql -f postgers/pg_values.yaml
- Варинты развертывания сервиса (на выбор)
	- kubectl apply -f .
	- helm install delicious ./delicious-chart
- Тестирование сервиса (на выбор)
	- newman run UserAPI.postman_collection.json
	- или через Swagger http://arch.homework/swagger/index.html
- Удаление (зависит от установки)
	- helm uninstall delicious
	- kubectl delete -f .

# уcтановка и настройка helm

- brew install helm
- helm repo add bitnami https://charts.bitnami.com/bitnami
- helm repo update
- helm search repo bitnami 

# Устанавливаем pg
- helm install pg bitnami/postgresql -f pg_values.yaml

# Настройка LoadBalancer
- minikube addons enable metallb
- minikube addons configure metallb
    - Enter Load Balancer Start IP: 192.168.64.150
    - Enter Load Balancer End IP: 192.168.64.190

# сборка контейнера и развертывание 
- docker build -t gr1feel/delicious-service:homework_2_v7 -f ./Dockerfile .
- docker push gr1feel/delicious-service:homework_2_v7


#  установка приложения
-  Просмотр манифестов: helm install delicious ./delicious-chart --dry-run

- helm install delicious ./delicious-chart 
- или helm upgrade delicious ./delicious-chart 

- kubectl delete daemonsets,replicasets,services,deployments,ingress,pods,rc,statefulset --all
