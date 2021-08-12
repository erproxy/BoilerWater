using System;
using System.Collections;
using System.Collections.Generic;
using Bottle;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Ui.Lvl
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Animator _animatorScrollBottles;

        [SerializeField] private GameObject _startButton;
        
        private Transform _cashTransform;
        private GameObject _prefab;
        
        //Делегат необходим для создания подписки геймкора на созданный объект префаба
        public delegate void Prefab(FluidCount fluidCount);

        public Prefab PrefabCreate;
        
        
        private void Start()
        {
            _cashTransform = transform;
        }

        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                _prefab = eventData.pointerDrag.GetComponent<DragElement>()._prefab;

                PrefabCreate(Instantiate(_prefab, _cashTransform.position, Quaternion.identity).GetComponent<FluidCount>());
                _animatorScrollBottles.SetBool("Hidden", true);

                _startButton.SetActive(true);
            }
        }
    }
}