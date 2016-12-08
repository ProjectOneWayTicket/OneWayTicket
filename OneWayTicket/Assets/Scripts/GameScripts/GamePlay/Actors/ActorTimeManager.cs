using PACE.Framework.Time;

namespace Gameplay.Actors
{
    public class ActorTimeManager : Singleton<ActorTimeManager>
    {
        protected ActorTimeManager() { }
        TimeManager _timeManager;
        public TimeManager TimeManager
        {
            get
            {
                if (_timeManager == null)
                    _timeManager = new TimeManager();
                return _timeManager;
            }
        }
    }
}
