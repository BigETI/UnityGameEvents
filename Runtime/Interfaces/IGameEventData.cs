using UnityGameEvents.Objects;

/// <summary>
/// Unity game events data namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents game event data
    /// </summary>
    public interface IGameEventData
    {
        /// <summary>
        /// Game event
        /// </summary>
        GameEventObjectScript GameEvent { get; set; }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        void Invoke();
    }
}
