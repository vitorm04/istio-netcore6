# Istio

How to run?

1 - Install Istio 
```sh
https://istio.io/latest/docs/setup/getting-started/#download
```
2 - Install Istio Addons
```sh
kubectl apply istio\addons
```

3 - Start Kiali

```sh
kubectl port-forward svc/kiali -n istio-system 20001
```
Access: http://localhost:20001/kiali

4- Build docker application images

```sh
cd ./src/
docker build . -t consumer:latest
docker build -f ServerDockerfile . -t server:latest
```

5 - Apply Kubernetes deploy

path: kubernetes/

```sh
cd ./kubernetes/
kubectl apply -f .\deploy-consumer.yml
kubectl apply -f .\deploy-server.yml
```


![image](https://user-images.githubusercontent.com/24477296/172265277-aaae8e9c-93b1-43b0-ac62-c3ea447c9fc4.png)
