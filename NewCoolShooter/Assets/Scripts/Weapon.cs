using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    [SerializeField] private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private float _gunDammage;
    [SerializeField] private float _currentAmmo;
    [SerializeField] private float _fireDistance;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider _fireSlider;

    private bool _haveHoot;
    private RaycastHit hitData;

    private void Update()
    {
        _fireSlider.maxValue = startTimeBtwShots;
        _fireSlider.value = timeBtwShots;
        GunShoot();
    }

    private void GunShoot()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                FireRay();
                if ((hitData.transform.tag == TagEnum.Enemy.ToString() || hitData.transform.tag == TagEnum.MeleeAtack.ToString()) && _haveHoot)
                {
                    hitData.transform.GetComponent<EnemyHealt>().ApplyDamage(_gunDammage);
                }
                timeBtwShots = startTimeBtwShots; //Темп стрельбы
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime; //Темп стрельбы
        }
    }

    private void FireRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(ray, out hitData);
  
        float x = hitData.transform.position.x - player.transform.position.x;
        float y = hitData.transform.position.y - player.transform.position.y;

        if (x <= _fireDistance && y <= _fireDistance)
            _haveHoot = true;
        else
            _haveHoot = false;
    }

    public void Reload() //Метод и логика самой перезарядки
    {
        //int reason = sizeClip - currentAmmo;
        //if (allAmmo >= reason)
        //{
        //    allAmmo = allAmmo - reason;
        //    currentAmmo = sizeClip;
        //}
        //else
        //{
        //    currentAmmo = currentAmmo + allAmmo;
        //    allAmmo = 0;
        //}
    }
}
