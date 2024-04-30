using System;

struct MyTime
{
    public int hour, minute, second;
    public MyTime(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }

    public override string ToString()
    {
        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }
}

class Program
{
    static int ToSecSinceMidnight(MyTime t)
    {
        return t.hour * 3600 + t.minute * 60 + t.second;
    }
    static MyTime FromSecSinceMidnight(int t)
    {
        int secPerDay = 60 * 60 * 24;
        t %= secPerDay;
        if (t < 0)
            t += secPerDay;
        int h = t / 3600;
        int m = (t / 60) % 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }
    static MyTime AddOneSecond(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 1;
        return FromSecSinceMidnight(totalSeconds);
    }
    static MyTime AddOneMinute(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 60;
        return FromSecSinceMidnight(totalSeconds);
    }

    static MyTime AddOneHour(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 3600;
        return FromSecSinceMidnight(totalSeconds);
    }

    static MyTime AddSeconds(MyTime t, int s)
    {
        int totalSeconds = ToSecSinceMidnight(t) + s;
        return FromSecSinceMidnight(totalSeconds);
    }

    static int Difference(MyTime mt1, MyTime mt2)
    {
        int diffSeconds = ToSecSinceMidnight(mt1) - ToSecSinceMidnight(mt2);
        return diffSeconds;
    }

    static bool IsInRange(MyTime start, MyTime finish, MyTime t)
    {
        int startSec = ToSecSinceMidnight(start);
        int finishSec = ToSecSinceMidnight(finish);
        int tSec = ToSecSinceMidnight(t);

        if (startSec <= finishSec)
        {
            return tSec >= startSec && tSec <= finishSec;
        }
        else
        {
            return tSec >= startSec || tSec <= finishSec;
        }
    }

    static string WhatLesson(MyTime mt)
    {
        int time = ToSecSinceMidnight(mt);
        if (time >= 28800 && time <= 33600)
            return "Зараз перша пара";
        if (time >= 33601 && time <= 34800)
            return "Зараз перерва між першою та другою парою";
        if (time >= 34801 && time <= 39600)
            return "Зараз друга пара";
        if (time >= 39601 && time <= 40800)
            return "Зараз перерва між другою та третьою парою";
        if (time >= 40801 && time <= 45600)
            return "Зараз третя пара"; 
        if (time >= 45601 && time <= 46800)
            return "Зараз перерва між третьою та четвертою парою";
        if (time >= 46801 && time <= 51600)
            return "Зараз четверта пара"; 
        if (time >= 51601 && time <= 52800)
            return "Зараз перерва між четвертою та пятою парою";
        if (time >= 52801 && time <= 57600)
            return "Зараз п'ята пара";
        if (time >= 57601 && time <= 58800)
            return "Зараз перерва між п'ятою та шостою парою";
        if (time >= 58801 && time <= 63600)
            return "Зараз шоста пара";
        else
            return "Пар немає, ти вільна людина (поки що)";

    }
    static void Main()
    {
        Console.Write("Введіть час:");
        int[] t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        MyTime time = new MyTime(t[0], t[1], t[2]);
        Console.WriteLine("Current Time: " + time.ToString());

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add one second");
            Console.WriteLine("2. Add one minute");
            Console.WriteLine("3. Add one hour");
            Console.WriteLine("4. Add seconds");
            Console.WriteLine("5. Calculate difference between two times");
            Console.WriteLine("6. Check if time is in range");
            Console.WriteLine("7. Check what lesson is now");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    time = AddOneSecond(time);
                    Console.WriteLine("Time after adding one second: " + time.ToString());
                    break;
                case 2:
                    time = AddOneMinute(time);
                    Console.WriteLine("Time after adding one minute: " + time.ToString());
                    break;
                case 3:
                    time = AddOneHour(time);
                    Console.WriteLine("Time after adding one hour: " + time.ToString());
                    break;
                case 4:
                    Console.Write("Enter seconds to add: ");
                    int seconds = int.Parse(Console.ReadLine());
                    time = AddSeconds(time, seconds);
                    Console.WriteLine($"Time after adding {seconds} seconds: " + time.ToString());
                    break;
                case 5:
                    Console.WriteLine("Enter time in format (hour minute second):");
                    int[] time1Entered = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    MyTime time1 = new MyTime(time1Entered[0], time1Entered[1], time1Entered[2]);
                    Console.WriteLine("Enter another time:");
                    int[] time2Entered = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    MyTime time2 = new MyTime(time2Entered[0], time2Entered[1], time2Entered[2]);
                    int difference = Difference(time1, time2);
                    Console.WriteLine($"Difference between the two times in seconds: {difference}");
                    break;
                case 6:
                    Console.WriteLine("Enter start time:");
                    int[] startEntered = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    MyTime start = new MyTime(startEntered[0], startEntered[1], startEntered[2]);
                    Console.WriteLine("Enter finish time:");
                    int[] finishEntered = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    MyTime finish = new MyTime(finishEntered[0], finishEntered[1], finishEntered[2]);
                    Console.WriteLine("Enter time to check:");
                    MyTime checkTime = new MyTime(t[0], t[1], t[2]);
                    bool inRange = IsInRange(start, finish, checkTime);
                    Console.WriteLine($"Is the time in range: {inRange}");
                    break;
                case 7:
                    Console.WriteLine(WhatLesson(time));
                    break;
                case 8:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }
}