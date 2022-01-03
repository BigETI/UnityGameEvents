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
    /// A class that describes a game event listener controller script
    /// </summary>
    public class GameEventListenerControllerScript : AControllerScript, IGameEventListenerController
    {
        /// <summary>
        /// game event
        /// </summary>
        [SerializeField]
        private GameEventObjectScript gameEvent = default;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        [SerializeField]
        private UnityEvent onGameEventInvoked = default;

        /// <summary>
        /// Registered game events
        /// </summary>
        public GameEventObjectScript RegisteredGameEvent { get; private set; }

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        public event GameEventInvokedDelegate OnGameEventInvoked;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        private void GameEventInvokedEvent()
        {
            if (onGameEventInvoked != null)
            {
                onGameEventInvoked.Invoke();
            }
            OnGameEventInvoked?.Invoke();
        }

        /// <summary>
        /// Gets invoked when script need to be initialized
        /// </summary>
        protected virtual void Awake()
        {
            if (gameEvent)
            {
                RegisteredGameEvent = gameEvent;
                gameEvent.OnGameEventInvoked += GameEventInvokedEvent;
            }
            else
            {
                Debug.LogError("Please assign a game event to this game event listener.", this);
            }
        }

        /// <summary>
        /// Gets invoked when script need to be destroyed
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (RegisteredGameEvent)
            {
                RegisteredGameEvent.OnGameEventInvoked -= GameEventInvokedEvent;
                RegisteredGameEvent = null;
            }
        }
    }
}
