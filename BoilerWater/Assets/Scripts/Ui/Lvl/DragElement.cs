using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui.Lvl
{
    public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [SerializeField] private Sprite _mainImage;
        public Canvas Canvas;
        public GameObject _prefab;
        
        private Transform _transformSelf;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _transformSelf = transform;
            _canvasGroup= GetComponent<CanvasGroup>();
        }

        private Transform defaultParentTransform;

        
        
        /// <summary>
        /// Трансформ объекта, к которому прикреплена кнопка
        /// </summary>
        public Transform DefaultParentTransform
        {
            get { return defaultParentTransform; }
            set
            {
                if (value != null)
                {
                    defaultParentTransform = value;
                }
            }
        }

        private Transform dragParentTransform;

        /// <summary>
        /// Трансформ объекта, к которому прикрепляется кнопка во время драга
        /// </summary>
        public Transform DragParentTransform
        {
            get { return dragParentTransform; }
            set
            {
                if (value != null)
                    dragParentTransform = value;
            }
        }

        private int siblingIndex;
        private IDropHandler dropHandlerImplementation;

        /// <summary>
        /// Номер индекса внутри родительского объекта
        /// </summary>
        public int SiblingIndex
        {
            get { return siblingIndex; }
            set
            {
                if (value > 0)
                    siblingIndex = value;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _transformSelf.SetParent(DragParentTransform);
            _canvasGroup.alpha = .6f;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
            // transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //возвращаем обратно в контент элемент
            transform.SetParent(DefaultParentTransform);
            transform.SetSiblingIndex(SiblingIndex);
            
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;

            // //создаем луч и хит
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // RaycastHit hit;

            // //пускаем луч и меняем материал у встреченного объекта
            // if (Physics.Raycast(ray, out hit))
            // {
            //     hit.collider.gameObject.GetComponent<Renderer>().material = mainMaterial;
            // }
        }

    }
}