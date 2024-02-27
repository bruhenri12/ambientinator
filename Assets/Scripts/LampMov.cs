using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMov : MonoBehaviour
{
    public float speed = 5f; // Velocidade do movimento

    void Update()
    {
        // Obtém a entrada do teclado
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Utiliza as teclas específicas para movimentação (8 para frente, 5 para trás, 4 para a esquerda, 6 para a direita)
        if (Input.GetKey(KeyCode.Keypad8)) // 8 para frente
            verticalInput = 1f;
        else if (Input.GetKey(KeyCode.Keypad5)) // 5 para trás
            verticalInput = -1f;

        if (Input.GetKey(KeyCode.Keypad4)) // 4 para a esquerda
            horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.Keypad6)) // 6 para a direita
            horizontalInput = 1f;

        // Calcula a direção do movimento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Aplica a velocidade ao movimento
        transform.Translate(movement * speed * Time.deltaTime);

        // Garante que o objeto permaneça no plano do chão (opcional)
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
