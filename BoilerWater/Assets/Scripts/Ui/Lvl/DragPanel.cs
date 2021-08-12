using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Lvl
{
    public class DragPanel : MonoBehaviour
    {

        [Tooltip("Ссылка на префаб драгуемого элемента")] [SerializeField]
        private GameObject _dragElementPrefab;

        [Tooltip("Ссылка на Content ScrollView")] [SerializeField]
        private Transform _scrollViewContent;

        [Tooltip("Спрайти для замены спрайтов в объектах")] [SerializeField]
        private List<Sprite> _sprites;
        
        [Tooltip("Префабы для спавна объекта")] [SerializeField]
        private List<GameObject> _prefabs;

        [SerializeField] private Canvas _canvas;

        private void Start()
        {
            var transformSelf = transform;
            for (int i = 0; i < _sprites.Count; ++i)
            {
                var dragObject = Instantiate(_dragElementPrefab, _scrollViewContent);
                var script = dragObject.GetComponent<DragElement>();


                dragObject.GetComponent<DragElement>()._prefab = _prefabs[i];
                dragObject.GetComponent<Image>().sprite = _sprites[i];
                script.DefaultParentTransform = _scrollViewContent;
                script.DragParentTransform = transformSelf;
                script.Canvas = _canvas;
                script.SiblingIndex = i;
            }
        }

    }
}