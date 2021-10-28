using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    private const float ANGLE_DIFFERENCE = 30.0f;

    [SerializeField] private HandTags handTag;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material materialGreen;
    [SerializeField] private Material materialYellow;
    [SerializeField] private Transform handTransform;

    public bool IsGreen;

    /*private void OnEnable()
    {
        Invoke("SetTogREEN", 2);
    }

    private void SetTogREEN()
    {
        string A = transform.parent.gameObject.name;
        ChangeColor(true);
    }*/

    private void OnTriggerStay(Collider other)
    {
        GameObject controller = other.gameObject;
        Debug.Log($"OnTriggerStay: {other.gameObject.name}");
        if (controller.CompareTag(handTag.ToString()))
        { 
            if (controller.GetComponent<HandAnimationController>().CurrentAnimation == HandAnimation.Fist)
            {
                Debug.Log($"{handTag}Rotation: {other.gameObject.transform.eulerAngles}");
                if ((controller.transform.eulerAngles.x >= handTransform.eulerAngles.x - ANGLE_DIFFERENCE && controller.transform.eulerAngles.x <= handTransform.eulerAngles.x + ANGLE_DIFFERENCE) &&
                    (controller.transform.eulerAngles.z >= handTransform.eulerAngles.z - ANGLE_DIFFERENCE && controller.transform.eulerAngles.z <= handTransform.eulerAngles.z + ANGLE_DIFFERENCE))
                {
                    
                    ChangeColor(true);
                }
                else
                {
                    Debug.Log($"YELLOW1");
                    ChangeColor(false);
                }
            }
            else
            {
                Debug.Log($"YELLOW2");
                ChangeColor(false);
            }
       }
        else
        {
            Debug.Log($"YELLOW3");
            ChangeColor(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject controller = other.gameObject;
        if (controller.CompareTag(handTag.ToString()))
        {
            Debug.Log($"YELLOW4");
            ChangeColor(false);
        }
    }

    public void ChangeColor(bool green)
    {
        if(green)
        {
            Debug.Log($"GREEN");
            meshRenderer.material = materialGreen;
            IsGreen = true;
        }
        else
        {
             meshRenderer.material = materialYellow;
            IsGreen = false;
        }
    }
}
