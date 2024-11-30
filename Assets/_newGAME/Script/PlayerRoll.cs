using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    public float rollDistance = 5f; // Roll sırasında karakterin gideceği mesafe
    public float rollDuration = 0.5f; // Roll süresi
    public float rollDelay = 0.3f; // Roll başlamadan önceki gecikme süresi

    private float rollSpeed; // Roll hızını hesaplamak için kullanılacak
    private Vector3 rollDirection; // Roll yönü
    private bool isRolling = false; // Roll yapılıp yapılmadığını kontrol etmek için
    private bool isDelaying = false; // Roll öncesi gecikme süresinde olup olmadığını kontrol etmek için

    private CharacterController _characterController; // Karakter kontrolcüsü
    private Animator _animator; // Animator bileşeni
    private float rollStartTime; // Roll'un başladığı zamanı tutmak için
    private float delayStartTime; // Gecikme süresinin başladığı zamanı tutmak için

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        rollSpeed = rollDistance / rollDuration; // Roll hızını hesapla
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling && !isDelaying)
        {
            StartRollDelay();
        }

        if (isDelaying)
        {
            CheckRollDelay();
        }

        if (isRolling)
        {
            PerformRoll();
        }
    }

    private void StartRollDelay()
    {
        isDelaying = true;
        delayStartTime = Time.time;
    }

    private void CheckRollDelay()
    {
        if (Time.time >= delayStartTime + rollDelay)
        {
            isDelaying = false;
            StartRoll();
        }
    }

    private void StartRoll()
    {
        isRolling = true;
        rollStartTime = Time.time;
        rollDirection = transform.forward; // Karakterin ileri yönünü al
        //_animator.SetTrigger("Roll"); // Roll animasyonunu tetikle
    }

    private void PerformRoll()
    {
        float elapsed = Time.time - rollStartTime; // Geçen süreyi hesapla
        if (elapsed < rollDuration)
        {
            Vector3 move = rollDirection * rollSpeed * Time.deltaTime; // Roll hareketini hesapla
            _characterController.Move(move); // Karakteri hareket ettir
        }
        else
        {
            isRolling = false; // Roll süresi bitince rolling'i durdur
        }
    }
}

