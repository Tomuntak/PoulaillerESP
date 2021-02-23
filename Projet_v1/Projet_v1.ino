
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <WifiClient.h>
#include <Stepper.h>

#define WIFI_SSID       "linksysTablettes"
#define WIFI_PASSWORD   "zx2axdt8fmkve3nj"
WiFiClient client;

bool LastState = 0;

void setup() {
  Serial.begin(9600);
  connect_wifi();
}



void loop() {
  
  BTN_open_close();
  connect_wifi();

}



void BTN_open_close() {
  if (digitalRead(0) && digitalRead(0) != LastState) { //Fermé
    LastState = !LastState;
    Serial.println("Ferme");
  }
  else if (digitalRead(0) == 0 && digitalRead(0) != LastState) { //Ouvert
    LastState = !LastState;
    Serial.println("Ouvert");
  }
  else {
  }
  delay(100);
}

void connect_wifi() {
  WiFi.mode(WIFI_STA);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting to the WiFi");
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(250);
    Serial.print(".");
  }
  Serial.println();
  Serial.print("IP Address: ");
  Serial.println(WiFi.localIP());
}
