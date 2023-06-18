# Connect and Consume Services - Azure Event Hubs


## Azure Event Hub

### Lab – Creating a Hub

- create en event hub namespace
<img src="/pictures/event_hub.png" title="event hub"  width="900">

- create en event hub
<img src="/pictures/event_hub2.png" title="event hub"  width="900">

### Sending and receiving events

- create a console app and install packages
```
Azure.Messaging.EventHubs
```

- add a *Send Access Policy* for your event hub
<img src="/pictures/event_hub3.png" title="event hub"  width="900">

- from there, grab the connection string to use in the app
<img src="/pictures/event_hub4.png" title="event hub"  width="900">
