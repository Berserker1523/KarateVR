using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller controller;
    [SerializeField] private Animator animator;

    private HandAnimation currentAnimation;
    public HandAnimation CurrentAnimation => currentAnimation;

    private void Update()
    {
        OVRInput.Update();
        bool primaryHandTrigger = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);
        bool primaryIndexTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller);
        animator.SetBool(Animator.StringToHash(HandAnimation.Fist.ToString()), primaryHandTrigger && primaryIndexTrigger);
        currentAnimation = primaryHandTrigger && primaryIndexTrigger ? HandAnimation.Fist : HandAnimation.Open;
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}
