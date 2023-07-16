using UnityEngine;

namespace Interpreter
{
    public class ErrorHandler
    {
        private bool hadError = false;

        public bool IsError()
        {
            return hadError;
        }

        public void Error(int line, string message)
        {
            Report(line, "", message);
        }
        public void Report(int line, string where, string message)
        {
            string m = string.Format("[line {0}] Error {1}: {2}\n", line, where, message);
            Debug.Log(m);
            hadError = true;
        }
    }
}
