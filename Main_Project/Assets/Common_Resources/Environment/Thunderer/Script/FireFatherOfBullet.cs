using UnityEngine;

public class FireFatherOfBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject newObject = Instantiate(bullet, transform.position, Quaternion.identity);
            FatherOfBulletMove FOB = newObject.GetComponent<FatherOfBulletMove>();
            if (FOB != null)
            {
                FOB.intitalFatherOfBullet(new Vector3(9.5f, 3.9f));
            }
        }
    }
}
