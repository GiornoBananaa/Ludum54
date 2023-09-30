using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PathSystem
{
    public class PathLinkDictionary
    {
        private class NodesLinePair
        {
            public PathNode[] Nodes;
            public LineRenderer LineRenderer;

            public NodesLinePair(PathNode[] nodes, LineRenderer lineRenderer)
            {
                Nodes = nodes;
                LineRenderer = lineRenderer;
            }
        }
        
        private List<NodesLinePair> _dict;
        private float _width;
        private int _lineLayerOrder;
        private Material _material;

        public PathLinkDictionary(float width, int lineLayerOrder,Material material)
        {
            _dict = new List<NodesLinePair>();
            _width = width;
            _lineLayerOrder = lineLayerOrder;
            _material = material;
        }

        public void Add(PathNode t1, PathNode t2)
        {
            if (Contains(t1, t2))
                return;

            GameObject gameObject = new GameObject();
            LineRenderer line = gameObject.AddComponent<LineRenderer>();
            line.endWidth = _width;
            line.startWidth = _width;
            line.material = _material;
            line.sortingOrder = _lineLayerOrder;
            line.SetPosition(0,t1.Point);
            line.SetPosition(1,t2.Point);
            
            _dict.Add(new NodesLinePair(new PathNode[]{t1,t2},line));
        }

        public bool Contains(PathNode t1, PathNode t2)
        {
            foreach (var p in _dict)
            {
                PathNode[] nodes = p.Nodes;

                if (nodes[0] == t1 && nodes[1] == t2
                    || nodes[0] == t2 && nodes[1] == t1)
                    return true;
            }

            return false;
        }
        
        public LineRenderer GetLineRender(PathNode t1, PathNode t2)
        {
            foreach (var pair in _dict)
            {
                if (pair.Nodes[0] == t1 && pair.Nodes[1] == t2
                    || pair.Nodes[0] == t2 && pair.Nodes[1] == t1)
                    return pair.LineRenderer;
            }

            return null;
        }
    }
}