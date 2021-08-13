



using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Json
{
    public class DefaultSettings : MonoBehaviour
    {
        [SerializeField] private Animator _animatorScrollBottle;
        private  List<GameObject> _fluids = new List<GameObject>();
        private List<Transform> _fluidsDefaultPos = new List<Transform>();


        private void Start()
        {
            var Temp = GameObject.FindGameObjectsWithTag("Fluid");
            foreach (var temp in Temp)
            {
                _fluids.Add(temp);
                _fluidsDefaultPos.Add(temp.transform);
            }
            _animatorScrollBottle.SetBool("Hidden", false);
        }
    }
}