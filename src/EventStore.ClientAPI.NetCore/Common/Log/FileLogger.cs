﻿using System;
using System.IO;

namespace EventStore.ClientAPI.Common.Log
{
    /// <summary>
    /// Logger that writes to a file
    /// </summary>
    class FileLogger : ILogger, IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public FileLogger(string filename)
        {
            _streamWriter = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate)) {AutoFlush = true};
        }

        public void Error(string format, params object[] args)
        {
            _streamWriter.WriteLine("Error: " + format, args);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            _streamWriter.WriteLine("Error: " + format, args);
            _streamWriter.WriteLine(ex);
        }

        public void Info(string format, params object[] args)
        {
            _streamWriter.WriteLine("Info : " + format, args);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            _streamWriter.WriteLine("Info : " + format, args);
            _streamWriter.WriteLine(ex);
        }

        public void Debug(string format, params object[] args)
        {
            _streamWriter.WriteLine("Debug: " + format, args);
        }

        public void Debug(Exception ex, string format, params object[] args)
        {
            _streamWriter.WriteLine("Debug: " + format, args);
            _streamWriter.WriteLine(ex);

        }

        void IDisposable.Dispose()
        {
            _streamWriter.Dispose();
        }
    }
}
