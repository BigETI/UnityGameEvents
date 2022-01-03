using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event object
    /// </summary>
    public interface IGameEventObject : IObject
    {
        /// <summary>
        /// Game event name
        /// </summary>
        string GameEventName { get; }

#if UNITY_EDITOR
        /// <summary>
        /// Game event description
        /// </summary>
        string Description { get; }
#endif
        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        bool Invoke();
    }
}
