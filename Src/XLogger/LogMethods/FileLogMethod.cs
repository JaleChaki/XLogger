using Logging.Configuration;
using Logging.Configuration.MethodsConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logging.LogMethods {
	public class FileLogMethod : ILogMethod {

		public readonly string FileName;

		public readonly string FileDirectory;

		protected static readonly object Sync = new object();

		protected List<string> WaitedLogs;

		public FileLogMethod(string fileName = null, FileLogMethodConfiguration config = null) {
			config = config ?? LoggerConfiguration.GetConfiguration<FileLogMethodConfiguration>();
			fileName = fileName ?? "log.log";
			if (config.GenerateNewFile) {
				FileName = string.Format(config.FilePattern, DateTime.Now, fileName);
			} else {
				FileName = config.FilePattern;
			}
			FileDirectory = config.FileDirectory;
			WaitedLogs = new List<string>();
		}

		public FileLogMethod(string fileName) : this(fileName, LoggerConfiguration.GetConfiguration<FileLogMethodConfiguration>()) {

		}

		public FileLogMethod(string fileName, string fileDirectory) {
			FileName = fileName;
			FileDirectory = fileDirectory;
			WaitedLogs = new List<string>();
		}

		public void Write(FormattedLogMessage log) {
			lock (Sync) {
				try {
					DirectoryInfo dir = new DirectoryInfo(FileDirectory);
					if (!dir.Exists) {
						dir.Create();
					}
					using (var writer = new StreamWriter(File.Open(Path.Combine(FileDirectory, FileName), FileMode.Append))) {
						writer.WriteLine(log.FormattedMessage);
					}
				}
				catch {
					WaitedLogs.Add(log.FormattedMessage);
				}
			}
		}
	}
}
