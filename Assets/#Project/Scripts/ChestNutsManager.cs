using UnityEngine;
[RequireComponent(typeof(Animator))]
public class ChestNutsManager : MonoBehaviour
{
    // [SerializeField] private Animation youranimation;// = GetComponent<Animation> ();
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("chestnut anim");  
            animator.SetBool("is caught", true);     
            
        }
    }
}
