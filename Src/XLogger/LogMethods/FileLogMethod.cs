﻿using System;
using System.Collections.Generic;
using System.IO;
using XLogger.Configuration;
using XLogger.Configuration.MethodsConfiguration;

namespace XLogger.LogMethods {
	public class FileLogMethod : ILogMethod {

		public readonly string FileName;

		public readonly string FileDirectory;

		protected List<string> WaitedLogs;

		public FileLogMethod(string fileName = null, FileLogMethodConfiguration config = null) {
			config = config ?? LoggerConfiguration.GetConfiguration<FileLogMethodConfiguration>() ?? new FileLogMethodConfiguration();
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
				using (var writer = new StreamWriter(File.Open(Path.Combine(FileDirectory, FileName), FileMode.Append))) {
					foreach (string s in WaitedLogs) {
						writer.WriteLine(s);
					}
					WaitedLogs.Clear();
					writer.WriteLine(log.FormattedMessage);
				}
			}
			catch {
				WaitedLogs.Add(log.FormattedMessage);
			}
		}
	}
}
