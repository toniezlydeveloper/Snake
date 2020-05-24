using Collectables;
using Obstacles;
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
        private IScorePresenter _scorePresenter;
        private IGameOverPresenter _gameOverPresenter;
    
        private void Awake()
        {
            _scorePresenter = GetComponent<IScorePresenter>();
            _gameOverPresenter = GetComponent<IGameOverPresenter>();
        }

        private void Start()
        {
            collisionsChecker.OnObstacleHit += GameOver;
            collisionsChecker.OnCollectableHit += HandleCollectableHit;

            _scorePresenter.Score = _score;
        }

        private void GameOver(IObstacle obstacle)
        {
            if (!obstacle.Interact())
            {
                return;
            }
            
            _gameOverPresenter.FinalScore = _score;
            _gameOverPresenter.PresentGameOver();
            Destroy(snakeController);
        }

        private void HandleCollectableHit(ICollectable collectable)
        {
            _score += pointScoreValue;
            _scorePresenter.Score = _score;
        
            collectablesPlacer.PlaceCollectable();
            collectable.Collect();
        }
    }
}