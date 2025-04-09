using UnityEngine;

namespace Platformer397
{
    public interface IAgent
    {
        void Navigate(Vector3 destination);
        void CompleteJob();
    }
}
