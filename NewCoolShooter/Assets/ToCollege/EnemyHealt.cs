using System.Collections;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] private float _enemyHealth;
    [SerializeField] private float _enemyGetHealth;
    private GameObject _enemy;

    public void ApplyDamage(float damage)
    {
        _enemyHealth -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagEnum.DeflectedBullet.ToString())
        {
            _enemyHealth = 0;
        }
    }

    private void Update()
    {
        if (Death())
        {
            gameObject.SetActive(false);
            PlayerHealt playerHealt = GameObject.FindGameObjectWithTag(TagEnum.Player.ToString()).GetComponent<PlayerHealt>();
            playerHealt.AddHealth(_enemyGetHealth);
            Destroy(gameObject, 1f);
        }
    }

    public bool Death()
    {
        if (_enemyHealth <= 0)
        {
            _enemyHealth = 0;           
            return true;
        }
        return false;
    }
}
