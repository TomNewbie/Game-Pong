using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float bouncyStrength;
    public string soundEffect;
    private void OnCollisionEnter2D(Collision2D collision) {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null){
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bouncyStrength);
            if(soundEffect != "null"){
                FindObjectOfType<AudioManager>().Play(soundEffect);
            }
        }

    }
}
