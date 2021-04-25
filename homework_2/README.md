
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
- docker build -t gr1feel/delicious-service:homework2_v1 -f ./Dockerfile .
- docker push gr1feel/delicious-service:homework2_v1


# БД
```
create table students
(
	id serial
		constraint students_pk
			primary key,
	first_name varchar(250),
	last_name varchar(250),
	age int
);

insert into students (first_name, last_name, age) values ('Михаил', 'Сидоров', 25);
insert into students (first_name, last_name, age) values ('Тарас', 'Бульба', 25);
```

#  установка приложения
-  Просмотр манифестов: helm install delicious ./delicious-chart --dry-run

- helm install delicious ./delicious-chart 
- или helm upgrade delicious ./delicious-chart 
