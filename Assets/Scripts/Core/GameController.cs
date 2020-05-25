using Collectables;
using UI;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SnakeController snakeController;
        [SerializeField] private CollisionsChecker collisionsChecker;
        [SerializeField] private CollectablesPlacer collectablesPlacer;
        [SerializeField] private int pointScoreValue;

        private int _score;
        private int _highScore;
        private IScorePresenter _scorePresenter;
        private IGameOverPresenter _gameOverPresenter;
        
        private const string HighScoreKey = "HighScore";
    
        private void Awake()
        {
            _scorePresenter = GetComponent<IScorePresenter>();
            _gameOverPresenter = GetComponent<IGameOverPresenter>();
        }

        private void Start()
        {
            collisionsChecker.OnCollectableHit += HandleCollectableHit;
            collisionsChecker.OnObstacleHit += GameOver;

            _scorePresenter.Score = _score;
            
            if (PlayerPrefs.HasKey(HighScoreKey))
            {
                _highScore = PlayerPrefs.GetInt(HighScoreKey);
            }
        }
        private void GameOver()
        {
            _gameOverPresenter.FinalScore = _score;
            _gameOverPresenter.PresentGameOver(TryUpdatingHighScore(_score));
            Destroy(snakeController);
        }

        private void HandleCollectableHit(ICollectable collectable)
        {
            _score += pointScoreValue;
            _scorePresenter.Score = _score;
        
            collectablesPlacer.PlaceCollectable();
            collectable.Collect();
        }

        private bool TryUpdatingHighScore(int newHighScore)
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