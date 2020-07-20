using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    public GameObject fireballPrefab;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        Vector2 shootingDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        shootingDirection.Normalize();
        if (Input.GetButtonDown("Fire1")) {
            GameObject fireball = Instantiate(fireballPrefab, transform.position,  Quaternion.identity);
            fireball.GetComponent<Rigidbody2D>().velocity = shootingDirection * 4.0f;
            fireball.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(fireball, 2.0f);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        
        transform.position = transform.position + movement * Time.deltaTime;
    }
}
