using System;
using Bottle;
using UnityEngine;
using Fluid;
using Ui.Lvl;
namespace Core
{
    public class GameCore : MonoBehaviour
    {

        [SerializeField] private ItemSlot _itemSlot;
        [SerializeField] private GameObject _stopB;
        [SerializeField] private GameObject _barrier1;
        private void Start()
        {
            _itemSlot.PrefabCreate += PrefabCreate;
        }

        private void PrefabCreate(FluidCount fluidCount)
        {
            fluidCount.PouredWater += PouredWater;
            fluidCount.StopWaterDrop += StopWaterDrop;
        }

        private void StopWaterDrop(float persentFullnes)
        {
            if (100 - persentFullnes <= 30)
            {
                Debug.Log("U win: "+ persentFullnes);
            }else Debug.Log("U loss: " + persentFullnes);
        }
        
        private void PouredWater(float persentFullnes)
        {
            _stopB.SetActive(false);
            _barrier1.SetActive(false);
            Debug.Log("U loss: " + persentFullnes);
        }

    }
}