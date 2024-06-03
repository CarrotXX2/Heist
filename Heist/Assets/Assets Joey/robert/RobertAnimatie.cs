using UnityEngine;

public class AIController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if AI is walking (this is just an example, use your own logic)
        isWalking = CheckIfWalking();

        // Update animator parameter
        animator.SetBool("isWalking", isWalking);
    }

    bool CheckIfWalking()
    {
        // Implement your logic to check if AI is walking
        // For example, check if the AI's velocity is above a certain threshold
        return GetComponent<Rigidbody>().velocity.magnitude > 0.1f;
    }
}
