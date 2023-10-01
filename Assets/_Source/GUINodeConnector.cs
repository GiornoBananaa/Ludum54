using System.Collections;
using System.Collections.Generic;
using PathSystem;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SceneGUINodeConnecting : MonoBehaviour
{
    private void OnGUI()
    {
        bool isButtonClicked = GUI.Button(new Rect(0f,0f,100f,30f),"ConnectNodes");
        
        if (!isButtonClicked) return;
        
        GameObject[] selected = Selection.gameObjects;
        List<PathNode> pathNodes = new List<PathNode>();
        foreach (var node in selected)
        {
            PathNode pathnode;
            if(node.TryGetComponent<PathNode>(out pathnode)) 
                pathNodes.Add(pathnode);
        }
        if(pathNodes.Count < 2) return;
        foreach (var node1 in pathNodes)
        {
            var serialzedObject = new SerializedObject(node1);
            var array = serialzedObject.FindProperty("<NearNodes>k__BackingField");
            
            foreach (var node2 in pathNodes)
            {
                if(node1 == node2) continue;
                bool isAdded = false;
                for (int i =0;i<array.arraySize; i++)
                {
                    if (array.GetArrayElementAtIndex(i).objectReferenceValue == node2)
                    {
                        isAdded = true;
                        break;
                    }
                }
                if(isAdded) continue;
                array.InsertArrayElementAtIndex(array.arraySize);
                array.GetArrayElementAtIndex(array.arraySize-1).objectReferenceValue = node2;
            }
            serialzedObject.ApplyModifiedProperties();
        }
    }
}
