using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLineRendererSortingLayer : MonoBehaviour 
{

	public LineRenderer lr;
	public string SortingLayer;
	public int OrderInLayer;

	/*void Awake() 
	{
		GetComponent<Outline>().enabled = true;
		lr = this.GetComponent<LineRenderer>();
	}

	void Start() 
	{
		lr.sortingLayerName = SortingLayer;
		lr.sortingOrder = OrderInLayer;
	}
	
	void SetLROrder(int newOrderInLayer = 0)
	{
		lr.sortingOrder = newOrderInLayer;
	}*/
}