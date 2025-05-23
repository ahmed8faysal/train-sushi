using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int trigPin = 12;
    static int echoPin = 13;

    static int LED1 = 0; 
    static int LED2 = 1;
    static int LED3 = 2;
    static int LED4 = 3;
    static int LED5 = 4;
    static int LED6 = 5;
    static int LED7 = 6;

    static GpioController gpio = new GpioController();

    static void Main()
    {
        gpio.OpenPin(trigPin, PinMode.Output);
        gpio.OpenPin(echoPin, PinMode.Input);

        gpio.OpenPin(LED1, PinMode.Output);
        gpio.OpenPin(LED2, PinMode.Output);
        gpio.OpenPin(LED3, PinMode.Output);
        gpio.OpenPin(LED4, PinMode.Output);
        gpio.OpenPin(LED5, PinMode.Output);
        gpio.OpenPin(LED6, PinMode.Output);
        gpio.OpenPin(LED7, PinMode.Output);

        while (true)
        {
            int distance = GetDistance();

            gpio.Write(LED1, distance <= 7 ? PinValue.High : PinValue.Low);
            gpio.Write(LED2, distance <= 14 ? PinValue.High : PinValue.Low);
            gpio.Write(LED3, distance <= 21 ? PinValue.High : PinValue.Low);
            gpio.Write(LED4, distance <= 28 ? PinValue.High : PinValue.Low);
            gpio.Write(LED5, distance <= 35 ? PinValue.High : PinValue.Low);
            gpio.Write(LED6, distance <= 42 ? PinValue.High : PinValue.Low);
            gpio.Write(LED7, distance <= 49 ? PinValue.High : PinValue.Low);

            Thread.Sleep(100);
        }
    }

    static int GetDistance()
    {
        gpio.Write(trigPin, PinValue.Low);
        Thread.Sleep(2);
        gpio.Write(trigPin, PinValue.High);
        Thread.Sleep(10);
        gpio.Write(trigPin, PinValue.Low);

        Stopwatch stopwatch = Stopwatch.StartNew();
        while (gpio.Read(echoPin) == PinValue.Low) { }
        stopwatch.Restart();
        while (gpio.Read(echoPin) == PinValue.High) { }
        stopwatch.Stop();

        double duration = stopwatch.Elapsed.TotalMicroseconds;
        return (int)(duration / 58.2);
    }
}