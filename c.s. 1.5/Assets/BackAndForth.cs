using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float _minZ = 5f;
    private float _maxZ = -15f;
    private int _directon = 1;

    private void Update()
    {
        transform.Translate(0, 0, _directon * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.position.z < _maxZ || transform.position.z > _minZ)
        {
            bounced = true;
            _directon = -_directon;
        }

        if (bounced)
        {
            transform.Translate(0, 0, _directon * speed * Time.deltaTime);
        }
    }
}
