# iot-edge-demo

**Work in progress**

# x86-based demo

* tempSensor module: simulated sensor from Microsoft repo
* transformModule: Azure Function module to convert bars to atm
* aggregateModule: Azure Stream Analytics to aggregate to 1-minute averages
* configModule: custom C# module to demonstrate configurations via Twin
* sql: running MS SQL
* BlobStorage: local blob storage endpoint with Azure synchronization

Message routing:
* tempSensor -> transformModule -> aggregateModule -> IoT Hub

