namespace RickAndMorty.Utils
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Wrapper for timing the execution of a code block.
    /// </summary>
    public class ExecutionTimer : IDisposable
    {
        private readonly MethodBase? _callerInfo;
        private readonly Stopwatch timer;
        private bool _disposed = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExecutionTimer"/> class.
        /// </summary>
        /// <param name="callerName">The name of the calling method.</param>
        public ExecutionTimer([CallerMemberName] string callerName = "")
        {
            this._callerInfo = this.GetCallerMethodBase(callerName);
            this.timer = Stopwatch.StartNew();
            this.timer.Start();
        }

        /// <summary>
        ///     Disposes the resources of the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Disposes the resources of the class.
        /// </summary>
        /// <param name="disposing">True if should dispose stuff.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                this.timer.Stop();
                Debug.WriteLine($"Method: {this._callerInfo?.Name} {this.timer.ElapsedMilliseconds}ms.");
            }

            this._disposed = true;
        }

        private MethodBase? GetCallerMethodBase(string callerName)
        {
            // get call stack
            StackTrace stackTrace = new StackTrace();

            // get method calls (frames)
            var stackFrame = stackTrace.GetFrames().FirstOrDefault(sf => sf?.GetMethod()?.Name == callerName);
            if (stackFrame == null)
            {
                return null;
            }

            return stackFrame.GetMethod();
        }
    }
}
