using UnityEngine;
using UnityGameEvents.Objects;
using UnityPatterns.Controllers;

/// <summary>
/// Unity game events controllers namespace
/// </summary>
namespace UnityGameEvents.Controllers
{
    /// <summary>
    /// A class that describes a game event invoker controller script
    /// </summary>
    public class GameEventInvokerControllerScript : AControllerScript, IGameEventInvokerController
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
            set => gameEvent = value;
        }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        public void Invoke()
        {
            if (gameEvent)
            {
                if (!gameEvent.Invoke())
                {
                    Debug.LogError("Failed to invoke game event.", this);
                }
            }
            else
            {
                Debug.LogError("Please assign a game event to this game event invoker controller.", this);
            }
        }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <typeparam name="T">Game event parameter type</typeparam>
        /// <param name="value">Game event parameter value</param>
        public void Invoke<T>(T value)
        {
            if (gameEvent)
            {
                if (gameEvent is AGameEventWithParameterObjectScript<T> game_event_with_parameter)
                {
                    game_event_with_parameter.Invoke(value);
                }
                else
                {
                    Debug.LogError($"Type \"{ typeof(T).FullName }\" does not match the parameter type with this game event.", this);
                }
            }
            else
            {
                Debug.LogError("Please assign a game event to this game event invoker controller.", this);
            }
        }
    }
}
