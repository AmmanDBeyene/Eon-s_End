using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Event_Scripts
{
    public class DistanceNode<T>
    {
        public T data;
        public int distance;
        public DistanceNode(T data, int distance) {
            this.data = data;
            this.distance = distance;
        }
    }

    public class EventPipeWrapper
    {
        [SerializeField]
        public List<IEventPipe> _pipes;

        [SerializeField]
        public IEventPipe _root;

        private List<IEventPipe> _visited;

        public EventPipeWrapper(IEventPipe root)
        {
            _pipes = new List<IEventPipe>();
            _visited = new List<IEventPipe>();
            _root = root;
            OrderPipes();
            //ReverseOrder(root);
        }

        private void ReverseOrder(IEventPipe root)
        {
            if (root == null || _visited.Contains(root))
            {
                return;
            }

            _visited.Add(root);

            List<IEventPipe> next = root.Next();
            foreach (IEventPipe pipe in next)
            {
                ReverseOrder(pipe);
            }

            _pipes.Add(root);
        }

        private void OrderPipes()
        {
            List<DistanceNode<IEventPipe>> distances = new List<DistanceNode<IEventPipe>>();
            ReverseDistance(distances, _root, 0);

            distances = distances.OrderByDescending(i => i.distance).ToList();
            distances.ForEach(i => _pipes.Add(i.data));
        }

        private void ReverseDistance(List<DistanceNode<IEventPipe>> distances, IEventPipe root, int distance)
        {
            if (root == null || _visited.Contains(root))
            {
                return;
            }

            _visited.Add(root);

            List<IEventPipe> next = root.Next();
            foreach (IEventPipe pipe in next)
            {
                ReverseDistance(distances, pipe, distance + 1);
            }

            distances.Add(new DistanceNode<IEventPipe>(root, distance));
        }
    }
}
