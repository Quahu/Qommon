using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.SystemConsole.Themes;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Qommon.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public abstract unsafe class QommonFixture
    {
        protected ILogger Logger;

        protected TestContext _context;

        protected static readonly ILoggerFactory LoggerFactory;

        static QommonFixture()
        {
            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            LoggerFactory = new SerilogLoggerFactory(serilogLogger);
        }

        [SetUp]
        public virtual void Setup()
        {
            _context = TestContext.CurrentContext;

            Logger = LoggerFactory.CreateLogger(_context.Test.Name);
        }

        [TearDown]
        public virtual void Teardown()
        { }
    }
}
