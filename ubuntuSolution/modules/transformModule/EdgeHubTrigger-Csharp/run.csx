#r "Microsoft.Azure.Devices.Client"
#r "Newtonsoft.Json"

using System.IO;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

public static async Task Run(Message messageReceived, IAsyncCollector<Message> output, TraceWriter log)
{
    byte[] messageBytes = messageReceived.GetBytes();
    var messageString = System.Text.Encoding.UTF8.GetString(messageBytes);
    
    if (!string.IsNullOrEmpty(messageString))
    {
        log.Info(string.Format("Info: Received message: {0}", messageString));
        var messageBody = JsonConvert.DeserializeObject<MessageBody>(messageString);
        
        // Convert from var to atm
        messageBody.machine.pressure = messageBody.machine.pressure * 0.98692326671601;
        var outString = JsonConvert.SerializeObject(messageBody);
        byte[] outBytes = System.Text.Encoding.UTF8.GetBytes(outString);
        var outMessage = new Message(outBytes);
        foreach (KeyValuePair<string, string> prop in messageReceived.Properties)
        {
            log.Info(prop.Key);
            outMessage.Properties.Add(prop.Key, prop.Value);
        }
        await output.AddAsync(outMessage);
        log.Info(string.Format("Info: Sending message {0}", outString));
    }
}

 // Message schema
 class MessageBody
 {
     public Machine machine {get; set;}
     public Ambient ambient {get; set;}
     public string timeCreated {get; set;}
 }
 class Machine
 {
    public double temperature {get; set;}
    public double pressure {get; set;}         
 }
 class Ambient
 {
    public double temperature {get; set;}
    public int humidity {get; set;}         
 }