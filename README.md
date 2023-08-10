# K8s_Api_DB_CI_CD
Deployment of a rest api and a MYSQL DB to a Kubernetes cluster together with implementation of a CI-CD pipeline for automated tests
and automated deployment to staging and production.

![Overview of deployment](https://github.com/yahiaalioua/K8s_Api_DB_CI_CD/blob/main/k8s_Deployment/k8sDeployment1.drawio.png)

The above diagram represent how the solution has been architected.

We have Deployments running within a cluster, one for our product APi and one for our Mysql DB.
The Deployments create replicasets that make sure that one pod will always be up and running for each deployment.
As how you can see the Mysql Pod mounts a volume to persist DB data into a Persistant Volume.
This is done using a Persistant Volume Claim that request data storage from the Persistant Volume and provides it to the Mysql Pod.
A Configmap has been used to store variables used to access and run the Mysql DB together with Secrets that will store 
database credentials that will be accessed by the pod as enviromental variables.


In order to provide database access within the cluster to the product Api pod we create a Service of type ClusterIP.

Once done that our product-api can fetch data from the Mysql Database.
However the product Api is accessible only within the cluster, we need to make it accessible to external traffic.

To achive this we create a Load Balancer that will expose the product Api to the extrnal traffic. 


