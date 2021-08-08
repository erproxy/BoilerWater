using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField] private Sprite _mainImage;
    
    private Transform _transformSelf;
    private RectTransform _rectTransform;
    public Canvas Canvas;


    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _transformSelf = transform;
    }

    /// <summary>
    /// Материал, применяемый к объектам на сцене
    /// </summary>
    public Sprite MainImage
    {
        get { return _mainImage; }
        set
        {
            if (value != null)
            {
                _mainImage = value;
            }
        }
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
        get
        {
            return dragParentTransform;
        }
        set
        {
            if (value != null)
                dragParentTransform = value;
        }
    }

    private int siblingIndex;
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
