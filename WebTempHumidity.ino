#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>   
#include <ESP8266mDNS.h>
#include "DHT.h"

#define DHTPIN 5
#define DHTTYPE DHT11

ESP8266WebServer svr(80);

DHT dht(DHTPIN, DHTTYPE);


const char* ssid = "SSID";
const char* password = "PASSWORD";
const char* dns_name = "meinESP";

const int PAUSE = 10000;
long lastActionTime = -1;

float Luftfeuchtigkeit;
float Temperatur;

IPAddress myIP;

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
  
  Serial.begin(115200);
  Serial.println("ESP gestartet");

  WiFi.begin(ssid, password);

  Serial.print("Verbindung wird hergestellt ...");
  while(WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
  }
  Serial.println();

  Serial.print("Verbunden! IP-Adresse: ");
  Serial.println(WiFi.localIP());

  if (MDNS.begin(dns_name))
  {
    Serial.println("DNS gestartet und erreichbar unter: ");
    Serial.println("http://" + String(dns_name) + ".local/");
  }

  svr.onNotFound([](){
    svr.send(404, "text/plain", "Link wurde nicht gefunden!");
  });

  svr.on("/", [](){
    svr.send(200, "text/plain", "ESP8266 2: \nPossible: /info: Information(Temperature & Humidity) \n          /ping: ping \n          /ip: IP-Address \n          /blink: LED geht für 800ms an");
  });
  svr.on("/ping", [](){
    svr.send(200, "text/plain", "PONG!");
  });
  //svr.on("/ip", [](){
  //  svr.send(200, "text/plain", "IP-Address: " + String(WiFi.localIP()) + "\nDNS-Address: http://" + dns_name + ".local/");
  //});
  svr.on("/blink", [](){
    digitalWrite(LED_BUILTIN, LOW);
    svr.send(200, "text/plain", "Wird gemacht... ");
    delay(800);
    digitalWrite(LED_BUILTIN, HIGH);
    delay(800);
    digitalWrite(LED_BUILTIN, LOW);
  });
  
  svr.begin();
  dht.begin();
  Serial.println("Webserver & DHT gestartet.");
  
}

void loop() {
  
  svr.handleClient();
  
  long currentMillis = millis();
  if(lastActionTime<(currentMillis-PAUSE)){
    lastActionTime = currentMillis;

    digitalWrite(LED_BUILTIN, LOW);
  
    Luftfeuchtigkeit = dht.readHumidity();
    Temperatur = dht.readTemperature();
  
    svr.on("/info", [](){
      svr.send(200, "text/plain", "Temperatur: " + String(Temperatur) + " | Luftfeuchtigkeit: " + String(Luftfeuchtigkeit));
    });
  }

  if(lastActionTime<(currentMillis-(0.06*PAUSE))) {
    digitalWrite(LED_BUILTIN, HIGH);
  }
  
}
