# Dapr Service Invocation Sample

## Description
This project demonstrates how to use Dapr's service invocation capabilities for inter-service communication. Dapr simplifies service-to-service calls using HTTP or gRPC, providing a consistent and platform-agnostic way to invoke services across different programming languages.

service-to-service calls. In this project, we have created two separate service projects: order-processor and service-invocation.

* order-processor: This service is used to expose APIs through the Dapr sidecar port.
* service-invocation: This service will invoke the APIs of the order-processor service using Dapr’s service invocation through its sidecar port.


## Prerequisites:
1. Install the latest .NET SDK.
2. Install and configure Dapr CLI.
	* Install the most recent Dapr CLI on Windows in $Env:SystemDrive\dapr, and update the User PATH environment variable to include this directory.
		```bash
		powershell -Command "iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex"
		```
	* Or using winget:
		```bash
		winget install Dapr.CLI
		```
3. Install the Dapr client library for .NET:
   
   
		dotnet add package Dapr.AspNetCore
   
5. Register the Dapr client in your Program.cs:
   
   
		builder.Services.AddDaprClient();
   
## Installation and Setup
* Now Run Both Services with Docker Compose
	To run both services using Docker Compose, simply use the following commands:
  ```bash	
	docker-compose up
	```
	To stop the services, run:
  ```bash	
	docker-compose down
	```
  
* Assigning Dapr Sidecar Port to the Order-Processor Service
	To assign a Dapr sidecar port to the order-processor service, open a new terminal window and run the following command:
  ```bash	
	dapr run --app-port 7001 --app-id order-processor --app-protocol http --dapr-http-port 3501 -- dotnet run
	```
  
	This command runs the order-processor service alongside the Dapr sidecar.
	* 7001: The port where your order-service is deployed.
	* 3501: The port for the Dapr sidecar handling the order-processor service.
