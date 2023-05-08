using System;
namespace DueTalk.Core
{
    public class BaseContext
    {
        public const string baseContext = @"/* This document contains a sample pseudo code, natural language commands and the pseudo code needed to accomplish them */
/* print 50 to canvas */
var x = 50
print(x)
/* clear canvas */
cls
/* Write analog data with parameter (pin number, duty cycle) */
AWrite(""L"",i)
/* Read analog data with paramter (pin number), return number */
x=ARead(0)
/* print 100 to display */
var x = 100
PrintLn(x)
/* delay 100 miliseconds */
Wait(100)
/* play beep (pin number, frequency, duration) */
Beep(0,256,1000)
/* Jump code to label back */
var i = 0
@Back
For i=0 to 100
    PrintLn(i)  
    Wait(100)
Next
Goto Back
/* Enable button a, parameter (pin number, state) */
BtnEnable('a',1)
/* Disable button b, parameter (pin number, state) */
BtnEnable('b',0)
/* Check if button 1 is up, return 1 if true, return 0 if false, parameter (pin number) */
x=BtnUp(1)
/* Check if button 2 is down, return 1 if true, return 0 if false, parameter (pin number) */
x=BtnDown(1)
/* Read digital pin, parameter (pin number, pull up or pull down) */
x = DRead(2,1)
If x = 0
    Print(""low"")
Else
    Print(""high"")
End
/* Write digital pin, parameter (pin number, state) */
for x = 1 to 10
    DWrite('L',1)
    Wait(200)
    DWrite('L',0)
    Wait(200)
next
/* Check distance sensor, parameter (trigger, echo) */
var x = 0
@Loop
x = Distance(0,1) 
If x>0 
    PrintLn(x)
End
Wait(100)
Goto Loop
/* Generate PWM frequency, parameter (frequency in KHz, duration, dutyCycle) */
var x = 0
@Loop
For x=1 to 1000
    Freq(x,500,500)
    Wait(200)
Next
For x=1000 to 1 step -1
    Freq(x,500,500)
    Wait(200)
Next
Goto Loop
/* Send 0x55 byte to slave address 0x3D */
var a = 0
a = 0x55
I2cBytes(0x3D, 1, 0)
/* Read 2 bytes from slave address 0x2C */
I2cBytes(0x2C, 0, 2)
/* Enable infrared */
IrEnable(1)
/* Read infrared */
var x = 0
@Loop
x=IrRead()
if x >=0: PrintLn(x):end
Wait(1000)
goto Loop
/* Clear display */
LcdClear(0)
/* Sends the display buffer to the LCD */
LcdShow()
/* Draw line to display, paramter (color, x1,y1,x2,y2) */
LcdLine(1,0,0,128,64)
/* Set pixel color, paramter (color, x, y) */
LcdPixel(1,64,32)
/* Draw circle, parameter (color, x,y,radius) */
LcdCircle(1,64,32,31)
/* Draw rectangle, parameter */
LcdClear(0)
LcdRect(1,10,10,118,54)
LcdShow()
/* Draw scaled text, parameter (text, color, x, y, scaleWidth, scaleHeight) */
LcdClear(0)
LcdTextS(""Hello"",1,0,0,2,2)
LcdShow()
/* Draw text, parameter (text, color, x, y) */
LcdClear(0)
LcdText(""Hello World"",1,10,10)
LcdShow()
/* Clear neo pixel */
NeoClear()
/* Set neopixel led to specific color, parameter (index, red, green, blue) */
var x = 0
For x = 0 to 8
    NeoSet(x,x*10,0,0)
Next
/* Set servo position, parameter (pin number, degree) */
ServoSet(0,180)
/* play sound, paramter (frequency, duration, volume) */
Sound(256,1000,50) 
/* Write to SPI, Send 0x55 and read the returned byte into x, parameter (byte) */
var x = 0
x = SpiByte(0x55)
/* SPI Config, mode 0 and frequency 200 Khz, parameter (mode,frequency) */
SpiCfg(0,200)
/* Read touch in pin 0 */
var a = 0 
a=TouchRead(0)
/* UART Init with baud rate 9600 */
UartInit(9600)
/* Read uart data return bytes */
x = UartRead()
/* Uart write data in byte */
UartWrite(data)
/* count data length to read from uart */
x = UartCount()
/* get cos function from number variable */
Cos(number)
/* Generate random number, maximum 100 */
Rnd(100) 
/* get sin of 90 */
Sin(90)
/* Get square root of number */
Sqrt(number)
/* Get tangent from number */
Tan(number)
/* get system tick in miliseconds from system */
TickMs()
/* truncate number */
Trunc(number) 
";


    }
}