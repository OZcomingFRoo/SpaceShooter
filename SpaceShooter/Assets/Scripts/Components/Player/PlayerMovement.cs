using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float horizontalSpeed;
    [SerializeField]
    float verticalSpeed;

    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
    private float XRadius { get { return transform.lossyScale.x / 2; } }
    private float YRadius { get { return transform.lossyScale.y / 2; } }

    void Start()
    {
        if (horizontalSpeed <= 0) horizontalSpeed = 5;
        if (verticalSpeed <= 0) verticalSpeed = 5;
    }
    
    void Update()
    {
        float YMovement = AxesUtils.GetYAxes();
        float newYPos = Mathf.Clamp(Position.y + YMovement * Time.deltaTime * horizontalSpeed,
            CameraBoundries.YMin() + this.YRadius, 0 - this.YRadius);

        float XMovement = AxesUtils.GetXAxes();
        float newXPos = Mathf.Clamp(Position.x + XMovement * Time.deltaTime * verticalSpeed,
            CameraBoundries.XMin() + this.XRadius, CameraBoundries.XMax() - this.XRadius);

        Position = new Vector3(newXPos, newYPos,1);
    }
}
