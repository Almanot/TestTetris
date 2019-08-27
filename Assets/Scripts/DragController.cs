using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

public class DragController : MonoBehaviour
{
    Vector3 newVector;

    //for tests by the computer control
    //private void OnMouseDrag()
    //{
    //    newVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    newVector.z = 0;
    //    transform.position = newVector;
    //    transform.localScale = new Vector3(1, 1, 1);
    //}
    //private void OnMouseUp()
    //{
    //    if(GameFieldController.instance.CheckTheSpace(newVector, GetComponent<Shape>()))
    //    {
    //        GameFieldController.instance.PlaceShape(newVector, GetComponent<Shape>());
    //        GetComponent<Shape>().Destroy();
    //    }
    //    else
    //    {
    //        GetComponent<Shape>().SetPosition();
    //        transform.localScale = new Vector3(0.75f, 0.75f, 1);
    //    }
    //}
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        newVector.x = touchPos.x - transform.position.x;
                        newVector.y = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - newVector.x, touchPos.y - newVector.y);
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    break;
                case TouchPhase.Ended:
                    if (GameFieldController.instance.CheckTheSpace(transform.position, GetComponent<Shape>()))
                    {
                        GameFieldController.instance.PlaceShape(transform.position, GetComponent<Shape>());
                        GetComponent<Shape>().Destroy();
                    }
                    else
                    {
                        GetComponent<Shape>().SetPosition();
                        transform.localScale = new Vector3(0.75f, 0.75f, 1);
                    }
                    break;
            }
        }
    }
}
