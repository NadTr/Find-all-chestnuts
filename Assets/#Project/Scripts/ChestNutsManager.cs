using UnityEngine;

public class ChestNutsManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("one chestnut");       
            
        }

        // if (typeof(other) == RaccoonController)
        // {
        //     other.CaughtAChestnut();
        // this.gameObject.SetActive(false);
        // }
    }
}
