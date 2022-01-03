using UnityPatterns;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// An interface that represents a game event with parameter listener controller
    /// </summary>
    /// <typeparam name="TGameEvent">Game event type</typeparam>
    /// <typeparam name="TParameter">Game event parameter type</typeparam>
    public interface IGameEventWithParameterListenerController<TGameEvent, TParameter> : IController where TGameEvent : IGameEventWithParameterObject<TParameter>
    {
        /// <summary>
        /// Registered game event
        /// </summary>
        TGameEvent RegisteredGameEvent { get; }

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        event GameEventWithParameterInvokedDelegate<TParameter> OnGameEventInvoked;
    }
}
