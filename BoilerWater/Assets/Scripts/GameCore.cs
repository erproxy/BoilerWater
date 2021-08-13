using System.Collections.Generic;
using Bottle;
using UnityEngine;
using TMPro;
using Ui.Lvl;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Core
{
    public class GameCore : MonoBehaviour
    {

        [SerializeField] private ItemSlot _itemSlot;
        [SerializeField] private GameObject _stopB;
        [SerializeField] private GameObject _barrier1;
        [SerializeField] private GameObject _handEnd;
        [SerializeField] private GameObject _ScoreBoard;
        private FluidCount _fluidCount;
        
        
        [SerializeField] private Animator _animatorScrollBottle;
        [SerializeField] private GameObject _curtain;
        [SerializeField] private GameObject _resetPanel;
        private  List<GameObject> _fluids = new List<GameObject>();
        private List<Vector3> _fluidsDefaultPos = new List<Vector3>();


        private void Start()
        {

            _itemSlot.PrefabCreate += PrefabCreate;
            var Temp = GameObject.FindGameObjectsWithTag("Fluid");
            foreach (var temp in Temp)
            {
                _fluids.Add(temp);
                _fluidsDefaultPos.Add(temp.transform.position);
            }
            
        }

        public void OnResetLvl()
        {
            _curtain.SetActive(true);
            for (int i = 0; i < _fluids.Count; i++)
            {
                _fluids[i].transform.position = _fluidsDefaultPos[i];
            }
            _resetPanel.SetActive(false);
            _ScoreBoard.SetActive(false);
            _animatorScrollBottle.SetBool("Hidden", false);
        }

        public void OnExitFromTheGame()
        {
            Application.Quit();
        }
        private void PrefabCreate(FluidCount fluidCount)
        {
            _fluidCount = fluidCount;
            _fluidCount.PouredWater += PouredWater;
            _fluidCount.StopWaterDrop += StopWaterDrop;
        }

        private void StopWaterDrop(float persentFullnes)
        {
            _ScoreBoard.SetActive(true);
            var TMP = _ScoreBoard.GetComponent<Text>();
            TMP.text = "asdf";
            TMP.color = Color.red;
            if (100 - persentFullnes <= 30)
            {
                TMP.text = persentFullnes.ToString();
                TMP.color = Color.green;
                Debug.Log("U win: "+ persentFullnes);
            }else
            {
                TMP.text = persentFullnes.ToString();
                TMP.color = Color.red;
                Debug.Log("U loss: " + persentFullnes);
            }
            
            _handEnd.SetActive(true);
            
            _fluidCount.PouredWater -= PouredWater;
            _fluidCount.StopWaterDrop -= StopWaterDrop;
        }
        
        private void PouredWater(float persentFullnes)
        {
            _stopB.SetActive(false);
            _barrier1.SetActive(false);
            _handEnd.SetActive(true);
            Debug.Log("U loss: " + persentFullnes);
            
            _ScoreBoard.SetActive(true);
            var TMP = _ScoreBoard.GetComponent<Text>();
            TMP.text = persentFullnes.ToString();
            TMP.color = Color.red;

            _fluidCount.PouredWater -= PouredWater;
            _fluidCount.StopWaterDrop -= StopWaterDrop;
        }

    }
}