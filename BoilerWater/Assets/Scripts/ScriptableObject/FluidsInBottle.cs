using UnityEngine;


    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Fluids In Bottle", order = 1)]
    public class FluidsInBottle : ScriptableObject
    {
        
        [SerializeField] private int maxFluids;
        public int MaxFluids
        {
            get
            {
                return maxFluids;
            }
        }
        
    }
