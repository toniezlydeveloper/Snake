using UnityEngine;

namespace Core
{
    public class HighScoreController
    {
        private int _highScore;

        private const string HighScoreKey = "HighScore";
        
        public HighScoreController()
        {
            if (PlayerPrefs.HasKey(HighScoreKey))
            {
                _highScore = PlayerPrefs.GetInt(HighScoreKey);
            }
        }

        public bool TryUpdatingHighScore(int newHighScore)
        {
            if (newHighScore <= _highScore)
            {
                return false;
            }

            _highScore = newHighScore;
            PlayerPrefs.SetInt(HighScoreKey, _highScore);
            return true;
        }
    }
}