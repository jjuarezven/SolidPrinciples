﻿using ArdalisRating.Core.Interfaces;
using System;

namespace ArdalisRating.Infrastructure.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
