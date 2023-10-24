using System;
using System.Diagnostics;
using Common;

namespace RunTestsConsoleApp
{
    public class StackAndQueuesTests
    {
        const int numSamples = 10000;

        public static bool Test<T>(IPushPop<T> pushPop, T[] initialValues, bool isQueue = false)
        {
            Console.WriteLine("# Running tests");
            Console.Write("Testing Push()/Count()...");
            for (int i = 0; i < initialValues.Length; i++)
            {
                pushPop.Push(initialValues[i]);

                if (pushPop.Count() != i + 1)
                {
                    Console.WriteLine($"ERROR. Count() returned {pushPop.Count()} instead of {i + 1}");
                    return false;
                }
            }
            Console.WriteLine($"OK.");

            Console.Write("Testing Clear()...");
            pushPop.Clear();
            if (pushPop.Count() != 0)
            {
                Console.WriteLine($"ERROR. Count returned {pushPop.Count()} instead of 0 after Clear()");
                return false;
            }
            Console.WriteLine($"OK.");

            Console.Write("Testing Push()/Pop()...");
            for (int i = 0; i < initialValues.Length; i++)
                pushPop.Push(initialValues[i]);

            for (int i = 0; i < initialValues.Length; i++)
            {
                T value = pushPop.Pop();

                if (!isQueue && !value.Equals(initialValues[initialValues.Length - i - 1])
                || isQueue && !value.Equals(initialValues[i])
                )
                {
                    Console.WriteLine($"ERROR. Pop() returned {value} instead of {initialValues[initialValues.Length - i - 1]}");
                    return false;
                }
            }
            Console.WriteLine($"OK.");
            return true;
        }
        public static double MeasurePerformance<T>(IPushPop<T> pushPop, T[] initialValues)
        {
            Console.WriteLine($"\n# Measuring performance (n={numSamples})");
            Stopwatch stopwatch = new Stopwatch();
            int numDigits = 5;
            //Push
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < numSamples; i++)
                pushPop.Push(initialValues[i % initialValues.Length]);
            stopwatch.Stop();
            Console.WriteLine($"Push (n={numSamples}) -> {Utils.ToString(stopwatch.Elapsed.TotalSeconds, numDigits)}");

            //Add again n elements
            for (int i = 0; i < numSamples; i++)
                pushPop.Push(initialValues[i % initialValues.Length]);

            //Remove first element
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < numSamples; i++)
                pushPop.Pop();
            stopwatch.Stop();
            Console.WriteLine($"Pop (n={numSamples}) -> {Utils.ToString(stopwatch.Elapsed.TotalSeconds, numDigits)} s");

            return stopwatch.Elapsed.TotalSeconds;
        }
    }
}