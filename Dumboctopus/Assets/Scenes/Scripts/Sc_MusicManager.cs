using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_MusicManager : MonoBehaviour
{
    public GameObject getAnimator;
    private Animator animator;
    private string isDead = "isDead";
    private string isWalking = "isWalking";
    private string isJumping = "isJumping";
    private string isSpitting = "isSpitting";
    public AudioSource sounds;
    private AudioClip deathSound;
    private AudioClip jumpSound;
    private AudioClip walkSound;
    private AudioClip spittingSound;
    public float timePlayingWalkingSoundAgain = 0.5f;
    public bool playOnlyOnceDeathSound;
    public bool playOnlyOnceJumpSound;
    public bool playOnlyOnceSpittingSound;
    
    void Start()
    {
        animator = getAnimator.GetComponent<Animator>();
        deathSound = (AudioClip)Resources.Load("deathSound");
        walkSound = (AudioClip)Resources.Load("walkSound");
        jumpSound = (AudioClip)Resources.Load("jumpSound");
        spittingSound = (AudioClip)Resources.Load("spittingSound");
        playOnlyOnceDeathSound = true;
        playOnlyOnceJumpSound = true;
        playOnlyOnceSpittingSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool(isDead) && playOnlyOnceDeathSound)
        {
            sounds.pitch = 1f;
            sounds.clip = deathSound;
            sounds.PlayOneShot(deathSound, 0.5f);
            playOnlyOnceDeathSound = false;
        }
        else if(!animator.GetBool(isDead))
        {
            playOnlyOnceDeathSound = true;
        }
        if(animator.GetBool(isWalking) && !(animator.GetBool(isJumping) || animator.GetBool(isSpitting) || animator.GetBool(isDead)))
        {
            int randomSoundRandomizer = Random.Range(0, 5);
            timePlayingWalkingSoundAgain += Time.deltaTime;
            if(timePlayingWalkingSoundAgain >= 0.5f)
            {
                sounds.clip = walkSound;
                if(randomSoundRandomizer == 0)
                {
                    sounds.pitch = 1f;
                    sounds.Play();
                }
                if(randomSoundRandomizer == 1)
                {
                    sounds.pitch = 1.2f;
                    sounds.Play();
                }
                if(randomSoundRandomizer == 2)
                {
                    sounds.pitch = 0.9f;
                    sounds.Play();
                }
                if(randomSoundRandomizer == 3)
                {
                    sounds.pitch = 1.1f;
                    sounds.Play();
                }
                if(randomSoundRandomizer == 4)
                {
                    sounds.pitch = 1.3f;
                    sounds.Play();
                }
                if(randomSoundRandomizer == 5)
                {
                    sounds.pitch = 0.8f;
                    sounds.Play();
                }
                timePlayingWalkingSoundAgain = 0f;
            }
        }
        else if(!animator.GetBool(isWalking))
        {
            timePlayingWalkingSoundAgain = 1f;
        }
        if(animator.GetBool(isJumping) && playOnlyOnceJumpSound)
        {
            sounds.pitch = 1f;
            sounds.clip = jumpSound;
            sounds.PlayOneShot(jumpSound, 0.5f);
            playOnlyOnceJumpSound = false;
        }
        else if(!animator.GetBool(isJumping))
        {
            playOnlyOnceJumpSound = true;
        }
        if(animator.GetBool(isSpitting) && playOnlyOnceSpittingSound)
        {
            sounds.pitch = 1f;
            sounds.clip = spittingSound;
            sounds.PlayOneShot(spittingSound, 0.5f);
            playOnlyOnceSpittingSound = false;
        }
        else if(!animator.GetBool(isSpitting))
        {
            playOnlyOnceSpittingSound = true;
        }
    }
}
