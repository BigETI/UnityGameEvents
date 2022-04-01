using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Unity game events editor editor windows namespace
/// </summary>
namespace UnityGameEventsEditor.EditorWindows
{
    /// <summary>
    /// A class that describes a generate game event classes editor window script
    /// </summary>
    public class GenerateGameEventClassesEditorWindowScript : EditorWindow, IGenerateGameEventClassesEditorWindow
    {
        /// <summary>
        /// Allowed classes
        /// </summary>
        private static IReadOnlyList<Type> allowedClasses;

        /// <summary>
        /// Allowed enumerators
        /// </summary>
        private static IReadOnlyList<Type> allowedEnumerators;
        
        /// <summary>
        /// Allowed interfaces
        /// </summary>
        private static IReadOnlyList<Type> allowedInterfaces;

        /// <summary>
        /// Allowed value types
        /// </summary>
        private static IReadOnlyList<Type> allowedValueTypes;

        /// <summary>
        /// Allowed type names
        /// </summary>
        private static string[] allowedTypeNames;

        /// <summary>
        /// Directory path
        /// </summary>
        private string directoryPath = string.Empty;

        /// <summary>
        /// Controller script name
        /// </summary>
        private string controllerScriptName = string.Empty;

        /// <summary>
        /// Controller script accessibility
        /// </summary>
        private EAccessibility controllerScriptAccessibility = EAccessibility.Public;

        /// <summary>
        /// Object script name
        /// </summary>
        private string objectScriptName = string.Empty;

        /// <summary>
        /// Object script accessibility
        /// </summary>
        private EAccessibility objectScriptAccessibility = EAccessibility.Public;

        /// <summary>
        /// Base namespace name
        /// </summary>
        private string baseNamespaceName = "MyNamespace";

        /// <summary>
        /// Controller script namespace name
        /// </summary>
        private string controllerScriptNamespaceName = string.Empty;

        /// <summary>
        /// Object script namespace name
        /// </summary>
        private string objectScriptNamespaceName = string.Empty;

        /// <summary>
        /// Is generating interfaces
        /// </summary>
        private bool isGeneratingInterfaces = true;

        /// <summary>
        /// Controller interface name
        /// </summary>
        private string controllerInterfaceName = string.Empty;

        /// <summary>
        /// Controller interface accessibility
        /// </summary>
        private EAccessibility controllerInterfaceAccessibility = EAccessibility.Public;

        /// <summary>
        /// Object interface name
        /// </summary>
        private string objectInterfaceName = string.Empty;

        /// <summary>
        /// Object interface accessibility
        /// </summary>
        private EAccessibility objectInterfaceAccessibility = EAccessibility.Public;

        /// <summary>
        /// Controller interface namespace name
        /// </summary>
        private string controllerInterfaceNamespaceName = "MyNamespace";

        /// <summary>
        /// Object interface namespace name
        /// </summary>
        private string objectInterfaceNamespaceName = "MyNamespace";

        /// <summary>
        /// Relative controller script directory path
        /// </summary>
        private string relativeControllerScriptDirectoryPath = "Controllers";

        /// <summary>
        /// Relative object script directory path
        /// </summary>
        private string relativeObjectScriptDirectoryPath = "Objects";

        /// <summary>
        /// Relative controller interface directory path
        /// </summary>
        private string relativeControllerInterfaceDirectoryPath = "Interfaces";

        /// <summary>
        /// Relative object interface directory path
        /// </summary>
        private string relativeObjectInterfaceDirectoryPath = "Interfaces";

        /// <summary>
        /// Selected allowed type index
        /// </summary>
        private int selectedAllowedTypeIndex = -1;

        /// <summary>
        /// Last selected allowed type index
        /// </summary>
        private int lastSelectedAllowedTypeIndex = -1;

        /// <summary>
        /// Last base namespace
        /// </summary>
        private string lastBaseNamespace = string.Empty;

        /// <summary>
        /// Scroll position
        /// </summary>
        public Vector2 ScrollPosition { get; set; }

