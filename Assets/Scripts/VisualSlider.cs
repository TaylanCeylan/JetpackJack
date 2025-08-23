using UnityEngine;

public class VisualSlider : MonoBehaviour
{
    [SerializeField] float restrictionPointX;
    [SerializeField] private float sliderSpeed;

    private void Update()
    {
        transform.position += new Vector3(-sliderSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -restrictionPointX)
        {
            transform.position = new Vector3(restrictionPointX, transform.position.y, transform.position.z);
        }
    }
}
