using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomPropertyDrawer(typeof(DropdownAttribute))]
public class DropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Obtener el objeto que contiene los campos
        var targetObject = property.serializedObject.targetObject;

        // Obtener el valor de concreteOption
        SerializedProperty concreteOptionProperty = property.serializedObject.FindProperty("concreteOption");

        // Si concreteOption es true, renderizar el campo
        if (concreteOptionProperty.boolValue)
        {
            // Buscar la lista de nodos marcada con el atributo NodeListAttribute
            FieldInfo nodeListField = null;
            foreach (var field in targetObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (field.GetCustomAttribute<ListAttribute>() != null && field.FieldType.IsArray)
                {
                    nodeListField = field;
                    break;
                }
            }

            // Si no se encontró ninguna lista marcada, mostrar un mensaje
            if (nodeListField == null)
            {
                EditorGUI.LabelField(position, label.text, "No se encontró una lista marcada con NodeListAttribute.");
                return;
            }

            // Obtener la lista de nodos
            var nodeList = nodeListField.GetValue(targetObject) as GameObject[];

            if (nodeList != null)
            {
                // Crear una lista de opciones con los nombres de los GameObjects en nodeList
                string[] options = new string[nodeList.Length];
                for (int i = 0; i < nodeList.Length; i++)
                {
                    options[i] = nodeList[i] != null ? nodeList[i].name : "None";
                }

                // Obtener el índice actual del GameObject seleccionado
                int currentIndex = -1;
                for (int i = 0; i < nodeList.Length; i++)
                {
                    if (property.objectReferenceValue == nodeList[i])
                    {
                        currentIndex = i;
                        break;
                    }
                }

                // Dibujar el menú desplegable
                currentIndex = EditorGUI.Popup(position, label.text, currentIndex, options);

                // Asignar el GameObject seleccionado
                if (currentIndex >= 0 && currentIndex < nodeList.Length)
                {
                    property.objectReferenceValue = nodeList[currentIndex];
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "La lista de nodos es nula o está vacía.");
            }
        }
    }
}
