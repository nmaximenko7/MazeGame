using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class SwipeControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]private Snake snake;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        float deltaX = eventData.delta.x;
        float deltaY = eventData.delta.y;
        Debug.Log(snake.direction);
        if (snake.direction.x == 0f && Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            Debug.Log("Drag X");
            if (deltaX > 0) snake.direction = Vector2Int.right;
            else if (deltaX < 0) snake.direction = Vector2Int.left;
        }
        else if (snake.direction.y == 0f && Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
        {
            Debug.Log("Drag Y");
            if (deltaY > 0) snake.direction = Vector2Int.up;
            else if (deltaY < 0) snake.direction = Vector2Int.down;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {

    }
}
