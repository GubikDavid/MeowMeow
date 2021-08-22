using UnityEngine;

public class FollowYarn : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private float[] positions = {1f, 1.1f, 1.184f, 1.152f, 1.264f};
    private float[] rotations = {25.686f, 21.189f, 13.327f, 3.07f, 0f, -0.229f, -3.855f ,-9.909f, -13.367f};
    void Update()
    {
        int num = (int)(Health.health / 20) - 1;
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - (num <= 4 ? .858f : positions[num-4]));
        Vector3 eulers = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(new Vector3(rotations[num], eulers.y, eulers.z)), Time.deltaTime / .8f);
    }
}
//0.858 - 40

//1.1 - 1.3   = z = 1
