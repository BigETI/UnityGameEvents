using UnityEngine;

/// <summary>
/// Unity game events editor namespace
/// </summary>
namespace UnityGameEventsEditor
{
    /// <summary>
    /// An interface that represents a generate game event classes editor window
    /// </summary>
    public interface IGenerateGameEventClassesEditorWindow
    {
        /// <summary>
        /// Scroll position
        /// </summary>
        Vector2 ScrollPosition { get; set; }

        /// <summary>
        /// Directory path
        /// </summary>
        string DirectoryPath { get; set; }

        /// <summary>
        /// Controller script name
        /// </summary>
        string ControllerScriptName { get; set; }

        /// <summary>
        /// Controller script accessibility
        /// </summary>
        EAccessibility ControllerScriptAccessibility { get; set; }

        /// <summary>
        /// Object script name
        /// </summary>
        string ObjectScriptName { get; set; }

        /// <summary>
        /// Object script accessibility
        /// </summary>
        EAccessibility ObjectScriptAccessibility { get; set; }

        /// <summary>
        /// Base namespace name
        /// </summary>
        string BaseNamespaceName { get; set; }

        /// <summary>
        /// Controller namespace name
        /// </summary>
        string ControllerScriptNamespaceName { get; set; }

        /// <summary>
        /// Object script namespace name
        /// </summary>
        string ObjectScriptNamespaceName { get; set; }

        /// <summary>
        /// Is generating interfaces
        /// </summary>
        bool IsGeneratingInterfaces { get; set; }

        /// <summary>
        /// Controller interface name
        /// </summary>
        string ControllerInterfaceName { get; set; }

        /// <summary>
        /// Controller interface accessibility
        /// </summary>
        EAccessibility ControllerInterfaceAccessibility { get; set; }

        /// <summary>
        /// Object interface name
        /// </summary>
        string ObjectInterfaceName { get; set; }

        /// <summary>
        /// Object interface accessibility
        /// </summary>
        EAccessibility ObjectInterfaceAccessibility { get; set; }

        /// <summary>
        /// Controller interface namespace name
        /// </summary>
        string ControllerInterfaceNamespaceName { get; set; }

        /// <summary>
        /// Object interface namespace name
        /// </summary>
        string ObjectInterfaceNamespaceName { get; set; }

        /// <summary>
        /// Relative controller script directory path
        /// </summary>
        string RelativeControllerScriptDirectoryPath { get; set; }

        /// <summary>
        /// Relative object script directory path
        /// </summary>
        string RelativeObjectScriptDirectoryPath { get; set; }

        /// <summary>
        /// Relative controller interface directory path
        /// </summary>
        string RelativeControllerInterfaceDirectoryPath { get; set; }

        /// <summary>
        /// Relative object interface directory path
        /// </summary>
        string RelativeObjectInterfaceDirectoryPath { get; set; }
    }
}
