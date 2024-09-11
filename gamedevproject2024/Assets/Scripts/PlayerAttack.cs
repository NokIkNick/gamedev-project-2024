using UnityEngine;
using UnityEngine.Events;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private UnityEvent onAttack;
    [SerializeField] private int playerAttackDamage = 10 ;

    //private Animator _animator;
    void Start()
    {
       // _animator = GetComponent<Animator>();
        attackHitbox.SetActive(false); // Disable the hitbox at the start
    }

    public void ActivateHitbox()
    {
        attackHitbox.SetActive(true);
        Debug.Log("Hitbox Activated");
    }

    public void DeactivateHitbox()
    {
        attackHitbox.SetActive(false);
        Debug.Log("Hitbox Deactivated");
    }

    /* private void OnTriggerEnter2D(Collider2D collison){
        Debug.Log("Hit Something From Player Attack");
        if(attackHitbox.activeSelf && collison.CompareTag("Enemy")){
            onAttack.Invoke();
            Debug.Log("Hit Enemy");
            collison.GetComponent<Enemy>()?.TakeDamage(1);
        }
    } */

    public int GetAttackDamage(){
        return playerAttackDamage;
    }
}
