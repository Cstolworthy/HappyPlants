#include <ESP8266WiFi.h>
#include <PubSubClient.h>


WiFiClient espClient;
PubSubClient client(espClient);

char* ssid[] = { "Pretty Fly for a Wifi" };
char* password[] = { "WhatIsWifi" };
char* mqtt_broker[] = { "192.168.1.38" };
char* topic[] = { "esp8266/test" };
char* mqtt_username[] = { "emqx" };
char* mqtt_password[] = { "public" };
int mqtt_port = 1883;


void setup() {
	Serial.begin(115200);
	delay(100);

	WiFi.begin(*ssid, *password);
	client.setServer(*mqtt_broker, mqtt_port);


	Serial.print("Attempting to connect to WiFi.");
	while (WiFi.status() != WL_CONNECTED) {
		delay(500);
		Serial.print(".");
		Serial.flush();
	}
	Serial.println();
	Serial.println("Connected to the WiFi network");
	//connecting to a mqtt broker
	while (!client.connected()) {

		char macAddress[18];
		WiFi.macAddress().toCharArray(macAddress, sizeof(macAddress));
		Serial.println(macAddress);
		char clientId[33];
		sprintf(clientId, "esp8266-client-%s", macAddress);
		Serial.printf("The client %s is attempting to connect to the mqtt broker\n", clientId);

		if (client.connect(*mqtt_broker, *mqtt_username, *mqtt_password)) {
			Serial.println("Public emqx mqtt broker connected");
			client.setCallback(callback);
			client.subscribe(*topic);
		}
		else {
			Serial.print("failed with state ");
			Serial.print(client.state());
			delay(2000);
		}
	}
}
void callback(char* topic, byte* payload, unsigned int length) {
	Serial.print("Message arrived in topic: ");
	Serial.println(topic);
	Serial.print("Message:");
	char message[100];
	for (int i = 0; i < length; i++) {
		message[i] = (char)payload[i];
	}
	Serial.println(message);
	Serial.println("-----------------------");
}


void loop() {
	Serial.println("Looping");
	if (Serial.available())
		delay(100);
	//String serialOutput = Serial.readStringUntil('\0');
	String vst = Serial.readStringUntil('\n');
	const char* buf = vst.c_str();
	
	client.publish(*topic, buf);
	client.loop();
	delay(1000);
}