using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayer;

    [SerializeField] private Texture2D _normalPointer;
    [SerializeField] private Texture2D _targetPointer;
    [SerializeField] private Texture2D _doorwayPointer;
    [SerializeField] private Texture2D _combatPointer;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 50,
            _clickableLayer.value))
        {
            var door = false;
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(_doorwayPointer, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(_targetPointer, new Vector2(16, 16), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(_normalPointer, Vector2.zero, CursorMode.Auto);
        }
    }
}
