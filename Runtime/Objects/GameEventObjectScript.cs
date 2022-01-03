using UnityEngine;

/// <summary>
/// Unity game events objects namespace
/// </summary>
namespace UnityGameEvents.Objects
{
    /// <summary>
    /// A class that describes a game event object script
    /// </summary>
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game events/Game event", order = -1)]
    public class GameEventObjectScript : ABaseGameEventObjectScript
    {
        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        public event GameEventInvokedDelegate OnGameEventInvoked;

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public override bool Invoke()
        {
            OnGameEventInvoked?.Invoke();
            return true;
        }
    }
}
