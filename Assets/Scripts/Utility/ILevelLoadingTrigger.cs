using System;

namespace Utility
{
    public interface ILevelLoadingTrigger
    {
        event Action<string> OnTrigger;
    }
}