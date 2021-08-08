using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingMub : MonoBehaviour, IDragHandler
{
    private readonly float speed = 0.1f;
    private bool move = false;
    private Vector3 target;
    private Vector2 startPos;



    Vector3 startDirection;
 
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            var dir = touchPosition - transform.position;
            var euler = transform.eulerAngles;
            euler.z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = euler;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("asdf");
   //     GO.position = Input.GetTouch(0).position;
    }
}
