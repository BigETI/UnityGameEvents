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
    /// A structure that describes game event data
    /// </summary>
    [Serializable]
    public struct GameEventData : IGameEventData
    {
        /// <summary>
        /// Game event
        /// </summary>
        [SerializeField]
        private GameEventObjectScript gameEvent;

        /// <summary>
        /// Gets invoked when game event has been invoked
        /// </summary>
        [SerializeField]
        private UnityEvent onGameEventInvoked;

        /// <summary>
        /// Game event
        /// </summary>
        public GameEventObjectScript GameEvent
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
                gameEvent.Invoke();
            }
            if (onGameEventInvoked != null)
            {
                onGameEventInvoked.Invoke();
            }
        }
    }
}
