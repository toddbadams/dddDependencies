using System;

namespace ddd.Core.Logging
{
    public interface ILog
    {
        /// <summary>
        /// Log a message object with Debug level.
        /// </summary>
        /// <param name="message">Message to log</param>
        void Debug(string message);

        /// <summary>
        /// Log a message object with Debug level.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Log a message object with Error level.
        /// </summary>
        /// <param name="message">Message to log</param>
        void Error(string message);

        /// <summary>
        /// Log a message object with Error level.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        void Error(object message, Exception exception);
    }
}
