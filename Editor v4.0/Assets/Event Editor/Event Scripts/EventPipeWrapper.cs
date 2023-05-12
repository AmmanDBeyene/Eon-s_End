using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Event_Scripts
{
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
            ReverseOrder(root);
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
    }
}
