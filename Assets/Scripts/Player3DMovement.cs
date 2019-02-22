using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DMovement : MonoBehaviour
{   // criando variáveis privadas editáveis no inspector
    [SerializeField][Tooltip ("Velocidade máxima do movimento do player")]
    private float playerTopSpeed; //velocidade máxima do movimento do player
    [SerializeField][Tooltip ("Aceleração do movimento do player")]
    private float playerAcceleration; //aceleração do movimento do player
    [SerializeField][Tooltip ("Altura do pulo do player")]
    private float JumpHeight; //altura do pulo
    [SerializeField][Tooltip ("Qual RigidBody receberá forças físicas deste script")]
    private Rigidbody rbPlayer; //qual rigidbody receberá forças físicas deste script
    [SerializeField][Tooltip ("Player pode dar pulo duplo?")]
    private bool canDoubleJump; // se o player pode dar pulo duplo

    //criando variáveis privadas
    private float playerCurrentHSpeed; //velocidade horizontal atual do player
    private float playerCurrentVSpeed; //velocidade vertical atual do player
    private float playerHTargetSpeed; // velocidade-alvo do player, que é determinada por quanto o usuário pressiona o direcional horizontal
    private float playerVTargetSpeed; // velocidade-alvo do player, que é determinada por quanto o usuário pressiona o direcional vertical
    private float hInput; // intensidade do input horizontal que o usuário está apertando
    private float vInput; // intensidade do input vertical que o usuário está apertando
    private bool isGrounded; //se o player está com os pés no chão ou não
    private bool doubleJumpAvailable;  // se o player tem o segundo pulo disponível

    // vê se o collider que toca o pé do jogador é walkable, pra saber se jogador pode ou não pular
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Walkable")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    // executa a cada frame, num tempo fixo.
    private void Update()
    {
        //capta se o botão pulo está pressionado ou nao.
        float jumpInput;

        // converte a bool do GetButton "Jump" em float
        if (Input.GetButtonDown("Jump") == true)
        {
            jumpInput = 1.0f;
        }
        else
        {
            jumpInput = 0.0f;
        }

        // se o jogador estiver com os pés no chão e puder dar pulo duplo,
        // pulo duplo fica disponível
        if (isGrounded == true && canDoubleJump == true)
        {
            doubleJumpAvailable = true;
        }
        if(isGrounded == true)
        {
            // aplica força vertical pra cima pra fazer o player pular
            rbPlayer.AddRelativeForce(0.0f, JumpHeight * jumpInput * 10000f, 0.0f);
        }
        else
        {
            if(doubleJumpAvailable == true)
            {
                if (jumpInput == 1f)
                {
                    rbPlayer.velocity = new Vector3(0f, 0f, 0f);
                }
                rbPlayer.AddRelativeForce(0.0f, JumpHeight * jumpInput * 10000f, 0.0f);
                if(jumpInput == 1.0f)
                {
                    doubleJumpAvailable = false;
                }
            }
        }

    }
    private void FixedUpdate()
    {
        //pega os inputs setados como eixos horizontal e vertical
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        Vector2 inputDirection = new Vector2(hInput, vInput);

        //velocidade alvo do player, limitda a quanto o input eixo horizontal é pressionado
        playerHTargetSpeed = hInput * (playerTopSpeed * 0.01f);
        playerVTargetSpeed = vInput * (playerTopSpeed * 0.01f);

        //velocidade atual do player. é calculada interpolando entre [a velocidade do player no frame anterior] e [a velocidade alvo] de acordo com a [Aceleração]
        playerCurrentHSpeed = Mathf.Lerp(playerCurrentHSpeed, playerHTargetSpeed, playerAcceleration * Time.deltaTime);
        playerCurrentVSpeed = Mathf.Lerp(playerCurrentVSpeed, playerVTargetSpeed, playerAcceleration * Time.deltaTime);

        // se ususario nao estiver apertando nem pra frente nem pra tras,
        // deve checar se a velocidade atual é baixa o suficiente pra parar o player de vez
        if (hInput == 0.0f)
        {
            if (Mathf.Abs(playerCurrentHSpeed) < 0.01f)
            {
                playerCurrentHSpeed = 0.0f;
            }
        }
        // Se ele ainda estiver apertando pra frente ou pra tras,
        // checa se a velocidade atual é alta o suficiente pra colocar o player na velocidade máxima
        else
        {
            if (Mathf.Abs(playerCurrentHSpeed) > (playerTopSpeed * 0.01f) * 0.95f)
            {
                playerCurrentHSpeed = (playerCurrentHSpeed / Mathf.Abs(playerCurrentHSpeed)) * (playerTopSpeed * 0.01f);
            }
        }
        if (vInput == 0.0f)
        {
            if (Mathf.Abs(playerCurrentVSpeed) < 0.01f)
            {
                playerCurrentVSpeed = 0.0f;
            }
        }
        else
        {
            if (Mathf.Abs(playerCurrentVSpeed) > (playerTopSpeed * 0.01f) * 0.95f)
            {
                playerCurrentVSpeed = (playerCurrentVSpeed / Mathf.Abs(playerCurrentVSpeed)) * (playerTopSpeed * 0.01f);
            }
        }
        // cria o vector 3 requerido pelo translate abaixo
        Vector3 playerTranslate = new Vector3(playerCurrentHSpeed, 0.0f, playerCurrentVSpeed);

        // move o player
        this.transform.Translate(playerTranslate);
    }
}

