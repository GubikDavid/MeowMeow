using UnityEngine;

public class FollowYarn : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private float speed = 12f;
    private float[] positions = {1f, 1.1f, 1.184f, 1.152f, 1.264f};
    private float[] rotations = {25.686f, 21.189f, 13.327f, 3.07f, 0f, -0.229f, -3.855f, -9.909f, -13.367f};
    private void Start()
    {
        Physics.IgnoreCollision(transform.GetChild(1).GetComponent<Collider>(), target.GetComponent<Collider>());
    }
    void Update()
    {
        
        //FollowX();
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        int num = (int)(Health.health / 20) - 1;
        float step = speed * Time.deltaTime;
/*        if (num <= 4)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - .858f), 50f * Time.deltaTime);// transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - .858f);
        else transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - (num <= 9 ? positions[num - 5] : target.transform.localScale.x / 2 + .23f)), 50f * Time.deltaTime);*/
        //else transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - (num <= 9 ? positions[num - 5] : target.transform.localScale.x / 2 + .23f));
        if (num <= 4) transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, target.transform.position.z - .858f), step);
        else transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, target.transform.position.z - (num <= 9 ? positions[num - 5] : 3.23f)), step);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(new Vector3(num < 8 ? rotations[num] : rotations[8], transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)), Time.deltaTime / .8f);
    }
    /*private void FollowX()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }*/
    public void Plus() 
    {
        if(speed < 11) speed++;
        print(speed);
    }
    public void minus() 
    {
        speed--;
        print(speed);
    }
}