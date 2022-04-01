using UnityGameEvents.Objects;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents game event with parameter data
    /// </summary>
    /// <typeparam name="T">Game event parameter value type</typeparam>
    public interface IGameEventWithParameterData<T>
    {
        /// <summary>
        /// Game event
        /// </summary>
        AGameEventWithParameterObjectScript<T> GameEvent { get; set; }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        void Invoke(T value);
    }
}
