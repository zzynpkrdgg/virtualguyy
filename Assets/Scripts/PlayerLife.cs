using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void Die()
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
        Restartlevel();
       
        }
    public void Restartlevel()
    {
        StartCoroutine(Respawn());

    }
    private IEnumerator Respawn()
    {   
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("alivee");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(1.5f);
        
        yield break;
    }
    }
