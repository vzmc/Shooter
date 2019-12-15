using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float speed;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var vector = new Vector3(x, 0, y);
        if(vector.sqrMagnitude > 1f)
        {
            vector.Normalize();
        }

        if (Mathf.Abs(x) < float.Epsilon && Mathf.Abs(y) < float.Epsilon)
        {
            return;
        }

        var direction = cameraTransform.TransformDirection(vector);
        direction.y = 0;
        direction = direction.normalized * vector.magnitude;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
