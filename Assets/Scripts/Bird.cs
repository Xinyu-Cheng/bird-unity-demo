using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    private Vector2 _startPosition;
    [SerializeField] float _launchForce = 500;
    // Start is called before the first frame update
    
    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {    
        _startPosition = _rigidbody2D.position;
       _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown() {
        _spriteRenderer.color = Color.red;
    }

    void OnMouseUp() {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _spriteRenderer.color = Color.white;
    }

    void OnMouseDrag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        if (desiredPosition.x > _startPosition.x) 
            desiredPosition.x = _startPosition.x;
        transform.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay() {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
