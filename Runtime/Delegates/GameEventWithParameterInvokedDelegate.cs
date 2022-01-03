/// <summary>
/// Unity game events namespace
/// </summary>
namespace UnityGameEvents
{
    /// <summary>
    /// Used to invoke when game event with parameter has been invoked
    /// </summary>
    /// <typeparam name="T">Game event parameter value type</typeparam>
    /// <param name="value">Game event parameter value</param>
    public delegate void GameEventWithParameterInvokedDelegate<T>(T value);
}
