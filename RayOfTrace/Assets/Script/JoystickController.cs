using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
  
    private float Degrees;
    private bool DisDrag;


    private GameObject Player;
    public Image PedImg;
    public Image JoystickImg;

    private Vector3 InputVector;
    private Vector3 StartVector;

   [SerializeField] private Vector3 NowVector;
   [SerializeField] private Vector3 Direction;

    
    void Start()
    {

        
    }


    public virtual void OnDrag(PointerEventData ped)
    {


        DisDrag = true;

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(PedImg.rectTransform,
                                                                    ped.position,
                                                                    ped.pressEventCamera,
                                                                    out pos))
        {

            pos.x = (pos.x / PedImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / PedImg.rectTransform.sizeDelta.y);

            NowVector = JoystickImg.transform.localPosition;

            InputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;



            JoystickImg.rectTransform.anchoredPosition =
                new Vector3(InputVector.x * (PedImg.rectTransform.sizeDelta.x / 2.5f), InputVector.z * (PedImg.rectTransform.sizeDelta.y / 2.5f));
        }
        NowVector = JoystickImg.transform.localPosition;
        Direction = (NowVector - StartVector).normalized;

    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        StartVector = Vector3.zero;
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        DisDrag = false;
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }

    public void InitPos()
    {
        DisDrag = false;
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }
}

