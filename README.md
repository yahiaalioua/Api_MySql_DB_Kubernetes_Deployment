# K8s_Api_DB_CI_CD
Deployment of a rest api and a MYSQL DB to a Kubernetes cluster together with implementation of a CI-CD pipeline for automated tests
and automated deployment to staging and production.

![Overview of deployment](https://github.com/yahiaalioua/K8s_Api_DB_CI_CD/blob/feature/k8s_Deployment/k8sDeployment1.drawio.png)

The above diagram represent how the solution has been architected.

We have 2 pods running within a cluster, one for our product APi and one for our Mysql DB.
As how you can see the Mysql Pod mounts a Volume to persist DB data of type Persistent Volueme a
