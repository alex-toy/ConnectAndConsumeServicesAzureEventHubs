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