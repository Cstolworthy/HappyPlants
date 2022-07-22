
#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <Settings.h>

WiFiClient espClient;
PubSubClient client(espClient);

void setup() {
  Serial.begin(115200);
  delay(1000);
  if(CONFIGURATION.loadConfig()){
    Serial.println("Config loaded:");
    Serial.println(CONFIGURATION.version);    
  }else{
    Serial.println("No configuration saved!");
    CONFIGURATION.saveConfig();   
  }
    WiFi.begin(CONFIGURATION.ssid, CONFIGURATION.password);
    client.setServer(CONFIGURATION.mqtt_broker, CONFIGURATION.mqtt_port);
    client.setCallback(callback);    
    client.publish(CONFIGURATION.topic, "hello emqx");
    client.subscribe(CONFIGURATION.topic);

     while (WiFi.status() != WL_CONNECTED) {
      delay(500);
      Serial.println("Connecting to WiFi..");
  }
  Serial.println("Connected to the WiFi network");
  //connecting to a mqtt broker
  
  while (!client.connected()) {
      String client_id = "esp8266-client-";
      client_id += String(WiFi.macAddress());
      Serial.printf("The client %s connects to the public mqtt broker\n", client_id.c_str());
      if (client.connect(client_id.c_str(), CONFIGURATION.mqtt_username, CONFIGURATION.mqtt_password)) {
          Serial.println("Public emqx mqtt broker connected");
      } else {
          Serial.print("failed with state ");
          Serial.print(client.state());
          delay(2000);
      }
  }
}

void callback(char *topic, byte *payload, unsigned int length) {
  Serial.print("Message arrived in topic: ");
  Serial.println(topic);
  Serial.print("Message:");
  for (int i = 0; i < length; i++) {
      Serial.print((char) payload[i]);
  }
  Serial.println();
  Serial.println("-----------------------");
}

void loop() {
  client.loop();
}
