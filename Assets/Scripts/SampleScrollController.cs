using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScrollController : MonoBehaviour {

	/// <summary>
	/// スクロールさせたい要素の複製元
	/// </summary>
	[SerializeField]
	private GameObject _scrollElementOrigin;

	/// <summary>
	/// 描画したい範囲のRectTransform
	/// 	Imageとか
	/// </summary>
	[SerializeField]
	private RectTransform _targetViewRect;

	/// <summary>
	/// スクロールさせる要素の親
	/// </summary>
	[SerializeField]
	private Transform _scrollContentParent;

	// Use this for initialization
	void Start () {
		for(int i = 0;i < 100; i++){
			SpawnScrollObject();
		}
		_scrollElementOrigin.SetActive(false);
	}

	private void SpawnScrollObject(){
		var scrollElement = Instantiate(_scrollElementOrigin);
		scrollElement.transform.SetParent(_scrollContentParent);
		var observer = scrollElement.GetComponent<ViewRectObserveComponent>();
		var image = scrollElement.GetComponent<Image>();
		//observer.Initialize(_targetViewRect, (entered) => SetImageEnable(image, entered));
		observer.Initialize(_targetViewRect, (entered) => ChangeColor(image, entered));
	}

	private void ChangeColor(Image image,bool isBlue){
		image.color = (isBlue) ? Color.blue : Color.red;
	}

	private void SetImageEnable(Image image,bool isActive){
		image.enabled = isActive;
	}
}