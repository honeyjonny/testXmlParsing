``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i5-2410M CPU 2.30GHz (Sandy Bridge), 1 CPU, 4 logical and 2 physical cores
Frequency=2241002 Hz, Resolution=446.2290 ns, Timer=TSC
.NET Core SDK=2.1.503
  [Host] : .NET Core 2.1.7 (CoreCLR 4.6.27129.04, CoreFX 4.6.27129.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3394.0
  Core   : .NET Core 2.1.7 (CoreCLR 4.6.27129.04, CoreFX 4.6.27129.04), 64bit RyuJIT


```
|                Method |  Job | Runtime |      Mean |     Error |    StdDev |       Min |      Max | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |----- |-------- |----------:|----------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|       TestRootParsing |  Clr |     Clr | 12.070 us | 0.2371 us | 0.3620 us | 11.482 us | 12.76 us |  1.00 |    0.00 | 8.5907 |     - |     - |  13.23 KB |
|       TestRootParsing | Core |    Core | 13.503 us | 0.0566 us | 0.0530 us | 13.398 us | 13.60 us |  1.11 |    0.03 | 8.6060 |     - |     - |  13.27 KB |
|                       |      |         |           |           |           |           |          |       |         |        |       |       |           |
| TestDataParsingManual |  Clr |     Clr |  9.804 us | 0.1937 us | 0.4788 us |  9.213 us | 11.13 us |  1.00 |    0.00 | 3.3112 |     - |     - |   5.09 KB |
| TestDataParsingManual | Core |    Core | 11.611 us | 0.0560 us | 0.0468 us | 11.545 us | 11.68 us |  1.19 |    0.05 | 3.3264 |     - |     - |   5.12 KB |
