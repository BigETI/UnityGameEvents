using UnityGameEvents.Objects;
using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event invoker controller
    /// </summary>
    public interface IGameEventInvokerController : IController
    {
        /// <summary>
        /// Game event
        /// </summary>
        ABaseGameEventObjectScript GameEvent { get; set; }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        void Invoke();

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <typeparam name="T">Game event parameter type</typeparam>
        /// <param name="value">Game event parameter value</param>
        void Invoke<T>(T value);
    }
}
