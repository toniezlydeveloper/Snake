using UI;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SnakeController snakeController;
        [SerializeField] private CollisionsChecker collisionsChecker;
        [SerializeField] private PointPlacer pointPlacer;
        [SerializeField] private int pointScoreValue;

        private int _score;
        private IScorePresenter _scorePresenter;
    
        private void Awake()
        {
            _scorePresenter = GetComponent<IScorePresenter>();
        }

        private void Start()
        {
            collisionsChecker.OnObstacleHit += GameOver;
            collisionsChecker.OnPointHit += HandlePointHit;

            _scorePresenter.Score = _score;
        }

        private void GameOver()
        {
            Destroy(snakeController);
        }

        private void HandlePointHit(GameObject point)
        {
            _score += pointScoreValue;
            _scorePresenter.Score = _score;
        
            pointPlacer.PlaceNextPoint();
            snakeController.Expand();
            Destroy(point);
        }
    }
}