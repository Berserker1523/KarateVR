using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ButtonTouch : MonoBehaviour
{
    public OVRInput.Button button;
    
    void Start()
    {
        button = OVRInput.Button.One;
        GameObject otherButton = GameObject.Find("BtnResp(Clone)");
        if (otherButton != null)
        {
            if(otherButton.GetComponent<ButtonTouch>().button == OVRInput.Button.One)
                button = OVRInput.Button.Two;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        Debug.Log($"ButtonTouch {OVRInput.Get(button, OVRInput.Controller.Active)}");
        if(OVRInput.Get(button, OVRInput.Controller.Active))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
