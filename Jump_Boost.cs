using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Jump_Boost : MonoBehaviour
{
   
    public PLayerBehavior pb;
    public float jumpForce = 10f; // how much force to add to the player's jump
    public float duration = 10f; // how long the jump boost lasts in seconds

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(JumpBoostCoroutine(other.gameObject));
            gameObject.SetActive(false); // hide the power-up after it's been collected
        }

    }

    private IEnumerator JumpBoostCoroutine(GameObject player)
    {
        // store the player's original jump force
        float originalJumpForce = pb.jumpVelocity;

        // increase the player's jump force
        pb.jumpVelocity += jumpForce;

        Destroy(this.transform.parent.gameObject);

        // wait for the duration of the jump boost
        yield return new WaitForSeconds(duration);

        // reset the player's jump force to its original value
        pb.jumpVelocity = originalJumpForce;

    }
}

