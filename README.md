# Connect and Consume Services - Azure Event Hubs


## Azure Event Hub

### Lab – Creating a Hub

- create en event hub namespace
<img src="/pictures/event_hub.png" title="event hub"  width="900">

- create en event hub
<img src="/pictures/event_hub2.png" title="event hub"  width="900">

### Sending and receiving events

- create two console apps for send and receive and install packages
```
Azure.Messaging.EventHubs
```

- add a *Send Access Policy* for your event hub
<img src="/pictures/event_hub3.png" title="event hub"  width="900">

- from there, grab the connection string to use in the send app
<img src="/pictures/event_hub4.png" title="event hub"  width="900">

- do the same for the receive app

- for the receive app, use the default group
<img src="/pictures/event_hub5.png" title="event hub"  width="900">

- run the apps and see the result
<img src="/pictures/event_hub6.png" title="event hub"  width="900">


## Partitions

### Azure Functions

- choose event hub trigger
<img src="/pictures/az_function.png" title="azure functions"  width="900">

- add a new access policy and grab the connection string to use in the azure function
<img src="/pictures/az_function2.png" title="azure functions"  width="900">

### Sending to multiple partitions

- run both send and receive and see that all batches have been sent. Note that the data is evenly distributed accross partition 1 and 2
<img src="/pictures/multiple.png" title="multiple partitions"  width="900">

### Reading from the first Partitions

- run both send and receive and see that all batches have been sent. Note that the data is only taken from partition 1
<img src="/pictures/multiple2.png" title="multiple partitions"  width="900">

### Event Processor class

It will keep track of the messages that have already been read.

- create console app for process and install packages
```
Azure.Messaging.EventHubs.Processor
```

- use the listen access policy for the hub
<img src="/pictures/processor.png" title="event processor"  width="900">

### Capture File Format

- add a new capture
<img src="/pictures/capture.png" title="capture file format"  width="900">
