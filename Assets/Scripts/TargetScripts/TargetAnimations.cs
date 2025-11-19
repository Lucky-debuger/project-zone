using UnityEngine;

public class TargetAnimations : MonoBehaviour
{
    private Animator animator;
    private Target target;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GetComponent<Target>();

        target.OnGetDamaged += Shake;
    }

    private void Shake()
    {
        animator.Play("Shake", 0, 0f);
        Debug.Log("Я получил урон");
    }

    private void OnDestroy()
    {
        if (target != null)
        {
            target.OnGetDamaged -= Shake; 
        }
    }

}
