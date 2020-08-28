# readme

## MSA

- microservice architecture
    1. language-independent, feature-independent
    1. composable
    1. testable
    1. scalable
    1. network-driven
- orchestration management
    1. manageability
    1. failure mitigation -> failover, backup, replication (geo-location)
    1. service discovery
    1. network topology
    1. rollout strategy -> update, upgrade, rollback
- kubernetes
    1. cluster -> root-level environment
    1. node -> abstract representation of virtual/physical server
    1. pod -> logical unit of compute composed of 1 or more containers, including network, storage, secret, configuration
    1. container -> isolated running instance of a package/library image
    1. deployment -> set of configuration instructions to run 1 or more pods
    1. service -> network overlay to access 1 or more containers across any node within a pod
- azure kubernetes service (AKS)
    1. server -> virtual/physical compute unit with configuration for memory, cpu, hard drive, network access
    1. network interface controller (nic) -> network device to manage route table, ip addressing, virtual network, security group
    1. load balancer -> network device to route traffic to available resources in a round-robin or weighted-average process
    1. azure resource manager template (ARM template) -> set of instructions to provision a cloud infrastructure (server, network, storage) driven by code (IaC = infrastructure as code)

## inquiry

1. can you explain the benefits of MSA?
1. can you explain the drawbacks of MSA?
1. how did you implement MSA in your project?
1. what is orchestration management?
1. what are the differences between Docker Swarm and Kubernestes?
1. why did you use Kubernetes in yourr project?
1. what are the differences between Monolith and MSA applications?
1. what are the differences between a Server and a Node?
1. what are the differences between AKS and K8s?
1. do you know of any other services similar to AKS?

## AKS with CLI

```sh
az login # follow the onscreen instructions to login

az account show # should list your current subscription

az account set # should ONLY use if changing the current subscription

# for AKS
ssh-keygen -t rsa -b 4096 -C <email address> # generate access key for servers

az group create --name <group name> --location <desired location name> # to create a resource group

az ad sp create-for-rbac # create a service user for access to external resources, save json document

az extension add --name aks-preview # fix an issue with az cli

az aks create --name <cluster name> --resource-group <created group name> --location <desired location name> --ssh-key-value <created public key> --node-vm-size <Standard_B2s or Standard_B2ms> --node-count 3 --service-principal <created appId rbac> --client-secret <created password rbac> # create K8s cluster with AKS service

az aks get-credentials --name <created cluster name> --resource-group <created group> --admin # connect to K8s cluster

kubectl <commands> # use control plane to interact with K8s cluster

# manual deploy
kubectl apply --filename .kubernetes/angular
kubectl apply --filename .kubernetes/aspnet_api
kubectl apply --filename .kubernetes/aspnet_mvc
```
