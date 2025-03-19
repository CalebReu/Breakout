using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private  Image[] lives;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;


    private float containerInitPosition;
    private float moveAmount;
    private void Start()
    {
        Canvas.ForceUpdateCanvases(); // for making sure the data we get is accurate (as the animation software "doTween" is asyncronous and might report the wrong postion)
  
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }
    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetScoreContainer(score));
    }
    public void LoseLife(int i) {
        lives[i].enabled = false;
    }
    private IEnumerator ResetScoreContainer(int score)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}