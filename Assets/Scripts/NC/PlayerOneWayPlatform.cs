using System.Collections;
using UnityEngine;

//most of this code was pulled from this video https://www.youtube.com/watch?v=7rCUt6mqqE8
public class PlayerOneWayPlatform : MonoBehaviour
{
    private const string GROUND_LAYER = "GroundLayer";
    
    private GameObject _currentOneWayPlatform;
    [SerializeField] CapsuleCollider2D _playerCollider;
    [SerializeField] PlayerRefactor _player;
    

    private void Update()
    {
        //if the player is dropping then disable the current collision
        if (_player.IsDropping())
        {
            Debug.Log("Platform_Update_Dropping");
            if (_currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Platform_CollisionEnter");
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER))
        {
            Debug.Log("Platform_CollisionEnter_Ground");
            _currentOneWayPlatform = collision.gameObject;
            _player.SetIsDropping(false); //player should not drop after hitting another block
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Platform_CollisionExit");
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER))
        {
            _currentOneWayPlatform = null;
            //_player.SetIsDropping(false); //player should not drop after exiting one of the blocks
        }
    }

    private IEnumerator DisableCollision()
    {
        Debug.Log("Platform_DisableCollision");
        BoxCollider2D platformCollider = _currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_playerCollider, platformCollider);
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(_playerCollider, platformCollider, false);
        _player.SetIsDropping(false);
    }
}
