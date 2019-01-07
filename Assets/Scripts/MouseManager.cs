using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayer;

    [SerializeField] private Texture2D _normalPointer;
    [SerializeField] private Texture2D _targetPointer;
    [SerializeField] private Texture2D _doorwayPointer;
    [SerializeField] private Texture2D _combatPointer;

    public EventVector3 OnClickEnvironment;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50,
            _clickableLayer.value))
        {
            var door = false;
            var item = false;
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(_doorwayPointer, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(_combatPointer, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(_targetPointer, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(doorway.position);
                    Debug.Log("Door");
                }
                else if (item)
                {
                    var itemTransform = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(itemTransform.position);
                    Debug.Log("Item");
                }
                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(_normalPointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[Serializable]
public class EventVector3 : UnityEvent<Vector3>
{

}