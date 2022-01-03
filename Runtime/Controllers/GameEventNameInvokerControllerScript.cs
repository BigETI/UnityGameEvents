using System;
using UnityEngine;
using UnityPatterns.Controllers;

/// <summary>
/// Unity game events controllers namespace
/// </summary>
namespace UnityGameEvents.Controllers
{
    /// <summary>
    /// A class that describes a game event invoker controller script
    /// </summary>
    public class GameEventNameInvokerControllerScript : AControllerScript, IGameEventNameInvokerController
    {
        /// <summary>
        /// Game event name
        /// </summary>
        [SerializeField]
        private string gameEventName = string.Empty;

        /// <summary>
        /// Game event name
        /// </summary>
        public string GameEventName
        {
            get => gameEventName ??= string.Empty;
            set => gameEventName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Invokes this named game event
        /// </summary>
        public void Invoke()
        {
            if (!NamedGameEvents.Invoke(GameEventName))
            {
                Debug.LogError($"Failed to invoke game event \"{ gameEventName }\".", this);
            }
        }

        /// <summary>
        /// Invokes this named game event
        /// </summary>
        /// <typeparam name="T">Named game event parameter value type</typeparam>
        /// <param name="value">Named game event parameter value</param>
        public void Invoke<T>(T value)
        {
            if (!NamedGameEvents.Invoke(GameEventName, value))
            {
                Debug.LogError($"Failed to invoke game event \"{ gameEventName }\".", this);
            }
        }
    }
}
