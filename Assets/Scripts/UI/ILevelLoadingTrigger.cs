using System;

namespace UI
{
    public interface ILevelLoadingTrigger
    {
        event Action<string> OnTrigger;
    }
}