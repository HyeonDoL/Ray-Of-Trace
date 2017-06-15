using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MoveButtonScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    Image Joystick;
    [SerializeField]
    Image JumpButton;
    [SerializeField]
    Image Item1;
    [SerializeField]
    Image Item2;
    private GameObject target;
    private bool DisDrag;
    private void Start()
    {
        Joystick.transform.localPosition = new Vector3(PlayerPrefs.GetInt(Prefstype.JoystickxPos, -624),
                                                  PlayerPrefs.GetInt(Prefstype.JoystickyPos,-284),0.0f);
        JumpButton.transform.localPosition = new Vector3(PlayerPrefs.GetInt(Prefstype.JumpButtonxPos, 634),
                                                    PlayerPrefs.GetInt(Prefstype.JumpButtonyPos, -300), 0.0f);
        Item1.transform.localPosition = new Vector3(PlayerPrefs.GetInt(Prefstype.Item1xPos, 439),
                                               PlayerPrefs.GetInt(Prefstype.Item1yPos, -175), 0.0f);
        Item2.transform.localPosition = new Vector3(PlayerPrefs.GetInt(Prefstype.Item2xPos, 629),
                                               PlayerPrefs.GetInt(Prefstype.Item2yPos, -61), 0.0f);
    }

    public virtual void OnDrag(PointerEventData ped)
    {


        DisDrag = true;
      
            Vector3 mousePosition
        = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            target.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

        

    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        CastRay(ped);
       
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        DisDrag = false;
        
    }
    public void ChangeButtonPos()
    {
        PlayerPrefs.SetInt(Prefstype.JoystickxPos, (int)Joystick.transform.localPosition.x);
        PlayerPrefs.SetInt(Prefstype.JoystickyPos, (int)Joystick.transform.localPosition.z);
        PlayerPrefs.SetInt(Prefstype.JumpButtonxPos, (int)JumpButton.transform.localPosition.x);
        PlayerPrefs.SetInt(Prefstype.JumpButtonyPos, (int)JumpButton.transform.localPosition.z);
        PlayerPrefs.SetInt(Prefstype.Item1xPos, (int)Item1.transform.localPosition.x);
        PlayerPrefs.SetInt(Prefstype.Item1yPos, (int)Item1.transform.localPosition.z);
        PlayerPrefs.SetInt(Prefstype.Item2xPos, (int)Item2.transform.localPosition.x);
        PlayerPrefs.SetInt(Prefstype.Item2yPos, (int)Item2.transform.localPosition.z);
    }
    void CastRay(PointerEventData ped)  
    {
        target = null;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
          
            target = hit.collider.gameObject;
            OnDrag(ped);
        }
    }
}
