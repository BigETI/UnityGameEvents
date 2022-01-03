using UnityGameEvents.Objects;
using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event name registerer controller
    /// </summary>
    public interface IGameEventNameRegistererController : IController
    {
        /// <summary>
        /// Game event
        /// </summary>
        ABaseGameEventObjectScript GameEvent { get; set; }

        /// <summary>
        /// Registered game event
        /// </summary>
        ABaseGameEventObjectScript RegisteredGameEvent { get; }

        /// <summary>
        /// Is this script initialized
        /// </summary>
        bool IsInitialized { get; }
    }
}
