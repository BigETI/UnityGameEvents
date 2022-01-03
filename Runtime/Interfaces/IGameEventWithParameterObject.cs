/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event with parameter object
    /// </summary>
    /// <typeparam name="T">Game event parameter value type</typeparam>
    public interface IGameEventWithParameterObject<T> : IGameEventObject
    {
        /// <summary>
        /// Gets invoked when game event with parameter has been invoked
        /// </summary>
        event GameEventWithParameterInvokedDelegate<T> OnGameEventWithParameterInvoked;

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <param name="value">Game event parameter value</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        bool Invoke(T value);
    }
}
