using XLogger.Configuration;
using XLogger.Configuration.MethodsConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XLogger.LogMethods {
	public class FileLogMethod : ILogMethod {

		public readonly string FileName;

		public readonly string FileDirectory;

		protected List<string> WaitedLogs;

		public FileLogMethod(string fileName = null, FileLogMethodConfiguration config = null) {
			config = config ?? LoggerConfiguration.GetConfiguration<FileLogMethodConfiguration>() ?? (new FileLogMethodConfiguration()).CreateDefaultConfiguration() as FileLogMethodConfiguration;
			fileName = fileName ?? "log.log";
			if (config.GenerateNewFile) {
				FileName = string.Format(config.FilePattern, DateTime.Now, fileName);
			} else {
				FileName = fileName;
			}
			FileDirectory = config.FileDirectory ?? string.Empty;
			WaitedLogs = new List<string>();
		}

		public FileLogMethod(FileLogMethodConfiguration config) : this(config?.FilePattern, config) {

		}

		public FileLogMethod(string fileName) : this(fileName, LoggerConfiguration.GetConfiguration<FileLogMethodConfiguration>()) {

		}

		public FileLogMethod(string fileName, string fileDirectory) {
			FileName = fileName;
			FileDirectory = fileDirectory;
			WaitedLogs = new List<string>();
		}

		public void Write(FormattedLogMessage log) {
			try {
				if (!string.IsNullOrEmpty(FileDirectory)) {
					DirectoryInfo dir = new DirectoryInfo(FileDirectory);
					if (!dir.Exists) {
						dir.Create();
					}
				}
				Console.WriteLine(log.FormattedMessage);
				using (var writer = new StreamWriter(File.Open(Path.Combine(FileDirectory, FileName), FileMode.Append))) {
					foreach (string s in WaitedLogs) {
						writer.WriteLine(s);
					}
					WaitedLogs.Clear();
					writer.WriteLine(log.FormattedMessage);
				}
			}
			catch {
				Console.WriteLine("E BLYAT");
				WaitedLogs.Add(log.FormattedMessage);
			}
		}
	}
}
