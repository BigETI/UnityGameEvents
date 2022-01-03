using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event name invoker controller
    /// </summary>
    public interface IGameEventNameInvokerController : IController
    {
        /// <summary>
        /// Game event name
        /// </summary>
        string GameEventName { get; set; }

        /// <summary>
        /// Invokes this named game event
        /// </summary>
        void Invoke();

        /// <summary>
        /// Invokes this named game event
        /// </summary>
        /// <typeparam name="T">Named game event parameter value type</typeparam>
        /// <param name="value">Named game event parameter value</param>
        void Invoke<T>(T value);
    }
}
