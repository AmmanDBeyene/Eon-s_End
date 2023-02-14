using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public class WarningManipulator
    {
        private const float _delay = 3000;
        private const float _fade = 1000;

        private VisualElement _target { get; set; }
        private bool _firstUpdate = true;
        private long _firstMs = 0;
        private int _stage = 0;

        public bool finished = false;

        public WarningManipulator(VisualElement target)
        {
            _target = target;
        }

        public void Update()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (_firstUpdate)
            {
                _firstMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                _stage = 0;
                _firstUpdate = false;
            }

            long delta = now - _firstMs;

            if (_stage == 0 && delta > _delay)
            {
                _stage = 1;
                _firstMs = now;
                return;
            }

            if (_stage != 1)
            {
                return;
            }

            float opacity = Math.Clamp(1 - 1 * delta / _fade, 0, 1);
            _target.style.opacity = opacity;

            if (delta > _fade)
            {
                _target.parent.Remove(_target);
                _stage = 3;
                finished = true;
            }
        }
    }
}
