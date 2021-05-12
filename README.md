# XLogger
Simple logger for C# apps

## Features
1. Console text highlighting:
![](/Doc/Readme/feature1.png)

2. Levels filtering
```c#
LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
	builder.UseConsoleLogging(LogLevelFilter.ByHigherLevel(LogLevel.Error));
});
Logger.Info("this is not-logged message");
Logger.Error("some error");
Logger.Fatal("fatal error");
/*
	Output:
	01.01.2020 12:00:00 Error:	some error
	01.01.2020 12:00:00 Fatal:	fatal error
*/
```

3. Exception logging
```c#
try {
	// some code ...
}
catch (Exception e) {
	Logger.Error(e);
}
```

4. Object logging
```c#
class YourAmazingClass {

	[LoggedProperty]
	public int YourProperty { get; set; }
	
	[LoggedProperty(Value = "your loved property")]
	public string YourAnotherProperty { get; set; }
	
	[LoggedProperty(IsDebug = true)]
	public string DebugField;
}

// usage
YourAmazingClass cl = new YourAmazingClass();
Logger.Info(cl);

```

5. Custom formatters for regular logs and exceptions
```c#
LoggerConfiguration.ConfigureLoggerConfiguration(builder => {
	builder
		.UseDefaultConfiguration()
		.AddFormatter(new MyCustomExceptionFormatter());	// add formatter for MyCustomException
});
Logger.Error(new MyCustomException());
```

## Usage
```c#
using XLogger;
using XLogger.Configuration;

namespace YourAmazingApp {
	public class YourAmazingClass {
	
		public void YourAmazingFunc() {
			Logger.Info("Hello, world!");

			Logger.Debug("debug message");
			LoggerConfiguration.SetLogLevel(LogLevel.Info);
			Logger.Debug("not logged message");
			LoggerConfiguration.SetLogLevel(LogLevel.Debug);
			Logger.Debug("this message was logged");
			/*
				01.01.2020 12:00:00 Debug:	debug message
				01.01.2020 12:00:00 Debug:	this message was logged
			*/
			
			try {
				throw new Exception();
			}
			catch (Exception e) {
				Logger.Error(e);
			}
		}
	
	}
}
```
more docs and samples will be writen later...