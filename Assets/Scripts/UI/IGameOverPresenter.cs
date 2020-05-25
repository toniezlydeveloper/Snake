namespace UI
{
    public interface IGameOverPresenter : IScorePresenter
    {
        void PresentGameOver(bool wasHighScore);
    }
}