using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.IO.StreamWriter;

namespace Dsi.Utility {

    public class Log2Text : IDisposable {

        public const string SeverityInformation = "I";
        public const string SeverityWarning = "W";
        public const string SeverityError = "E";
        public const string SeverityFatal = "F";
        public const string SeverityDebug = "D";

        public string _fullPath = null;
        private System.IO.StreamWriter _streamWriter = null;

        public void Log(string message, string severity = SeverityInformation) {
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            _streamWriter.WriteLine($"{timestamp:-25} [{severity}] {message}");
        }
        public void LogInfo(string message) {
            Log(message);
        }
        public void LogWarn(string message) {
            Log(message, SeverityWarning);
        }
        public void LogError(string message) {
            Log(message, SeverityError);
        }
        public void LogFatal(string message) {
            Log(message, SeverityFatal);
        }
        public void LogDebug(string message) {
            Log(message, SeverityDebug);
        }

        public Log2Text(string fullPath) {
            _streamWriter = new System.IO.StreamWriter(fullPath, true);
        }

        public void Dispose() {
            if (_streamWriter is not null) {
                _streamWriter.Close();
            }
        }
        
    }
}
