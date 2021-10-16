using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _rigidbody;
    public float speed = 10f;

    public void AddStartingForce(){
        float x =  Random.value  < 0.5f ? 1.0f : -1.0f;
        float y =  Random.value < 0.5f ? Random.Range(-1.0f,-0.5f): Random.Range(0.5f,1.0f);
        Vector2 direction = new Vector2(x,y);
        this._rigidbody.AddForce(direction * speed);
    }
    public void AddForce(Vector2 force){
        if(this._rigidbody.velocity.x < 15 && this._rigidbody.velocity.y < 15 && this._rigidbody.velocity.y > -15 && this._rigidbody.velocity.x > -15    ){
            this._rigidbody.AddForce(force);            
        }
    }

    public void ResetPosition(){
        this._rigidbody.position = Vector2.zero;
        this._rigidbody.velocity = Vector2.zero;
    }
}
