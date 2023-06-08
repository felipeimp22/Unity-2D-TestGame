using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character2DController : MonoBehaviour
{
    public float MovementSpeed = 4;
    public float JumpForce = 4;
    private Rigidbody2D _rigidbody;
    
    public projectileBehaviour ProjectilePreFab;

    public Transform LaunchOffset;

    // Start is called before the first frame update
    private void Start(){
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update(){
        var movement = Input.GetAxis("Horizontal");
        var jump = Input.GetAxis("Vertical");
        var spaceJump = Input.GetButtonDown("Jump");
        var castSpell = Input.GetButtonDown("Fire1");
        
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        
        // Turns the character to side you're walking
        if(!Mathf.Approximately(0,movement)) transform.rotation = movement > 0 ? Quaternion.Euler(0,180,0): Quaternion.identity;

        //Ensure that space will jump
        if(spaceJump && Mathf.Abs(_rigidbody.velocity.y) < 0.001f){
            _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
        }
        //Ensure that arrow up will jump like space
        if(jump > 0  && Mathf.Abs(_rigidbody.velocity.y) < 0.001f){
            _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
        }

        if(castSpell){
            Instantiate(ProjectilePreFab,LaunchOffset.position,transform.rotation);
        }
    }
}
