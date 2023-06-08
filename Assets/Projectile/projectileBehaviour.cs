using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    public float damage = 1;

    // Update is called once per frame
    private void Update(){
      transform.position += -transform.right * Time.deltaTime * speed;  
    }
    private void OnCollisionEnter2D(Collision2D collision){

      var enemy = collision.collider.GetComponent<enemyBehaviour>();
      if(enemy){
        enemy.takeHit(damage);
      }
      Destroy(gameObject);
    }
}
