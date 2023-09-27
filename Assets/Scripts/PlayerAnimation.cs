using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator PlayerAnimator;
    [SerializeField]
    private Animator DoorAnimator;
    private readonly int isPlayerOutside = Animator.StringToHash("isPlayerOutside");
    private readonly int isPlayerInside = Animator.StringToHash("isPlayerInside");
    private readonly int isDoorOpen = Animator.StringToHash("isDoorOpen");
    private readonly int isDoorClose = Animator.StringToHash("isDoorClose");
    [SerializeField]
    private Transform CarModel;
    [SerializeField]
    private Transform PlayerHolder;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CarEnterAnimation());
        } 
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(CarExitAnimation());
        }
    } 

    private IEnumerator CarEnterAnimation()
    {
        DoorAnimator.SetBool(isDoorOpen, false);
        DoorAnimator.SetBool(isDoorClose, false);
        PlayerAnimator.SetBool(isPlayerInside, false);
        PlayerAnimator.SetBool(isPlayerOutside, false);
        PlayerAnimator.SetBool(isPlayerOutside, true);
        yield return new WaitForSeconds(1f);
        DoorAnimator.SetBool(isDoorOpen, true);
        yield return new WaitForSeconds(2.3f);
        DoorAnimator.SetBool(isDoorClose, true);
        this.transform.SetParent(CarModel);
    }

    private IEnumerator CarExitAnimation()
    {
        DoorAnimator.SetBool(isDoorOpen, false);
        DoorAnimator.SetBool(isDoorClose, false);
        PlayerAnimator.SetBool(isPlayerInside, false);
        PlayerAnimator.SetBool(isPlayerOutside, false);
        PlayerAnimator.SetBool(isPlayerInside, true);
        yield return new WaitForSeconds(1f);
        DoorAnimator.SetBool(isDoorOpen, true);
        yield return new WaitForSeconds(2.3f);
        DoorAnimator.SetBool(isDoorClose, true);
        this.transform.SetParent(PlayerHolder);
    }
}
