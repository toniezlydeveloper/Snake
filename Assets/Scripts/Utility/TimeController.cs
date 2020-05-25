using UnityEngine;

namespace Utility
{
    public static class TimeController
    {
        private static bool isInitialized;
        private static float initialTimeScale;
        private static float previousTimeScale;

        public static void MultiplyTimeScale(float modifier)
        {
            Initialize();
            SetTimeScale(initialTimeScale * modifier);
        }

        public static void RestorePreviousTimeScale()
        {
            Time.timeScale = previousTimeScale;
        }

        public static void ResetTimeScale()
        {
            Initialize();
            SetTimeScale(initialTimeScale);
        }
        
        private static void SetTimeScale(float newTimeScale)
        {
            previousTimeScale = Time.timeScale;
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