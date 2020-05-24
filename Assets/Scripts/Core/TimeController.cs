using UnityEngine;

namespace Core
{
    public static class TimeController
    {
        private static bool isInitialized;
        private static float initialTimeScale;

        public static void MultiplyTimeScale(float modifier)
        {
            Initialize();
            SetTimeScale(initialTimeScale * modifier);
        }

        public static void ResetTimeScale()
        {
            Initialize();
            SetTimeScale(initialTimeScale);
        }
        
        private static void SetTimeScale(float newTimeScale)
        {
            Time.timeScale = newTimeScale;
        }

        private static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }
            
            initialTimeScale = Time.timeScale;
            isInitialized = true;
        }
    }
}