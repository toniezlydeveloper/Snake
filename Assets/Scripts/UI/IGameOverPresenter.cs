namespace UI
{
    public interface IGameOverPresenter
    {
        int FinalScore { set; }

        void PresentGameOver(bool wasHighScore);
    }
}