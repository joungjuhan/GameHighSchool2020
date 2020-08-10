using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableOBject : MonoBehaviour//IPointerDownHandler
{
    //    private void OnMouseDown()
    //    {
    //        Debug.Log("오브젝트를 눌렀습니다.");
    //    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //throw new System.NotImplementedException();
    //    Debug.Log("오브젝트를 눌렀습니다.");
    //}
    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Debug.Log("오브젝트를 눌렀습니다.");
    }
}
