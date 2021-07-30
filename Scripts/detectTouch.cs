using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class detectTouch : MonoBehaviour, IPointerDownHandler
{
    public MovePlayer movePlayer;

    public void OnPointerDown(PointerEventData eventData)
    {
      if(gameObject.name == "Jump")
        {
            if(movePlayer.isGround)
            movePlayer.Jump();
        }
      if(gameObject.name == "Turn")
        {
            movePlayer.Turn();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
}
