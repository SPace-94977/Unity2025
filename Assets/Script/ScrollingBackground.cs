using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 0.02f; // Speed of which the background scrolls down

    Material myMaterial;
    Vector2 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Offset is a set of coordinates. Since we only want to apply an offset to the Y value of our image
        // We leave X as 0 and Y is set to the backgroundSpeed
        offset = new Vector2(0f, backgroundSpeed);
        // The GetComponent function allows us to access the MeshRenderer component of the Background object
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
