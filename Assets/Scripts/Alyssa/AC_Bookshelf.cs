using UnityEngine;

public class AC_Bookshelf : MonoBehaviour
{
    public delegate void OnCollisionWormBookshelfFunc(SpriteRenderer spriteRender);
    public static event OnCollisionWormBookshelfFunc OnCollisionWormBookshelf;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bookworm")
        {
            SpriteRenderer spriteRender = gameObject.GetComponentInChildren<SpriteRenderer>();
            OnCollisionWormBookshelf?.Invoke(spriteRender);
            Debug.Log("hit");
        }
            
    }
}
