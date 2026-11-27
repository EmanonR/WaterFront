using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    Animator animator;

    string currentAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        currentAnimation = "";
    }

    public void PlayAnimation(string animationName)
    {
        if (currentAnimation != animationName)
        {
            currentAnimation = animationName;
            animator.Play(animationName);
        }
    }
}
