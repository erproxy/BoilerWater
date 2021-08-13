using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;


namespace Hand
{
    public class HandEndLogick : MonoBehaviour
    {

        [SerializeField] private Transform _checkCountPos;
        [SerializeField] private float _rangeCounting;
        [SerializeField] private LayerMask _whatIsSolid;


        private Transform _transformSelf;
        private GameObject _bottle;
        
        private List<Transform> _childs = new List<Transform>();
        private List<Transform> _childsParent = new List<Transform>();


        private void Start()
        {
            _transformSelf = transform;
        }

        public void SetParent()
        {
            Collider2D[] enemies= Physics2D.OverlapCircleAll(_checkCountPos.position,
                _rangeCounting, _whatIsSolid);
            if (enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    _childs.Add(enemies[i].transform);
                    _childsParent.Add(enemies[i].transform.parent);
                    _childs[i].SetParent(_transformSelf);
                }
            }
            _bottle = GameObject.FindWithTag("Bottle");
            
            
        }


        public void DefaultParent()
        {
            for (int i = 0; i < _childs.Count; i++)
            {
                _childs[i].SetParent(_childsParent[i]);
            }
            Destroy(_bottle);
            gameObject.SetActive(false);
            _childs.Clear();
            _childsParent.Clear();
        }
        
        private void OnDrawGizmosSelected(){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_checkCountPos.position, _rangeCounting);
        }
        
    }
}
