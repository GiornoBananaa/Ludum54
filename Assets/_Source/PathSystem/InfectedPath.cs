using System;
using System.Collections.Generic;
using ItemsSystem;
using UnityEngine;

namespace PathSystem
{
    public class InfectedPath : MonoBehaviour
    {
        [SerializeField] private PathNode[] infectedNode;
        [SerializeField] private Key key;
        [SerializeField] private Material infectedMaterial;
        [SerializeField] private Material deafultMaterial;

        private List<LineRenderer> lines;
        
        private void Start()
        {
            lines = new List<LineRenderer>();
            //key.OnPickUp += OpenPath
            Invoke("BlockPath",0.4f);
        }

        private void Update()
        {
            if (key == null)
            {
                OpenPath(); 
                gameObject.SetActive(false);
            }
        }

        private void BlockPath()
        {
            foreach (PathNode node in infectedNode)
            {
                node.IsInfected = true;
                foreach (PathNode node2 in infectedNode)
                {
                    if (PathNode.Links.Contains(node2, node))
                    {
                        LineRenderer line = PathNode.Links.GetLineRender(node, node2);
                        line.material = infectedMaterial;
                        lines.Add(line);
                    }
                }
            }
        }
        
        private void OpenPath()
        {
            foreach (LineRenderer line in lines)
            {
                line.material = deafultMaterial;
            }

            foreach (PathNode node in infectedNode)
            {
                node.IsInfected = true;
            }
        }
    }
}
