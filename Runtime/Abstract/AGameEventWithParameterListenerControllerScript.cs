using UnityEngine;
using UnityEngine.Events;
using UnityGameEvents.Objects;
using UnityPatterns.Controllers;

/// <summary>
/// Unity game events controllers namespace
/// </summary>
namespace UnityGameEvents.Controllers
{
    /// <summary>
    /// An abstract class that describes a game event with parameter listener controller script
    /// </summary>
    /// <typeparam name="TGameEvent">Game event type</typeparam>
    /// <typeparam name="TParameter">Game event parameter type</typeparam>
    public abstract class AGameEventWithParameterListenerControllerScript<TGameEvent, TParameter> : AControllerScript, IGameEventWithParameterListenerController<TGameEvent, TParameter> where TGameEvent : AGameEventWithParameterObjectScript<TParameter>
    {
        /// <summary>
        /// Game event
        /// </summary>
        [SerializeField]
        private TGameEvent gameEvent = default;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        [SerializeField]
        private UnityEvent<TParameter> onGameEventInvoked = default;

        /// <summary>
        /// Registered game event
        /// </summary>
        public TGameEvent RegisteredGameEvent { get; private set; }

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        public event GameEventWithParameterInvokedDelegate<TParameter> OnGameEventInvoked;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        /// <param name="value">Game event parameter value</param>
        private void GameEventInvokedEvent(TParameter value)
        {
            if (onGameEventInvoked != null)
            {
                onGameEventInvoked.Invoke(value);
            }
            OnGameEventInvoked?.Invoke(value);
        }

        /// <summary>
        /// Gets invoked when script has been initialized
        /// </summary>
        protected virtual void Awake()
        {
            if (gameEvent)
            {
                RegisteredGameEvent = gameEvent;
                gameEvent.OnGameEventWithParameterInvoked += GameEventInvokedEvent;
            }
            else
            {
                Debug.LogError("Please assign a game event to this game event listener.", this);
            }
        }

        /// <summary>
        /// Gets invoked when script has been destroyed
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (RegisteredGameEvent)
            {
                RegisteredGameEvent.OnGameEventWithParameterInvoked -= GameEventInvokedEvent;
                RegisteredGameEvent = null;
            }
        }
    }
}
