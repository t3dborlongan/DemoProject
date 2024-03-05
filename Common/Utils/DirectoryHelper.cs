using Common.Constants;
using Common.Utils;

namespace Constants.Utils
{
    public class DirectoryHelper
    {
        // Get the path to the bin directory
        static string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

        static DirectoryHelper()
        {
            SetupDeploymentDirectory(DeploymentPaths.AUDIT_TRAIL);
        }

        public static void SetupDeploymentDirectory(string folderName)
        {
            // Combine the bin directory path with the folder name
            string folderPath = Path.Combine(binDirectory, folderName);

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                // If the folder does not exist, create it
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder created: " + folderPath);
            }
        }

        private static void IncludeToAddedDirectory(string filePath)
        {
            SetupDeploymentDirectory(DeploymentPaths.ADDED_DIR);
            string fileName = Path.GetFileName(filePath);
            Console.WriteLine($"Copying {fileName} to the Added files folder.");
            string sourceFile = Path.Combine(binDirectory, filePath);
            string destinationFile = Path.Combine(binDirectory, DeploymentPaths.ADDED_DIR, fileName);
            File.Copy(sourceFile, destinationFile, true);
            Console.WriteLine($"Copying {fileName} to the Added files folder was successful.");
        }

        private static void IncludeToRemovedDirectory(string filePath)
        {
            SetupDeploymentDirectory(DeploymentPaths.REMOVE_DIR);
            string fileName = Path.GetFileName(filePath);
            Console.WriteLine($"Copying {fileName} to the Removed files folder.");
            string sourceFile = Path.Combine(binDirectory, filePath);
            string destinationFile = Path.Combine(binDirectory, DeploymentPaths.REMOVE_DIR, fileName);
            File.Copy(sourceFile, destinationFile, true);
            Console.WriteLine($"Copying {fileName} to the Removed files folder was successful.");
        }

        public static void PrepareForDeployment(string[] lineItem)
        {
            if (!string.IsNullOrEmpty(lineItem[0]) || 
                !string.IsNullOrEmpty(lineItem[1]))
            {
                var changeStatus = lineItem[0].ToUpper();
                var fileSourcePath = lineItem[1].Replace("/", "\\");

                if (changeStatus == FileStatus.ADDED || changeStatus == FileStatus.MODIFIED)
                {
                    AuditTrailHelper.LogToAddedAuditTrail(fileSourcePath);
                    IncludeToAddedDirectory(fileSourcePath);
                }
                else if (changeStatus == FileStatus.REMOVED || changeStatus == FileStatus.DELETED) 
                {
                    AuditTrailHelper.LogToRemovedAuditTrail(fileSourcePath);
                    IncludeToRemovedDirectory(fileSourcePath);
                }
            }
        }
    }
}
