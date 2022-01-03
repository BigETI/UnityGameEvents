using UnityEngine;
using UnityPatterns.Objects;

/// <summary>
/// Unity game events objects namespace
/// </summary>
namespace UnityGameEvents.Objects
{
    /// <summary>
    /// An abstract class that describes a base game event object script
    /// </summary>
    public abstract class ABaseGameEventObjectScript : AObjectScript, IGameEventObject
    {
        /// <summary>
        /// Game event name
        /// </summary>
        [SerializeField]
        private string gameEventName = string.Empty;

#if UNITY_EDITOR
        /// <summary>
        /// Game event description
        /// </summary>
        [SerializeField]
        [TextArea]
        private string description = string.Empty;
#endif

        /// <summary>
        /// Game event name
        /// </summary>
        public string GameEventName => gameEventName ?? string.Empty;

#if UNITY_EDITOR
        /// <summary>
        /// Game event description
        /// </summary>
        public string Description => description ?? string.Empty;
#endif

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public abstract bool Invoke();
    }
}
