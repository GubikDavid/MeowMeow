using UnityEngine;

public class FollowYarn : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private float[] rotations = {22.5f, 11.19f, -.376f, -12.183f, -19.7f};
    void Update()
    {
        int num = (int)(Health.health / 20) - 1;
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - (num <= 3 ? .595f : target.transform.localScale.x / 2 + .15f));
        Vector3 eulers = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(new Vector3(num < 3 ? rotations[num] : rotations[4], eulers.y, eulers.z)), Time.deltaTime / .8f);
    }
}
