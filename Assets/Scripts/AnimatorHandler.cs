using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}
