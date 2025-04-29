using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WaterControllerGreen : MonoBehaviour
{
    [Header("Wave Settings")]
    public float waveSpeed = 1.5f;
    public float waveHeight = 0.3f;
    public float waveFrequency = 2f;

    [Header("Physics")]
    public float buoyancyForce = 12f;
    public float waterDrag = 3f;
    public float jumpBoost = 8f;

    private SpriteRenderer spriteRenderer;
    private float[] waveOffsets;
    private float textureWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textureWidth = spriteRenderer.bounds.size.x;
        InitializeWaveOffsets();
    }

    void InitializeWaveOffsets()
    {
        int points = Mathf.FloorToInt(textureWidth * 2);
        waveOffsets = new float[points];

        for (int i = 0; i < points; i++)
        {
            waveOffsets[i] = Random.Range(0f, 2f * Mathf.PI);
        }
    }

    void Update()
    {
        AnimateWater();
    }

    void AnimateWater()
    {
        Material mat = spriteRenderer.material;
        mat.SetFloat("_WaveSpeed", waveSpeed);
        mat.SetFloat("_WaveHeight", waveHeight);
        mat.SetFloat("_WaveFrequency", waveFrequency);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            // اعمال نیروی شناوری
            float buoyancy = buoyancyForce * (1 - (other.bounds.min.y - transform.position.y));
            rb.AddForce(Vector2.up * buoyancy);

            // افزایش درگ در آب
            rb.drag = waterDrag;
        }
    }

    public void ApplyJumpBoost(Rigidbody2D playerRb)
    {
        playerRb.AddForce(Vector2.up * jumpBoost, ForceMode2D.Impulse);
    }
}