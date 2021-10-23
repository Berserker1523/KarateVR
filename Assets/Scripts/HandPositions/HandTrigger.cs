using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    [SerializeField] private HandTags handTag;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material materialGreen;
    [SerializeField] private Material materialYellow;

    private void OnTriggerStay(Collider other)
    {
        GameObject controller = other.gameObject;
        Debug.Log($"OnTriggerStay: {other.gameObject.name}");
        if (controller.CompareTag(handTag.ToString()))
        { 
        
        if (controller.GetComponent<HandAnimationController>().CurrentAnimation == HandAnimation.Fist)
            {
                Debug.Log($"{handTag}Rotation: {other.gameObject.transform.eulerAngles}");
                if (/*(controller.transform.eulerAngles.x >= 10.0f && controller.transform.eulerAngles.x <= 30.0f) && */(controller.transform.eulerAngles.z >= 150.0f && controller.transform.eulerAngles.z <= 210.0f))
                {
                    Debug.Log($"GREEN");
                    meshRenderer.material = materialGreen;
                }
                else
                {
                    Debug.Log($"YELLOW1");
                    meshRenderer.material = materialYellow;
                }
            }
            else
            {
                Debug.Log($"YELLOW2");
                meshRenderer.material = materialYellow;
            }
       }
        /*else
        {
            Debug.Log($"YELLOW3");
            meshRenderer.material = materialYellow;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject controller = other.gameObject;
        if (controller.CompareTag(handTag.ToString()))
        {
            Debug.Log($"YELLOW4");
            meshRenderer.material = materialYellow;
        }
    }
}
