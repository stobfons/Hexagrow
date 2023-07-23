using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewItem : MonoBehaviour
{
[SerializeField]
private Image childImage;

public void changeImage(Sprite image){
childImage.sprite = image;
}
}
