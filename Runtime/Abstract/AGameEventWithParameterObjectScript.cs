/// <summary>
/// Unity game events objects namespace
/// </summary>
namespace UnityGameEvents.Objects
{
    /// <summary>
    /// An abstract class that describes a game event with parameter object script
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AGameEventWithParameterObjectScript<T> : ABaseGameEventObjectScript, IGameEventWithParameterObject<T>
    {
        /// <summary>
        /// Gets invoked when game event with parameter has been invoked
        /// </summary>
        public event GameEventWithParameterInvokedDelegate<T> OnGameEventWithParameterInvoked;

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public override bool Invoke() => false;

        /// <summary>
        /// Invokes this game event
        /// </summary>
        /// <param name="value">Game event parameter value</param>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public virtual bool Invoke(T value)
        {
            bool ret = false;
            if (value != null)
            {
                OnGameEventWithParameterInvoked?.Invoke(value);
                ret = true;
            }
            return ret;
        }
    }
}
