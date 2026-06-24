using UnityEngine;

public class DisolveDriver : MonoBehaviour
{
    public Renderer targetRenderer;
    public string propertyName = "_Disolve_Amount";
    public float duration = 1.5f;
    public bool pingPong = true;
    private int propertyId;
    private float elapsed = 0f;

    private MaterialPropertyBlock block;
    
    private void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
        block = new MaterialPropertyBlock();
    }
    private void Update()
    {
        elapsed += Time.deltaTime;
        float amount = pingPong ? Mathf.PingPong(elapsed / duration, 1f) : Mathf.Clamp01(elapsed / duration);
        targetRenderer.GetPropertyBlock(block);
        block.SetFloat(propertyName, amount);
        targetRenderer.SetPropertyBlock(block);
    }
}
