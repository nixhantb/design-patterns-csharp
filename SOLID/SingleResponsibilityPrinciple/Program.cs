
namespace SingleResponsibilityPrinciple
{

    // Logger: (SRP: Handles logging logic)

    public class Logger
    {

        private readonly FileManager _fileManager;

        public Logger(FileManager fileManager)
        {
            _fileManager = fileManager;
        }


        public void LogInfo(string message)
        {

            var logMessage = $"{DateTime.Now} [INFO] : {message}";
            _fileManager.WriteToFile(logMessage);
        }

        public void LogError(string message)
        {
            var logMessage = $"{DateTime.Now} [ERROR]: {message}";
            _fileManager.WriteToFile(logMessage);
        }
    }

    // Handles file Operations (SRP)
    public class FileManager
    {

        private readonly string _filePath;

        public FileManager(string filePath)
        {

            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {

            var directory = Path.GetDirectoryName(_filePath);
           

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {

                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
            }

        }

        public void WriteToFile(string content)
        {
            File.AppendAllText(_filePath, content + Environment.NewLine);
        }

    }

    public class Program
    {

        static void Main(string[] args)
        {

            var logger = new Logger(new FileManager("application.log"));

            logger.LogInfo("Application started");

            try
            {
                throw new InvalidOperationException("Something went wrong");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            logger.LogInfo("Application ended.");
            Console.WriteLine("Logs written successfully!");
        }
    }


}