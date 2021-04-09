# NetCoreApi-Kafka

## Description

The purpose of the project is using the basic features of Apache Kafka.<br><br>
For that I created two Microservices (Web API) projects using .Net Core 3.1:

1) Producer 
<br><br>
Responsible for sending messages (ProducerController) to the local Kafka Bootstrapper Server.

2) Producer 
<br><br>
Responsible for retrieving messages (ConsumerController) from the local Kafka Bootstrapper Server and apply the logic needed.

## Technlogies / Dependencies

[Docker](https://docs.docker.com/get-docker/)<br>
[.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)<br>
[Apache Kafka using Confluent Platform (Docker)](https://docs.confluent.io/platform/current/quickstart/ce-docker-quickstart.html?utm_medium=sem&utm_source=google&utm_campaign=ch.sem_br.nonbrand_tp.prs_tgt.kafka_mt.mbm_rgn.latam_lng.eng_dv.all&utm_term=%2Bkafka%20%2Bdocker&creative=&device=c&placement=&gclid=CjwKCAjw07qDBhBxEiwA6pPbHk1CPBkrdwo2D5gvPUuLSRzkLh7rBquBkJ6CuL0SU1mIdn6pReH6JxoCmVgQAvD_BwE)

## Running the app

Following the Apacha Kafka Docker link, you will be able to have the container running inside Docker.
If everything is working properly, you will be able to access the Apache Kafka Control Center: http://localhost:9021. <br><br>
The only thing you need for calling the HTTP requests of the application is the Apache Kafka Topic, so create one inside the Control Center. 
This topic will be passed as a parameter in the HTTP requests of the app.
<br><br>
For each project, you can open your terminal/cmd and type: `dotnet run`
<br><br>
The <b>Producer Microservice</b> will be running in the port :4000 => http://localhost:4000/swagger
<br>
And the <b>Consumer Microservice</b> will be running in the port :5000 => http://localhost:5000/swagger
<br>
<br>
You can use the Swagger UI for performing the testings sending and receiving messages.

## Next Steps

Change the Consumer Microservice for working like a shcedule job, probably using [Quartz](http://www.quartz-scheduler.org/).


