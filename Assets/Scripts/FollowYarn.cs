using UnityEngine;

public class FollowYarn : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    float[] positions = {.57f, .58f, .59f, .595f, .65f, .75f, .85f, .95f, 1.05f, 1.1f};
    float[] rotations = {22.5f, 11.19f, -.376f, -12.183f, -19.7f};
    void Update()
    {
        int num = (int)(Health.health / 20) - 1;
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - positions[num]);
        Vector3 eulers = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(new Vector3(num < 4 ? rotations[num] : rotations[4], eulers.y, eulers.z)), Time.deltaTime / .8f);
    }
    //20hp - z = 0.57
    //100hp => z = 0.6
    //200hp - z = 1.1

    //normalna rotacija -19.7
    //min rotacija 25.436
}
