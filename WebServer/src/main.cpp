/**
 * @author hyie (github.com/hyiev1)
 * @date 09/12/2020
 * 
 * used libraries: 
 *    https://github.com/bblanchon/ArduinoJson (arduinojson.org)
 *    https://github.com/adafruit/DHT-sensor-library (adafruit.com)
**/
#include <Arduino.h>

#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

#include <DHT.h>
#include <ArduinoJson.h>

#define DHTPIN 0
#define DHTTYPE DHT11

ESP8266WebServer server(80);
DHT dht(DHTPIN, DHTTYPE);

String ssid = "<ssid>";
String pass = "<password>";

IPAddress myIP;


float temperature = 0;
float humidity = 0;
bool update = true;

void handleInfo() {
  if(update) {
    temperature = dht.readTemperature(false); // true = Fahrenheit | false = Celcius
    humidity = dht.readHumidity();
    update = false;
    Serial.println("Updated data: Temperature: " + String(temperature) + " | Humidity: " + String(humidity));
  }

  DynamicJsonDocument doc(512);
  doc["temperature"] = temperature;
  doc["humidity"] = humidity;

  String buffer;
  serializeJson(doc, buffer);
  server.send(200, "application/json", buffer);

  Serial.println("Sent data: Temperature: " + String(temperature) + " | Humidity: " + String(humidity));
}
void handleMain() {
  server.send(200, "text/html", "Hello " + server.client().remoteIP().toString() + "!");
}
void handleNotFound() {
  server.send(404, "text/html", "Requested site not found!");
}

void setup() 
{
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.println("Starting ESP");

  // Connecting to WiFi
  WiFi.begin(ssid, pass);
  Serial.println("Connecting to " + ssid + "!");
  bool blink = true;
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    digitalWrite(LED_BUILTIN, blink);
    blink = !blink;
  }
  Serial.println("\nSuccessfully connected!");
  Serial.println("Local IP: " + WiFi.localIP().toString());

  // Starting Server
  server.onNotFound(handleNotFound);
  server.on("/", HTTP_GET, handleMain);
  server.on("/info", HTTP_GET, handleInfo);

  server.begin();
  dht.begin();

  Serial.println("Started Server & DHT.");
  digitalWrite(LED_BUILTIN, HIGH);
}


const int PAUSE = 10000; // 10s
long lastActionTime = -1;

void loop() 
{
  server.handleClient();

  if(update) {
    lastActionTime = millis();
  } 
  else if (lastActionTime<(millis()-PAUSE)) {
    lastActionTime = millis();
    Serial.println("10s passed.");
    update = true;
  }
}