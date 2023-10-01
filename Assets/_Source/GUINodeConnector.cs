using System.Collections.Generic;
using ItemsSystem;
using PathSystem;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SceneGUINodeConnecting : MonoBehaviour
{
    [SerializeField] private GameObject infectedPathPrefab;

    private void OnGUI()
    {
        if (Selection.gameObjects.Length == 0) return;
        bool isConnectButtonClicked = GUI.Button(new Rect(0f, 0f, 100f, 30f), "ConnectNodes");
        bool isUnConnectButtonClicked = GUI.Button(new Rect(0f, 32f, 115f, 30f), "UnConnectNodes");
        bool isClearButtonClicked = GUI.Button(new Rect(0f, 64f, 110f, 30f), "RemoveAllLinks");
        bool isInfectedButtonClicked = GUI.Button(new Rect(0f, 96f, 118f, 30f), "MakeInfectedPath");
        bool isDeletInfectedButtonClicked = GUI.Button(new Rect(0f, 128f, 124f, 30f), "DeleteInfectedPath");

        List<PathNode> pathNodes;
        if (!isConnectButtonClicked && !isUnConnectButtonClicked && !isClearButtonClicked && !isInfectedButtonClicked &&
            !isDeletInfectedButtonClicked) return;

        pathNodes = GetSelectedNodes();
        if (isConnectButtonClicked) NodeConnect(pathNodes);
        if (isUnConnectButtonClicked) NodeUnConnect(pathNodes);
        if (isClearButtonClicked) ClearNode(pathNodes);
        if (isInfectedButtonClicked) MakeInfectedPath(pathNodes);
        if (isDeletInfectedButtonClicked) DeleteInfectedPath();
    }

    private void ClearNode(List<PathNode> pathNodes)
    {
        foreach (var node1 in pathNodes)
        {
            var serialzedObject = new SerializedObject(node1);
            var array = serialzedObject.FindProperty("<NearNodes>k__BackingField");

            for (int i = 0; i < array.arraySize; i++)
            {
                var node2 = array.GetArrayElementAtIndex(i).objectReferenceValue;
                var serialzedObject2 = new SerializedObject(node2);
                var array2 = serialzedObject2.FindProperty("<NearNodes>k__BackingField");
                for (int j = 0; j < array2.arraySize; j++)
                {
                    if (array2.GetArrayElementAtIndex(j).objectReferenceValue == node1)
                    {
                        array2.GetArrayElementAtIndex(j).objectReferenceValue = null;
                        array2.DeleteArrayElementAtIndex(j);
                        break;
                    }
                }

                serialzedObject2.ApplyModifiedProperties();
            }

            array.ClearArray();

            serialzedObject.ApplyModifiedProperties();
        }
    }

    private void NodeConnect(List<PathNode> pathNodes)
    {
        if (pathNodes.Count < 2) return;
        foreach (var node1 in pathNodes)
        {
            var serialzedObject = new SerializedObject(node1);
            var array = serialzedObject.FindProperty("<NearNodes>k__BackingField");

            foreach (var node2 in pathNodes)
            {
                if (node1 == node2) continue;
                bool isAdded = false;
                for (int i = 0; i < array.arraySize; i++)
                {
                    if (array.GetArrayElementAtIndex(i).objectReferenceValue == node2)
                    {
                        isAdded = true;
                        break;
                    }
                }

                if (isAdded) continue;
                array.InsertArrayElementAtIndex(array.arraySize);
                array.GetArrayElementAtIndex(array.arraySize - 1).objectReferenceValue = node2;
            }

            serialzedObject.ApplyModifiedProperties();
        }
    }

    private void NodeUnConnect(List<PathNode> pathNodes)
    {
        if (pathNodes.Count < 2) return;
        foreach (var node1 in pathNodes)
        {
            var serialzedObject = new SerializedObject(node1);
            var array = serialzedObject.FindProperty("<NearNodes>k__BackingField");

            foreach (var node2 in pathNodes)
            {
                if (node1 == node2) continue;
                bool isAdded = false;
                for (int i = 0; i < array.arraySize; i++)
                {
                    if (array.GetArrayElementAtIndex(i).objectReferenceValue == node2)
                    {
                        array.GetArrayElementAtIndex(i).objectReferenceValue = null;
                        array.DeleteArrayElementAtIndex(i);
                        break;
                    }
                }
            }

            serialzedObject.ApplyModifiedProperties();
        }
    }

    private void MakeInfectedPath(List<PathNode> pathNodes)
    {
        InfectedPath infectedPathobj = Instantiate(infectedPathPrefab, null).GetComponent<InfectedPath>();

        var infectedPathSerObj = new SerializedObject(infectedPathobj);
        var array = infectedPathSerObj.FindProperty("infectedNode");

        infectedPathSerObj.FindProperty("keySpawner").objectReferenceValue = FindObjectOfType<KeySpawner>();

        for (int i = 0; i < pathNodes.Count; i++)
        {
            array.InsertArrayElementAtIndex(i);
            array.GetArrayElementAtIndex(i).objectReferenceValue = pathNodes[i];
        }

        infectedPathSerObj.ApplyModifiedProperties();

        var ItemUnloaderSerObj = new SerializedObject(FindObjectOfType<CoreItemUnloader>());
        var unloaderArray = ItemUnloaderSerObj.FindProperty("infectedPaths");

        unloaderArray.InsertArrayElementAtIndex(unloaderArray.arraySize);
        unloaderArray.GetArrayElementAtIndex(unloaderArray.arraySize - 1).objectReferenceValue = infectedPathobj;

        ItemUnloaderSerObj.ApplyModifiedProperties();
    }

    private void DeleteInfectedPath()
    {
        List<InfectedPath> infectedPaths = GetSelectedInfectedPaths();
        var ItemUnloaderSerObj = new SerializedObject(FindObjectOfType<CoreItemUnloader>());
        var unloaderArray = ItemUnloaderSerObj.FindProperty("infectedPaths");

        foreach (var path in infectedPaths)
        {
            for (int i = 0; i < unloaderArray.arraySize; i++)
            {
                if (unloaderArray.GetArrayElementAtIndex(i).objectReferenceValue == path)
                {
                    unloaderArray.GetArrayElementAtIndex(i).objectReferenceValue = null;
                    unloaderArray.DeleteArrayElementAtIndex(i);
                    break;
                }

            }

            ItemUnloaderSerObj.ApplyModifiedProperties();
            DestroyImmediate(path.gameObject);
        }
    }

    private List<PathNode> GetSelectedNodes()
    {
        GameObject[] selected = Selection.gameObjects;
        List<PathNode> pathNodes = new List<PathNode>();
        foreach (var node in selected)
        {
            PathNode pathnode;
            if (node.TryGetComponent<PathNode>(out pathnode))
                pathNodes.Add(pathnode);
        }

        return pathNodes;
    }

    private List<InfectedPath> GetSelectedInfectedPaths()
    {
        GameObject[] selected = Selection.gameObjects;
        List<InfectedPath> paths = new List<InfectedPath>();
        foreach (var node in selected)
        {
            InfectedPath pathnode;
            if (node.TryGetComponent<InfectedPath>(out pathnode))
                paths.Add(pathnode);
        }

        return paths;
    }

}
