using UnityEngine;

public class JumpObject : MonoBehaviour
{
    [Tooltip("튕겨 나가는 힘")]
    public float jumpForce = 75f;

    [Tooltip("튕겨 나가는 방향 (기본은 위로)")]
    public Vector3 launchDirection = Vector3.up;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 기존 속도 제거 후, 위로 힘 가함
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(launchDirection.normalized * jumpForce, ForceMode.Impulse);
                Debug.Log("점프대 발동: 플레이어 튕김");
            }
        }
    }
}