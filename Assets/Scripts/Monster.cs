using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    bool _hasDead = false;

    void OnCollisionEnter2D(Collision2D collision) {

        if (ShouldDisappearFromCollision(collision)) 
            StartCoroutine(Disappear());
        
    }

    IEnumerator Disappear() {
        _hasDead = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    bool ShouldDisappearFromCollision(Collision2D collision) {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (_hasDead) 
            return false;

        if (bird != null) 
            return true;
    
        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Monster : MonoBehaviour
// {
//     [SerializeField] Sprite _deadSprite;
//     [SerializeField] ParticleSystem _particleSystem;
//     bool _hasDied = false;
//    void OnCollisionEnter2D(Collision2D collision){
//     if (ShouldDissapearFromCollison(collision))
//         Disappear();
//    }
//    bool ShouldDissapearFromCollison(Collision2D collision){
//     if (_hasDied)
//         return false;
//     Bird bird = collision.gameObject.GetComponent<Bird>();
//     if (bird!=null)
//         return true;
//     if (collision.contacts[0].normal.y < -0.5)
//         return true;
//     return false;
//    }
//    void Disappear(){
//         _hasDied = true;
//         GetComponent<SpriteRenderer>().sprite = _deadSprite;
//         _particleSystem.Play();
//         //gameObject.SetActive(false);
//    }
// }

