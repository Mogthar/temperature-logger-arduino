#include <OneWire.h>
#include <DallasTemperature.h>
#include <math.h>

// Data wire is plugged into port 4 on the Arduino
#define ONE_WIRE_BUS 13
// Setup a oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs)
OneWire oneWire(ONE_WIRE_BUS);

// Pass our oneWire reference to Dallas Temperature. 
DallasTemperature sensors(&oneWire);

int numberOfDevices; // Number of temperature devices found
char acquireDataCommand = 'a';
char fillData[] = ",-1";

float dividerScaling = 0.54113;

void setup(void) {
  // start serial port
  Serial.begin(9600);
  
  // Start up the library
  sensors.begin();
}

void loop(void) {
  if(Serial.find(acquireDataCommand))
  {
    numberOfDevices = sensors.getDeviceCount();
    sensors.requestTemperatures();
    for(int i = 0; i < 5; i++)
    {
      if(i < numberOfDevices)
      {
        Serial.print(',');
        Serial.print(sensors.getTempCByIndex(i)); 
      }
      else
      {
        Serial.print(fillData);
      }
    }
    // Read the pressure from pffeifer
    int analogBitValue = analogRead(A0);
    float voltage = analogBitValue * (5.0 / 1023.0) / dividerScaling;
    float exponent = 1.667 * voltage - 11.33;
    int flooredExponent = floor(exponent);
    float prefactor = pow(10, exponent - flooredExponent);
    Serial.print(',');
    Serial.print(prefactor);
    Serial.print('E');
    Serial.print(flooredExponent);
    Serial.println();
    Serial.flush();
  }
}
