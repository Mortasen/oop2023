using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double[]> averageTemperatures = GenerateAverageTemperatures();
        double[] sortedAverageTemperatures = CalculateAverageTemperatures(averageTemperatures);
        PrintAverageTemperatures(sortedAverageTemperatures);
    }

    static Dictionary<string, double[]> GenerateAverageTemperatures()
    {
        Random random = new Random();
        string[] months = {"січень", "лютий", "березень", "квітень", "травень", "червень",
                           "липень", "серпень", "вересень", "жовтень", "листопад", "грудень"};

        Dictionary<string, double[]> averageTemperatures = new Dictionary<string, double[]>();

        for (int month = 0; month < 12; month++)
        {
            double[] dailyTemperatures = new double[30];
            for (int day = 0; day < 30; day++)
            {
                double temperature = random.NextDouble() * 40 - 10; // Random temperature between -10°C and 30°C
                dailyTemperatures[day] = temperature;
            }

            averageTemperatures.Add(months[month], dailyTemperatures);
        }

        return averageTemperatures;
    }

    static double[] CalculateAverageTemperatures(Dictionary<string, double[]> averageTemperatures)
    {
        double[] sortedAverageTemperatures = new double[12];

        int index = 0;
        foreach (var kvp in averageTemperatures)
        {
            string month = kvp.Key;
            double[] temperatures = kvp.Value;

            double averageTemperature = CalculateAverageTemperature(temperatures);
            sortedAverageTemperatures[index] = averageTemperature;
            index++;
        }

        Array.Sort(sortedAverageTemperatures);
        return sortedAverageTemperatures;
    }

    static double CalculateAverageTemperature(double[] temperatures)
    {
        double sum = 0;
        foreach (double temperature in temperatures)
        {
            sum += temperature;
        }

        return sum / temperatures.Length;
    }

    static void PrintAverageTemperatures(double[] sortedAverageTemperatures)
    {
        Console.WriteLine("Середня температура за кожен місяць (відсортована по зростанню):");

        string[] months = {"січень", "лютий", "березень", "квітень", "травень", "червень",
                           "липень", "серпень", "вересень", "жовтень", "листопад", "грудень"};

        for (int i = 0; i < sortedAverageTemperatures.Length; i++)
        {
            double averageTemperature = sortedAverageTemperatures[i];
            string month = months[i];

            Console.WriteLine($"{month}: {averageTemperature:F2}°C");
        }
    }
}

