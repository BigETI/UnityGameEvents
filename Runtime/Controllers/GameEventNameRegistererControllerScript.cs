using UnityEngine;
using UnityGameEvents.Objects;
using UnityPatterns.Controllers;

/// <summary>
/// Unity game events controllers namespace
/// </summary>
namespace UnityGameEvents.Controllers
{
    /// <summary>
    /// A class that describes a game event name registerer controller script
    /// </summary>
    public class GameEventNameRegistererControllerScript : AControllerScript, IGameEventNameRegistererController
    {
        /// <summary>
        /// Game event
        /// </summary>
        [SerializeField]
        private ABaseGameEventObjectScript gameEvent = default;

        /// <summary>
        /// Game event
        /// </summary>
        public ABaseGameEventObjectScript GameEvent
        {
            get => gameEvent;
            set
            {
                if (gameEvent != value)
                {
                    gameEvent = value;
                    if (RegisteredGameEvent)
                    {
                        NamedGameEvents.UnregisterNamedGameEvent(RegisteredGameEvent);
                        RegisteredGameEvent = null;
                    }
                    if (IsInitialized && gameEvent && !string.IsNullOrWhiteSpace(gameEvent.GameEventName))
                    {
                        NamedGameEvents.RegisterNamedGameEvent(gameEvent);
                        RegisteredGameEvent = gameEvent;
                    }
                }
            }
        }

        /// <summary>
        /// Registered game event
        /// </summary>
        public ABaseGameEventObjectScript RegisteredGameEvent { get; private set; }

        /// <summary>
        /// Is this script initialized
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Gets invoked when script needs to be initialized
        /// </summary>
        protected virtual void Awake()
        {
            if (gameEvent)
            {
                if (string.IsNullOrWhiteSpace(gameEvent.GameEventName))
                {
                    Debug.LogError($"Game event \"{ gameEvent.name }\" does not have an event name assigned to it.", this);
                }
                else
                {
                    NamedGameEvents.RegisterNamedGameEvent(gameEvent);
                    RegisteredGameEvent = gameEvent;
                }
            }
            else
            {
                Debug.LogError($"Please assign a game event to this game event registerer.", this);
            }
            IsInitialized = true;
        }

        /// <summary>
        /// Gets invoked when script needs to be destroyed
        /// </summary>
        protected virtual void OnDestroy()
        {
            IsInitialized = false;
            if (RegisteredGameEvent)
            {
                NamedGameEvents.UnregisterNamedGameEvent(RegisteredGameEvent);
            }
        }
    }
}
