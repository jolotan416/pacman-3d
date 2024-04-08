using UnityEngine;

namespace Utils
{
    public class LogUtils
    {
        private string tag = "";

        public LogUtils(string tag)
        {
            this.tag = CreateTag(tag);
        }

        public void LogDebug(string logString)
        {
            Debug.Log(tag + logString);
        }

        public void LogWarning(string logString)
        {
            Debug.LogWarning(tag + logString);
        }

        public void LogError(string logString)
        {
            Debug.LogError(tag + logString);
        }

        private string CreateTag(string tag)
        {
            return "[" + tag + "] ";
        }
    }
}