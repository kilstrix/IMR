using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator mAnimator;

    public Transform otherCactus;
    public float attackDistance = 0.25f;
    private bool isInAttackRange = false;

    public enum CactusType { First, Second }
    public CactusType cactusType;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (mAnimator == null) return;
        if (Input.GetKeyDown(KeyCode.T))
        {
            mAnimator.SetTrigger("TrAttack");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            mAnimator.SetTrigger("TrJump");
        }

        if (otherCactus == null) return;

        float distance = Vector3.Distance(transform.position, otherCactus.position);

        if (distance <= attackDistance && !isInAttackRange)
        {
            isInAttackRange = true;

            if (cactusType == CactusType.First)
            {
                mAnimator.SetTrigger("TrAttack");
            }
            else if (cactusType == CactusType.Second)
            {
                mAnimator.SetTrigger("TrJump");
            }
        }
        else if (distance > attackDistance && isInAttackRange)
        {
            isInAttackRange = false;
        }
    }
}
