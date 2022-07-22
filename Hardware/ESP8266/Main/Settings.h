
typedef struct
{
    char version[6]; // detect if setting actually are written
    char *ssid; 
    char *password;
    char *mqtt_broker;
    char *topic;
    char *mqtt_username;
    char *mqtt_password;
    int mqtt_port;
    int loadConfig();
    void saveConfig();
} config;

#define CONFIG_VERSION "VER01"
#define CONFIG_START 32

config CONFIGURATION = {
    CONFIG_VERSION,
    "Pretty Fly for a Wifi",
    "WhatIsWifi",
    "192.168.1.38",
    "esp8266/test",
    "emqx",
    "public",
    1883
};

