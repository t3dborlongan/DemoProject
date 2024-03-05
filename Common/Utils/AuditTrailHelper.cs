using Common.Constants;

namespace Common.Utils
{
    public static class AuditTrailHelper
    {
        // Get the path to the bin directory
        static string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private static void CreateLogFileIfDoesNotExists(string logFile)
        {
            if (!File.Exists(logFile))
            {
                // If the file doesn't exist, create it
                using (FileStream fs = File.Create(logFile))
                {
                    Console.WriteLine($"Created log file: {Path.GetFileName(logFile)}.");
                }
            }
        }

        private static void LogAuditTrail(string logData, string logFile)
        {
            CreateLogFileIfDoesNotExists(logFile);
            using StreamWriter sw = File.AppendText(logFile);
            sw.WriteLine(Path.GetFileName(logData));

            Console.WriteLine($"{logData} appended to the {Path.GetFileName(logFile)} file.");
        }

        public static void LogToAddedAuditTrail(string fileName)
        {
            string logFile = Path.Combine(binDirectory, DeploymentPaths.AUDIT_TRAIL, DeploymentPaths.ADDED_FILE_LOG);

            LogAuditTrail(fileName, logFile);
        }

        public static void LogToRemovedAuditTrail(string fileName)
        {
            string logFile = Path.Combine(binDirectory, DeploymentPaths.AUDIT_TRAIL, DeploymentPaths.REMOVED_FILE_LOG);

            LogAuditTrail(fileName, logFile);
        }

        public static void LogToJsonFile(string data) {
            string logFile = Path.Combine(binDirectory, DeploymentPaths.AUDIT_TRAIL, DeploymentPaths.JSON_LOG);

            LogAuditTrail(data, logFile);
        }
    }
}