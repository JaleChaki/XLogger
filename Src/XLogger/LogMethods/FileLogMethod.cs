using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logging.LogMethods {
	public class FileLogMethod : ILogMethod {

		public readonly string FileName;

		public readonly string FileDirectory;

		protected static readonly object Sync = new object();



		public FileLogMethod() : this() {

		}

		public FileLogMethod(string fileName) : this(fileName, string.Empty) {

		}

		public FileLogMethod(string fileName, string fileDirectory) {
			FileName = fileName;
			FileDirectory = fileDirectory;
		}

		public void Write(FormattedLogMessage log) {

			lock (Sync) {
				try {
					using (StreamWriter writer = new StreamWriter(Path.Combine(FileName))) {
						
					}
				}
				catch {
					
				}
			}
		}
	}
}
