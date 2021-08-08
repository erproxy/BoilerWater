using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Lvl.Buttons
{
    public class SwipeBottles : MonoBehaviour
    {
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private float _scrollPos = 0;
        private float[] _pos;
        private Transform _transformSelf;

        private void Start()
        {
            _transformSelf = transform;
        }

        private void Update()
        {
            _pos = new float[_transformSelf.childCount];
            var distance = 1f / (_pos.Length - 1f);

            for (int i = 0; i < _pos.Length; i++)
            {
                _pos[i] = distance * i;
            }

          //  Touch touch = Input.GetTouch(0);touch.phase == TouchPhase.Moved
            if (Input.GetMouseButton(0))
            {
                _scrollPos = _scrollbar.value;
            }
            else
            {
                for (int i = 0; i < _pos.Length; i++)
                {
                    if (_scrollPos<_pos[i] +(distance/2)&& _scrollPos> _pos[i]-(distance/2))
                    {
                        _scrollbar.value = Mathf.Lerp(_scrollbar.value, _pos[i], 0.1f);
                    }
                }
            }
            
            for (int i = 0; i < _pos.Length; i++)
            {
                if (_scrollPos<_pos[i] +(distance/2)&& _scrollPos> _pos[i]-(distance/2))
                {
                    _transformSelf.GetChild(i).localScale = Vector2.Lerp(_transformSelf.GetChild(i).localScale,
                        new Vector2(1f, 1f), 0.1f);
                    for (int a = 0; a < _pos.Length; a++)
                    {
                        if (a != i)
                        {
                            _transformSelf.GetChild(a).localScale = Vector2.Lerp(_transformSelf.GetChild(a).localScale,
                                new Vector2(0.8f, 0.8f), 0.1f);
                        }
                    }
                }
            }
        }
    }
}