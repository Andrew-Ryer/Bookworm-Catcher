using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioClip singleJump;
    [SerializeField] private AudioClip doubleJump;
    [SerializeField] private AudioClip landing;
    [SerializeField] private AudioClip walking;
    private AudioSource _audioSource;
    private float walkingClipTimer = 0f;
    private float walkingClipTimerMax = 0.19f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player.SingleJumpActivated += Player_SingleJumpActivated;
        player.DoubleJumpActivated += Player_DoubleJumpActivated;
        player.LandingActivated += Player_LandingActivated;
    }

    private void Update()
    {
        if (player.isWalking())
        {
            if (walkingClipTimer <= 0f)
            {
                walkingClipTimer = walkingClipTimerMax;
                playWalkingClip();
            }
        }
        if (walkingClipTimer > 0f)
        {
            walkingClipTimer -= Time.deltaTime;
        }
    }

    private void playWalkingClip()
    {
            _audioSource.PlayOneShot(walking);
    }

    private void Player_LandingActivated(object sender, EventArgs e)
    {
        _audioSource.PlayOneShot(landing);
    }

    private void Player_DoubleJumpActivated(object sender, EventArgs e)
    {
        _audioSource.PlayOneShot(doubleJump);
    }

    private void Player_SingleJumpActivated(object sender, EventArgs e)
    {
        _audioSource.PlayOneShot(singleJump);
    }
}
