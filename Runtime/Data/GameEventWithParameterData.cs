using System;
using UnityEngine;
using UnityEngine.Events;
using UnityGameEvents.Objects;

/// <summary>
/// Unity game events data namespace
/// </summary>
namespace UnityGameEvents.Data
{
    /// <summary>
    /// A structure that describes game event with parameter data
    /// </summary>
    /// <typeparam name="T">Game event parameter value type</typeparam>
    [Serializable]
    public struct GameEventWithParameterData<T> : IGameEventWithParameterData<T>
    {
        /// <summary>
        /// Game event
        /// </summary>
        [SerializeField]
        private AGameEventWithParameterObjectScript<T> gameEvent;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        [SerializeField]
        private UnityEvent<T> onGameEventInvoked;

        /// <summary>
        /// Game event
        /// </summary>
        public AGameEventWithParameterObjectScript<T> GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        /// <summary>
        /// Invokes this game event
        /// </summary>
        public void Invoke(T value)
        {
            if (gameEvent)
            {
                gameEvent.Invoke(value);
            }
            if (onGameEventInvoked != null)
            {
                onGameEventInvoked.Invoke(value);
            }
        }
    }
}
