using System;
using System.Collections.Generic;

/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// A classs that provides functionalities for named game events
    /// </summary>
    public static class NamedGameEvents
    {
        /// <summary>
        /// Named game events
        /// </summary>
        private static readonly Dictionary<string, IDictionary<IGameEventObject, uint>> namedGameEvents = new Dictionary<string, IDictionary<IGameEventObject, uint>>();

        /// <summary>
        /// Registers the specified named game event
        /// </summary>
        /// <param name="namedGameEvent">Named game event</param>
        public static void RegisterNamedGameEvent(IGameEventObject namedGameEvent)
        {
            if (namedGameEvent == null)
            {
                throw new ArgumentNullException(nameof(namedGameEvent));
            }
            if (string.IsNullOrWhiteSpace(namedGameEvent.GameEventName))
            {
                throw new ArgumentException("Specified game event is not named.", nameof(namedGameEvent));
            }
            if (namedGameEvents.TryGetValue(namedGameEvent.GameEventName, out IDictionary<IGameEventObject, uint> named_game_events))
            {
                if (named_game_events.ContainsKey(namedGameEvent))
                {
                    ++named_game_events[namedGameEvent];
                }
                else
                {
                    named_game_events.Add(namedGameEvent, 1U);
                }
            }
            else
            {
                named_game_events = new Dictionary<IGameEventObject, uint> { { namedGameEvent, 1U } };
                namedGameEvents.Add(namedGameEvent.GameEventName, named_game_events);
            }
        }

        /// <summary>
        /// Unregisters the specified named game event
        /// </summary>
        /// <param name="namedGameEvent">Named game event</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool UnregisterNamedGameEvent(IGameEventObject namedGameEvent)
        {
            if (namedGameEvent == null)
            {
                throw new ArgumentNullException(nameof(namedGameEvent));
            }
            if (string.IsNullOrWhiteSpace(namedGameEvent.GameEventName))
            {
                throw new ArgumentException("Specified game event is not named.", nameof(namedGameEvent));
            }
            uint registration_count = default;
            bool ret = namedGameEvents.TryGetValue(namedGameEvent.GameEventName, out IDictionary<IGameEventObject, uint> named_game_events) && named_game_events.TryGetValue(namedGameEvent, out registration_count);
            if (ret)
            {
                --registration_count;
                if (registration_count > 0U)
                {
                    named_game_events[namedGameEvent] = registration_count;
                }
                else if (named_game_events.Remove(namedGameEvent) && (named_game_events.Count <= 0))
                {
                    namedGameEvents.Remove(namedGameEvent.GameEventName);
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the named game event registration count
        /// </summary>
        /// <param name="namedGameEvent">Named game event</param>
        /// <returns>Named game event registration count</returns>
        public static uint GetNamedGameEventRegistrationCount(IGameEventObject namedGameEvent)
        {
            if (namedGameEvent == null)
            {
                throw new ArgumentNullException(nameof(namedGameEvent));
            }
            if (string.IsNullOrWhiteSpace(namedGameEvent.GameEventName))
            {
                throw new ArgumentException("Specified game event is not named.", nameof(namedGameEvent));
            }
            return (namedGameEvents.TryGetValue(namedGameEvent.GameEventName, out IDictionary<IGameEventObject, uint> named_game_events) && named_game_events.TryGetValue(namedGameEvent, out uint ret)) ? ret : 0U;
        }

        /// <summary>
        /// Clears named game event registrations
        /// </summary>
        /// <param name="namedGameEvent">Named game event</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool ClearNamedGameEventRegistrations(IGameEventObject namedGameEvent)
        {
            if (namedGameEvent == null)
            {
                throw new ArgumentNullException(nameof(namedGameEvent));
            }
            if (string.IsNullOrWhiteSpace(namedGameEvent.GameEventName))
            {
                throw new ArgumentException("Specified game event is not named.", nameof(namedGameEvent));
            }
            bool ret = namedGameEvents.TryGetValue(namedGameEvent.GameEventName, out IDictionary<IGameEventObject, uint> named_game_events);
            if (ret && named_game_events.Remove(namedGameEvent) && (named_game_events.Count <= 0))
            {
                namedGameEvents.Remove(namedGameEvent.GameEventName);
            }
            return ret;
        }

        /// <summary>
        /// Invokes the specified named game event
        /// </summary>
        /// <param name="gameEventName">Game event name</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Invoke(string gameEventName)
        {
            if (string.IsNullOrWhiteSpace(gameEventName))
            {
                throw new ArgumentNullException(nameof(gameEventName));
            }
            bool ret = namedGameEvents.TryGetValue(gameEventName, out IDictionary<IGameEventObject, uint> named_game_events);
            if (ret)
            {
                foreach (IGameEventObject game_event in named_game_events.Keys)
                {
                    ret = game_event.Invoke() && ret;
                }
            }
            return ret;
        }

        /// <summary>
        /// Invokes the specified named game event
        /// </summary>
        /// <typeparam name="T">Game event parameter value type</typeparam>
        /// <param name="gameEventName">Game event name</param>
        /// <param name="value">Game event parameter value</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool Invoke<T>(string gameEventName, T value)
        {
            if (string.IsNullOrWhiteSpace(gameEventName))
            {
                throw new ArgumentNullException(nameof(gameEventName));
            }
            bool ret = namedGameEvents.TryGetValue(gameEventName, out IDictionary<IGameEventObject, uint> named_game_events);
            if (ret)
            {
                foreach (IGameEventObject game_event in named_game_events.Keys)
                {
                    if (game_event is IGameEventWithParameterObject<T> game_event_with_parameter)
                    {
                        ret = game_event_with_parameter.Invoke(value) && ret;
                    }
                }
            }
            return ret;
        }
    }
}
