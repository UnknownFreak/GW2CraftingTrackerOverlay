using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OverlayApp.Logger
{
    public class Logger
    {
        public enum MessageType
        {
            Info,
            Warning,
            Error,
            ComponentInfo,
        }

        private static BindingList<LogMessage> logmessages = new BindingList<LogMessage>();
        private static DataGridView log;
        public static void Log(object message, MessageType type, [CallerLineNumber] uint lineNumber = 0)
        {
            if(log != null)
            log.Invoke((MethodInvoker)delegate {
                logmessages.Add(new LogMessage(message.ToString(), type, lineNumber));
                log.Refresh();
            });
            else
            {
                logmessages.Add(new LogMessage(message.ToString(), type, lineNumber));
            }

        }

        public class LogMessage
        {
            public LogMessage(string msg, MessageType type, uint line)
            {
                Message = msg;
                Severity = type;
                Line = line;
            }

            public string Message { get; set; }
            public MessageType Severity { get; set; }
            public uint Line { get; set; }
        }

        public static void linkDataSource(DataGridView logView)
        {
            log = logView;
            logView.DataSource = logmessages;
        }
    }
}
