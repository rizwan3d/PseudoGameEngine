﻿using System.Diagnostics;

namespace PseudoGameEngine
{
    public class Timer
    {
        Stopwatch stopWatch = new Stopwatch();

        public Timer()
        {
            stopWatch.Start();
        }

        // Start the timer
        public void Reset()
        {
            stopWatch.Restart();
        }


       // Stop the timer
        public void Stop()
        {
            stopWatch.Stop();
        }

        // Returns the duration of the timer (in Milliseconds)
        public float DurationMilliseconds
        {
            get
            {                
                return stopWatch.ElapsedMilliseconds;
            }
        }

        // Returns the duration of the timer (in Seconds)
        public float DurationSeconds
        {
            get
            {
                return (float)stopWatch.Elapsed.TotalSeconds;
            }
        }


    }
}
