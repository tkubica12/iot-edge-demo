# iot-edge-demo

# ubuntuSolution

* tempSensor module: simulated sensor from Microsoft repo
* transformModule: Azure Function module to convert bars to atm
* aggregateModule: Azure Stream Analytics to aggregate to 1-minute averages
* configModule: custom C# module to demonstrate configurations via Twin

Routing:
* tempSensor -> transformModule -> aggregateModule -> IoT Hub
* configModule (separated)