using UnityEngine;
using System.Collections;

public class PHealth : MonoBehaviour
{
	public float health = 100f;                         // How much health the player has left.
	public AudioSource deathSound;                         // The sound effect of the player dying.

	private Animator anim;                              // Reference to the animator component.
	private bool playerDead;                            // A bool to show if the player is dead or not.

	void Update ()
	{
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// ... and if the player is not yet dead...
			if(!playerDead)
			{
				playerDead = true;
				deathSound.Play();
				Destroy (this);
			}
				
			else
			{

			}
		}
	}

	
	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		health -= amount;
	}
}