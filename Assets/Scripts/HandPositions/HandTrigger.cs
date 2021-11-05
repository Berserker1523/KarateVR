using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    private const float ANGLE_DIFFERENCE = 30.0f;

    [SerializeField] private HandTag handTag;
    [SerializeField] private HandAnimation handAnimationTrigger = HandAnimation.Fist;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material materialGreen;
    [SerializeField] private Material materialYellow;
    [SerializeField] private Transform handTransform;

    public bool IsWellDone;

    private GameObject controller;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"OnTriggerStay: {other.gameObject.name}");

        if (!other.gameObject.CompareTag(handTag.ToString()))
            return;

        controller = other.gameObject;
        if (controller.GetComponent<HandAnimationController>().CurrentAnimation != handAnimationTrigger)
        {
            Debug.Log($"YELLOW2");
            ChangeStatus(false);
            return;
        }

        if (CheckHandRotation())
        {
                    
            ChangeStatus(true);
        }
        else
        {
            Debug.Log($"YELLOW1");
            ChangeStatus(false);
        }

        controller = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(handTag.ToString()))
        {
            Debug.Log($"YELLOW3");
            ChangeStatus(false);
        }
    }

    public void ChangeStatus(bool wellDone)
    {
        if(wellDone)
        {
            Debug.Log($"GREEN");
            meshRenderer.material = materialGreen;
            IsWellDone = true;
        }
        else
        {
            meshRenderer.material = materialYellow;
            IsWellDone = false;
        }
    }

    private bool CheckHandRotation()
    {
        Debug.Log($"{handTag}Rotation: {controller.transform.eulerAngles}");
        if(handAnimationTrigger == HandAnimation.Open)
            return controller.transform.eulerAngles.x >= handTransform.eulerAngles.x - ANGLE_DIFFERENCE && controller.transform.eulerAngles.x <= handTransform.eulerAngles.x + ANGLE_DIFFERENCE;
        else if (handAnimationTrigger == HandAnimation.Fist)
            return controller.transform.eulerAngles.z >= handTransform.eulerAngles.z - ANGLE_DIFFERENCE && controller.transform.eulerAngles.z <= handTransform.eulerAngles.z + ANGLE_DIFFERENCE;

        Debug.LogError("Not Implemented");
        return false;
    }

    private void OnEnable()
    {
        ChangeStatus(false);
        //Invoke("SetToGreen", 5);
    }

    private void SetToGreen()
    {
        string A = transform.parent.gameObject.name;
        ChangeStatus(true);
    }
}
