import processing.io.*;

int trigPin = 12;
int echoPin = 13;

int LED1 = A0;
int LED2 = A1;
int LED3 = A2;
int LED4 = A3;
int LED5 = A4;
int LED6 = A5;
int LED7 = 2;

int duration = 0;
int distance = 0;

void setup() {
  GPIO.pinMode(trigPin, GPIO.OUTPUT);
  GPIO.pinMode(echoPin, GPIO.INPUT);
  
  GPIO.pinMode(LED1, GPIO.OUTPUT);
  GPIO.pinMode(LED2, GPIO.OUTPUT);
  GPIO.pinMode(LED3, GPIO.OUTPUT);
  GPIO.pinMode(LED4, GPIO.OUTPUT);
  GPIO.pinMode(LED5, GPIO.OUTPUT);
  GPIO.pinMode(LED6, GPIO.OUTPUT);
  GPIO.pinMode(LED7, GPIO.OUTPUT);
  
  println("Setup Complete");
}

void loop() {
  GPIO.digitalWrite(trigPin, GPIO.LOW);
  delayMicroseconds(2);
  GPIO.digitalWrite(trigPin, GPIO.HIGH);
  delayMicroseconds(10);
  GPIO.digitalWrite(trigPin, GPIO.LOW);
  
  duration = GPIO.pulseIn(echoPin, GPIO.HIGH);
  distance = duration / 58.2;

  GPIO.digitalWrite(LED1, distance <= 7 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED2, distance <= 14 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED3, distance <= 21 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED4, distance <= 28 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED5, distance <= 35 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED6, distance <= 42 ? GPIO.HIGH : GPIO.LOW);
  GPIO.digitalWrite(LED7, distance <= 49 ? GPIO.HIGH : GPIO.LOW);

  delay(100);
}