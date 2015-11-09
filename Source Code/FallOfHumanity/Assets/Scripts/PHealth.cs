using UnityEngine;
using System.Collections;

public class PHealth : MonoBehaviour
{
	public int damage = 0;                         // How much health the player has left.
	public AudioSource deathSound;                         // The sound effect of the player dying.

	private Animator anim;                              // Reference to the animator component.
	private bool playerDead;                            // A bool to show if the player is dead or not.

	void Start ()
	{
        anim = GetComponent<Animator>();
	
	}

	
	public void Hit ()
	{
		// Decrement the player's health by amount.
        if (damage < 3)
        {
            damage++;
            anim.SetInteger("DamageVal", damage);
        }
	}

    void ChangeAnimation()
    {
        
    }

}