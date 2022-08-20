using UnityEngine;

public class Example : MonoBehaviour
{
    Animator m_Animator;


    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            m_Animator.SetBool("isDead", true);


        if (Input.GetKeyDown(KeyCode.A))
            m_Animator.SetBool("attack", true);

        var att = m_Animator.GetCurrentAnimatorClipInfo(0);

        if (att[0].clip.name == "attack" && m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75f)
        {
            Debug.Log("Enemy Dead");
        }
    }
}