        /// <summary>
        /// Directory path
        /// </summary>
        public string DirectoryPath
        {
            get => directoryPath;
            set => directoryPath = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        /// <summary>
        /// Controller script name
        /// </summary>
        public string ControllerScriptName
        {
            get => controllerScriptName;
            set => controllerScriptName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Controller script accessibility
        /// </summary>
        public EAccessibility ControllerScriptAccessibility
        {
            get => controllerScriptAccessibility;
            set => controllerScriptAccessibility = value;
        }

        /// <summary>
        /// Object script name
        /// </summary>
        public string ObjectScriptName
        {
            get => objectScriptName;
            set => objectScriptName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Object script accessibility
        /// </summary>
        public EAccessibility ObjectScriptAccessibility
        {
            get => objectScriptAccessibility;
            set => objectScriptAccessibility = value;
        }

        /// <summary>
        /// Base namespace name
        /// </summary>
        public string BaseNamespaceName
        {
            get => baseNamespaceName;
            set => baseNamespaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Controller namespace name
        /// </summary>
        public string ControllerScriptNamespaceName
        {
            get => controllerScriptNamespaceName;
            set => controllerScriptNamespaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Object script namespace name
        /// </summary>
        public string ObjectScriptNamespaceName
        {
            get => objectScriptNamespaceName;
            set => objectScriptNamespaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Is generating interfaces
        /// </summary>
        public bool IsGeneratingInterfaces
        {
            get => isGeneratingInterfaces;
            set => isGeneratingInterfaces = value;
        }

        /// <summary>
        /// Controller interface name
        /// </summary>
        public string ControllerInterfaceName
        {
            get => controllerInterfaceName;
            set => controllerInterfaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Controller interface accessibility
        /// </summary>
        public EAccessibility ControllerInterfaceAccessibility
        {
            get => controllerInterfaceAccessibility;
            set => controllerInterfaceAccessibility = value;
        }

        /// <summary>
        /// Object interface name
        /// </summary>
        public string ObjectInterfaceName
        {
            get => objectInterfaceName;
            set => objectInterfaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Object interface accessibility
        /// </summary>
        public EAccessibility ObjectInterfaceAccessibility
        {
            get => objectInterfaceAccessibility;
            set => objectInterfaceAccessibility = value;
        }

        /// <summary>
        /// Controller interface namespace name
        /// </summary>
        public string ControllerInterfaceNamespaceName
        {
            get => controllerInterfaceNamespaceName;
            set => controllerInterfaceNamespaceName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Object interface namespace name
        /// </summary>
        public string ObjectInterfaceNamespaceName
        {
            get => objectInterfaceNamespaceName;
            set => objectInterfaceNamespaceName = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        /// <summary>
        /// Relative controller script directory path
        /// </summary>
        public string RelativeControllerScriptDirectoryPath
        {
            get => relativeControllerScriptDirectoryPath;
            set => relativeControllerScriptDirectoryPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Relative object script directory path
        /// </summary>
        public string RelativeObjectScriptDirectoryPath
        {
            get => relativeObjectScriptDirectoryPath;
            set => relativeObjectScriptDirectoryPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Relative controller interface directory path
        /// </summary>
        public string RelativeControllerInterfaceDirectoryPath
        {
            get => relativeControllerInterfaceDirectoryPath;
            set => relativeControllerInterfaceDirectoryPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Relative object interface directory path
        /// </summary>
        public string RelativeObjectInterfaceDirectoryPath
        {
            get => relativeObjectInterfaceDirectoryPath;
            set => relativeObjectInterfaceDirectoryPath = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Shows a "New game event classes" window
        /// </summary>
        [MenuItem("Assets/Create/Game events/New game event classes")]
        private static void ShowNewGameEventClassesWindow()
        {
            GenerateGameEventClassesEditorWindowScript generate_game_event_classes_editor_window = GetWindow<GenerateGameEventClassesEditorWindowScript>(true, "Generate game event classes", true);
            if (generate_game_event_classes_editor_window)
            {
                string directory_path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
                if (directory_path.Contains("."))
                {
                    directory_path = directory_path.Remove(directory_path.LastIndexOf('/'));
                }
                generate_game_event_classes_editor_window.DirectoryPath = directory_path;
            }
        }

        /// <summary>
        /// Appends required namespace names
        /// </summary>
        /// <param name="stringBuilder">String builder</param>
        /// <param name="currentNamespaceName">Current namespace name</param>
        /// <param name="usingNamespaceNames">Using namespace names</param>
        private static void AppendRequiredNamespaceNames(StringBuilder stringBuilder, string currentNamespaceName, params string[] usingNamespaceNames)
        {
            List<string> using_namespaces = new List<string>();
            foreach (string using_namespace_name in usingNamespaceNames)
            {
                if (!currentNamespaceName.StartsWith(using_namespace_name) && !using_namespaces.Contains(using_namespace_name))
                {
                    using_namespaces.Add(using_namespace_name);
                }
            }
            using_namespaces.Sort();
            foreach (string using_namespace in using_namespaces)
            {
                stringBuilder.Append("using ");
                stringBuilder.Append(using_namespace);
                stringBuilder.AppendLine(";");
            }
            if (using_namespaces.Count > 0)
            {
                stringBuilder.AppendLine();
            }
            using_namespaces.Clear();
        }

        /// <summary>
        /// Get squished type name
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Squished type name</returns>
        private static string GetSquishedTypeName(Type type) => type.FullName.Replace(".", string.Empty).Replace("+", string.Empty).Replace("´", string.Empty).Replace("`", string.Empty);

        /// <summary>
        /// Creates a script asset
        /// </summary>
        /// <param name="resourcePath">Resource path</param>
        /// <param name="contents">Script contents</param>
        private static void CreateScriptAsset(string resourcePath, string contents)
        {
            string path = Path.Combine(Environment.CurrentDirectory, $"{ resourcePath }.cs");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using FileStream file_stream = File.OpenWrite(path);
            using StreamWriter stream_writer = new StreamWriter(file_stream);
            stream_writer.Write(contents);
        }

        /// <summary>
        /// Gets invoked when GUI needs to be drawn
        /// </summary>
        private void OnGUI()
        {
            ScrollPosition = EditorGUILayout.BeginScrollView(ScrollPosition);
            EditorGUILayout.LabelField("Directory path", directoryPath);
            if ((allowedClasses == null) || (allowedEnumerators == null) || (allowedInterfaces == null) || (allowedValueTypes == null))
            {
                List<Type> allowed_classes = new List<Type>();
                List<Type> allowed_enumerators = new List<Type>();
                List<Type> allowed_interfaces = new List<Type>();
                List<Type> allowed_value_types = new List<Type>();
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsEnum)
                        {
                            allowed_enumerators.Add(type);
                        }
                        else if (type.IsInterface)
                        {
                            allowed_interfaces.Add(type);
                        }
                        else if (type.IsClass || type.IsValueType)
                        {
                            if (typeof(IFormattable).IsAssignableFrom(type) || typeof(UnityEngine.Object).IsAssignableFrom(type))
                            {
                                (type.IsClass ? allowed_classes : allowed_value_types).Add(type);
                            }
                            else
                            {
                                foreach (CustomAttributeData custom_attribute_data in type.CustomAttributes)
                                {
                                    if (typeof(SerializableAttribute).IsAssignableFrom(custom_attribute_data.AttributeType))
                                    {
                                        (type.IsClass ? allowed_classes : allowed_value_types).Add(type);
                                    }
                                }
                            }
                        }
                    }
                }
                allowed_classes.Sort((Type left, Type right) => left.FullName.CompareTo(right.FullName));
                allowed_enumerators.Sort((Type left, Type right) => left.FullName.CompareTo(right.FullName));
                allowed_interfaces.Sort((Type left, Type right) => left.FullName.CompareTo(right.FullName));
                allowed_value_types.Sort((Type left, Type right) => left.FullName.CompareTo(right.FullName));
                allowedClasses = allowed_classes;
                allowedEnumerators = allowed_enumerators;
                allowedInterfaces = allowed_interfaces;
                allowedValueTypes = allowed_value_types;
                allowedTypeNames = new string[allowed_classes.Count + allowed_enumerators.Count + allowed_interfaces.Count + allowed_value_types.Count];
                for (int index = 0; index < allowedClasses.Count; index++)
                {
                    Type allowed_class = allowed_classes[index];
                    allowedTypeNames[index] = $"Classes/{ allowed_class.FullName.Replace('.', '/') }";
                }
                for (int index = 0; index < allowedEnumerators.Count; index++)
                {
                    Type allowed_enumerator = allowed_enumerators[index];
                    allowedTypeNames[allowedClasses.Count + index] = $"Enumerators/{ allowed_enumerator.FullName.Replace('.', '/') }";
                }
                for (int index = 0; index < allowedInterfaces.Count; index++)
                {
                    Type allowed_interface = allowed_interfaces[index];
                    allowedTypeNames[allowedClasses.Count + allowedEnumerators.Count + index] = $"Interfaces/{ allowed_interface.FullName.Replace('.', '/') }";
                }
                for (int index = 0; index < allowedValueTypes.Count; index++)
                {
                    Type allowed_value_type = allowed_value_types[index];
                    allowedTypeNames[allowedClasses.Count + allowedEnumerators.Count + allowedInterfaces.Count + index] = $"Value types/{ allowed_value_type.FullName.Replace('.', '/') }";
                }
            }
            selectedAllowedTypeIndex = EditorGUILayout.Popup("Type", selectedAllowedTypeIndex, allowedTypeNames);
            EditorGUILayout.Space();
            if ((selectedAllowedTypeIndex < 0) || (selectedAllowedTypeIndex >= allowedTypeNames.Length))
            {
                EditorGUILayout.LabelField("Please select a type to generate game event classes for.");
            }
            else
            {
                Type type =
                    (selectedAllowedTypeIndex < allowedClasses.Count) ?
                        allowedClasses[selectedAllowedTypeIndex] :
                        (
                            ((selectedAllowedTypeIndex - allowedClasses.Count) < allowedEnumerators.Count) ?
                                allowedEnumerators[selectedAllowedTypeIndex - allowedClasses.Count] :
                                (
                                    ((selectedAllowedTypeIndex - allowedClasses.Count - allowedEnumerators.Count) < allowedInterfaces.Count) ?
                                        allowedInterfaces[selectedAllowedTypeIndex - allowedClasses.Count - allowedEnumerators.Count] :
                                        allowedValueTypes[selectedAllowedTypeIndex - allowedClasses.Count - allowedEnumerators.Count - allowedInterfaces.Count]
                                )
                        );
                if (lastSelectedAllowedTypeIndex != selectedAllowedTypeIndex)
                {
                    lastSelectedAllowedTypeIndex = selectedAllowedTypeIndex;
                    string squished_type_name = GetSquishedTypeName(type);
                    controllerScriptName = $"{ squished_type_name }GameEventListenerControllerScript";
                    objectScriptName = $"{ squished_type_name }GameEventListenerObjectScript";
                    controllerInterfaceName = $"I{ squished_type_name }GameEventListenerController";
                    objectInterfaceName = $"I{ squished_type_name }GameEventListenerObject";
                }
                if (lastBaseNamespace != baseNamespaceName)
                {
                    lastBaseNamespace = baseNamespaceName;
                    string prefix = (baseNamespaceName.Length > 0) ? $"{ baseNamespaceName }." : string.Empty;
                    controllerScriptNamespaceName = $"{ prefix }Controllers";
                    objectScriptNamespaceName = $"{ prefix }Objects";
                    controllerInterfaceNamespaceName = baseNamespaceName;
                    objectInterfaceNamespaceName = baseNamespaceName;
                }
                EditorGUILayout.LabelField("Type", type.FullName);
                EditorGUILayout.Space();
                controllerScriptName = EditorGUILayout.TextField("Controller script name", controllerScriptName.Trim());
                controllerScriptAccessibility = (EAccessibility)EditorGUILayout.EnumPopup("Accessibility", controllerScriptAccessibility);
                EditorGUILayout.Space();
                objectScriptName = EditorGUILayout.TextField("Object script name", objectScriptName.Trim());
                objectScriptAccessibility = (EAccessibility)EditorGUILayout.EnumPopup("Accessibility", objectScriptAccessibility);
                EditorGUILayout.Space();
                baseNamespaceName = EditorGUILayout.TextField("Base namespace", baseNamespaceName.Trim());
                controllerScriptNamespaceName = EditorGUILayout.TextField("Controller script namespace", controllerScriptNamespaceName.Trim());
                objectScriptNamespaceName = EditorGUILayout.TextField("Object script namespace", objectScriptNamespaceName.Trim());
                EditorGUILayout.Space();
                relativeControllerScriptDirectoryPath = EditorGUILayout.TextField("Controller script directory path", relativeControllerScriptDirectoryPath.Trim());
                relativeObjectScriptDirectoryPath = EditorGUILayout.TextField("Object script directory path", relativeObjectScriptDirectoryPath.Trim());
                EditorGUILayout.Space();
                isGeneratingInterfaces = EditorGUILayout.Toggle("Is generating interfaces", isGeneratingInterfaces);
                if (isGeneratingInterfaces)
                {
                    EditorGUILayout.Space();
                    controllerInterfaceName = EditorGUILayout.TextField("Controller interface name", controllerInterfaceName.Trim());
                    controllerInterfaceAccessibility = (EAccessibility)EditorGUILayout.EnumPopup("Accessibility", controllerInterfaceAccessibility);
                    EditorGUILayout.Space();
                    objectInterfaceName = EditorGUILayout.TextField("Object interface name", objectInterfaceName.Trim());
                    objectInterfaceAccessibility = (EAccessibility)EditorGUILayout.EnumPopup("Accessibility", objectInterfaceAccessibility);
                    EditorGUILayout.Space();
                    controllerInterfaceNamespaceName = EditorGUILayout.TextField("Controller interface namespace", controllerInterfaceNamespaceName.Trim());
                    objectInterfaceNamespaceName = EditorGUILayout.TextField("Object interface namespace", objectInterfaceNamespaceName.Trim());
                    EditorGUILayout.Space();
                    relativeControllerInterfaceDirectoryPath = EditorGUILayout.TextField("Controller interface directory path", relativeControllerInterfaceDirectoryPath.Trim());
                    relativeObjectInterfaceDirectoryPath = EditorGUILayout.TextField("Object interface directory path", relativeObjectInterfaceDirectoryPath.Trim());
                }
                EditorGUILayout.Space();
                if (GUILayout.Button("Generate classes"))
                {
                    selectedAllowedTypeIndex = -1;
                    try
                    {
                        if (!AssetDatabase.IsValidFolder(Path.Combine(directoryPath, relativeControllerScriptDirectoryPath)))
                        {
                            AssetDatabase.CreateFolder(directoryPath, relativeControllerScriptDirectoryPath);
                        }
                        if (!AssetDatabase.IsValidFolder(Path.Combine(directoryPath, relativeObjectScriptDirectoryPath)))
                        {
                            AssetDatabase.CreateFolder(directoryPath, relativeObjectScriptDirectoryPath);
                        }
                        if (isGeneratingInterfaces)
                        {
                            if (!AssetDatabase.IsValidFolder(Path.Combine(directoryPath, relativeControllerInterfaceDirectoryPath)))
                            {
                                AssetDatabase.CreateFolder(directoryPath, relativeControllerInterfaceDirectoryPath);
                            }
                            if (!AssetDatabase.IsValidFolder(Path.Combine(directoryPath, relativeObjectInterfaceDirectoryPath)))
                            {
                                AssetDatabase.CreateFolder(directoryPath, relativeObjectInterfaceDirectoryPath);
                            }
                        }
                        StringBuilder string_builder = new StringBuilder();
                        
                        // Controller script
                        AppendRequiredNamespaceNames(string_builder, controllerScriptNamespaceName, $"{ nameof(UnityGameEvents) }.{ nameof(UnityGameEvents.Controllers) }", type.Namespace, objectScriptNamespaceName, controllerInterfaceNamespaceName);
                        if (controllerScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("namespace ");
                            string_builder.AppendLine(controllerScriptNamespaceName);
                            string_builder.AppendLine("{");
                            string_builder.Append("    ");
                        }
                        string_builder.Append(controllerScriptAccessibility.ToString().ToLowerInvariant());
                        string_builder.Append(" class ");
                        string_builder.Append(controllerScriptName);
                        string_builder.Append(" : AGameEventWithParameterListenerControllerScript<");
                        string_builder.Append(objectScriptName);
                        string_builder.Append(", ");
                        string_builder.Append(type.Name);
                        if (isGeneratingInterfaces)
                        {
                            string_builder.Append(">, ");
                            string_builder.AppendLine(controllerInterfaceName);
                        }
                        else
                        {
                            string_builder.AppendLine(">");
                        }
                        if (controllerScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("{");
                        if (controllerScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("    // ...");
                        if (controllerScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("}");
                        if (controllerScriptNamespaceName.Length > 0)
                        {
                            string_builder.AppendLine("}");
                        }
                        CreateScriptAsset(Path.Combine(directoryPath, relativeControllerScriptDirectoryPath, controllerScriptName), string_builder.ToString());
                        string_builder.Clear();

                        // Object script
                        AppendRequiredNamespaceNames(string_builder, objectScriptNamespaceName, $"{ nameof(UnityGameEvents) }.{ nameof(UnityGameEvents.Objects) }", nameof(UnityEngine), type.Namespace, objectInterfaceNamespaceName);
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("namespace ");
                            string_builder.AppendLine(objectScriptNamespaceName);
                            string_builder.AppendLine("{");
                            string_builder.Append("    ");
                        }
                        string_builder.Append("[CreateAssetMenu(fileName = \"");
                        string_builder.Append(type.Name);
                        string_builder.Append("GameEvent\", menuName = \"Game events/");
                        string_builder.Append(type.Namespace.Replace('.', '/'));
                        string_builder.Append("/Game event (");
                        string_builder.Append(type.Name);
                        string_builder.AppendLine(")\")]");
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.Append(objectScriptAccessibility.ToString().ToLowerInvariant());
                        string_builder.Append(" class ");
                        string_builder.Append(objectScriptName);
                        string_builder.Append(" : AGameEventWithParameterObjectScript<");
                        string_builder.Append(type.Name);
                        if (isGeneratingInterfaces)
                        {
                            string_builder.Append(">, ");
                            string_builder.AppendLine(objectInterfaceName);
                        }
                        else
                        {
                            string_builder.AppendLine(">");
                        }
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("{");
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("    // ...");
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.Append("    ");
                        }
                        string_builder.AppendLine("}");
                        if (objectScriptNamespaceName.Length > 0)
                        {
                            string_builder.AppendLine("}");
                        }
                        CreateScriptAsset(Path.Combine(directoryPath, relativeObjectScriptDirectoryPath, objectScriptName), string_builder.ToString());
                        string_builder.Clear();

                        if (isGeneratingInterfaces)
                        {
                            // Controller interface
                            AppendRequiredNamespaceNames(string_builder, controllerInterfaceNamespaceName, nameof(UnityGameEvents), type.Namespace, objectScriptNamespaceName);
                            if (objectScriptNamespaceName.Length > 0)
                            {
                                string_builder.Append("namespace ");
                                string_builder.AppendLine(controllerInterfaceNamespaceName);
                                string_builder.AppendLine("{");
                                string_builder.Append("    ");
                            }
                            string_builder.Append(controllerInterfaceAccessibility.ToString().ToLowerInvariant());
                            string_builder.Append(" interface ");
                            string_builder.Append(controllerInterfaceName);
                            string_builder.Append(" : IGameEventWithParameterListenerController<");
                            string_builder.Append(objectScriptName);
                            string_builder.Append(", ");
                            string_builder.Append(type.Name);
                            string_builder.AppendLine(">");
                            if (controllerInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("{");
                            if (controllerInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("    // ...");
                            if (controllerInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("}");
                            if (controllerInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.AppendLine("}");
                            }
                            CreateScriptAsset(Path.Combine(directoryPath, relativeControllerInterfaceDirectoryPath, controllerInterfaceName), string_builder.ToString());
                            string_builder.Clear();

                            // Object interface
                            AppendRequiredNamespaceNames(string_builder, objectInterfaceNamespaceName, type.Namespace, nameof(UnityGameEvents));
                            if (objectScriptNamespaceName.Length > 0)
                            {
                                string_builder.Append("namespace ");
                                string_builder.AppendLine(objectInterfaceNamespaceName);
                                string_builder.AppendLine("{");
                                string_builder.Append("    ");
                            }
                            string_builder.Append(objectInterfaceAccessibility.ToString().ToLowerInvariant());
                            string_builder.Append(" interface ");
                            string_builder.Append(objectInterfaceName);
                            string_builder.Append(" : IGameEventWithParameterObject<");
                            string_builder.Append(type.Name);
                            string_builder.AppendLine(">");
                            if (objectInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("{");
                            if (objectInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("    // ...");
                            if (objectInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.Append("    ");
                            }
                            string_builder.AppendLine("}");
                            if (objectInterfaceNamespaceName.Length > 0)
                            {
                                string_builder.AppendLine("}");
                            }
                            CreateScriptAsset(Path.Combine(directoryPath, relativeObjectInterfaceDirectoryPath, objectInterfaceName), string_builder.ToString());
                            string_builder.Clear();
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                    AssetDatabase.Refresh();
                }
            }
            EditorGUILayout.EndScrollView();
        }
    }
}
