#!/usr/bin/env dotnet-script

#nullable enable

using System;
using System.Threading;

#region [Script]

var exemplo = new TimerExemplo();

while (true)
{
    var key = ReadKey(true);

    if (key.Key == ConsoleKey.S)
    {
        exemplo.Start();
    }
    else if (key.Key == ConsoleKey.X)
    {
        exemplo.Stop();
    }
    else if (key.Key == ConsoleKey.Q)
    {
        break;
    }
}

#endregion [Script]

#region [Classes]

class TimerExemplo
{
    private const double DefaultCountDown = 15;
    private double CountDown = 15;

    Timer? timer;

    public void Start()
    {
        CountDown = DefaultCountDown;

        if (timer == null)
        {
            WriteLine("Timer iniciado");
            timer = new(t => UpdateTime(), null, 0, 1000);
        }
        else
        {
            WriteLine("Timer reiniciado");
        }
    }

    public void Stop()
    {
        if (timer != null)
        {
            timer.Dispose();
            timer = null;
        }

        WriteLine("Timer parado");
    }

    public void UpdateTime()
    {
        WriteLine(TimeSpan.FromSeconds(CountDown).ToString("mm\\:ss"));

        if (--CountDown < 0)
        {
            CountDown = 0;

            Stop();
        }
    }
}

#endregion [Classes]
