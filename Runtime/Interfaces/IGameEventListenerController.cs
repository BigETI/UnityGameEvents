using UnityGameEvents.Objects;
using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event listener controller
    /// </summary>
    public interface IGameEventListenerController : IController
    {
        /// <summary>
        /// Registered game events
        /// </summary>
        GameEventObjectScript RegisteredGameEvent { get; }

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        event GameEventInvokedDelegate OnGameEventInvoked;
    }
}
