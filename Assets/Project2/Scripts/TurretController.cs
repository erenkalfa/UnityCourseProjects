using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float turnSpeed;
    
    public GameObject bullet;
    public Transform firePoint;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0,horizontalInput,0)*turnSpeed*Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletObject.GetComponent<Rigidbody>().AddForce(firePoint.forward*5000);
    }
}
