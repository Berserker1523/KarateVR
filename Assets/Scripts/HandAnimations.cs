using UnityEngine;

public enum HandAnimations
{
    Open,
    Fist
}

public class HandAnimations : MonoBehaviour
{
    private const string HOLD = "Hold";

    [SerializeField] private OVRInput.Controller controller;
    [SerializeField] private Animator animator;

    private string currentAnimation;
    public string CurrentAnimation
    {
        get { return CurrentAnimation; }
        set
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool primaryHandTrigger = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);
        bool primaryIndexTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller);
        animator.SetBool(Animator.StringToHash(HOLD), primaryHandTrigger && primaryIndexTrigger);
    }
}
