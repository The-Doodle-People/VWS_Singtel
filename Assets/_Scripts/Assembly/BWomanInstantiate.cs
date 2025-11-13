using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWomanInstantiate : MonoBehaviour {
	private int hairCol;
	private int hairTyp;
	private int faceTyp;
	private int eyeCol;
	private int topCol;
	private int btmCol;
	private int skinTyp;
	private int topTyp;
	private int btmTyp;
	private int jacketCol;
	private int shirtCol;
	private int skirtCol;
	private int pantsCol;
	private int shoesCol;
    private int glassesTyp;



    public enum ShoesColor
	{
		Blue,
		Black,
		Gray,
		LightGray,
		Red,
		White

	}
	public enum JacketColor
	{
		Blue,
		Black,
		Gray,
		LightGray,
		Red,
		White

	}

	public enum SkirtColor
	{
		Blue,
		Black,
		Gray,
		LightGray,
		Red,
		White
	}

	public enum PantsColor
	{
		Blue,
		Black,
		Gray,
		LightGray,
		Red,
		White

	}

	public enum ShirtColor
	{
		Blue,
		Black,
		Gray,
		LightBlue,
		Red,
		White

	}





	public enum HairType
	{
		Medium,
		PonyTail,
		FrenchRoll,
		Short,
		Bun

	}

	public enum HairColor
	{
		Blond,
		White,
		Dark,
		Red,
		Brown

	}

	public enum EyeColor
	{
		Brown,
		Blue,
		Green,
		Black,
		DarkBlue,
		LightBrown

	}


	public enum FaceType
	{
		FaceA,
		FaceB,
		FaceC,
		FaceD,
		FaceE

	}

	public enum SkinType
	{
		Pink,
		Black,
		White,
		Tanned,
		Pale,
		Brown

	}


	public enum TopColors
	{
		WhiteBlue,
		Blue,
		Grey,
		WhitePurple

	}

	public enum TopType
	{
		Shirt,
		Jacket

	}

	public enum BottomType
	{
		Skirt,
		Pants

	}

    public enum GlassesType
    {
        No,
        Glasses,
        SunGlasses

    }


    public Transform prefabObject;

	public FaceType faceType;
    public GlassesType glassesType;
    public SkinType skinType;
	public EyeColor eyeColor;
	public TopType topType;
	public JacketColor jacketColor;
	public ShirtColor shirtColor;
	public BottomType bottomType;
	public PantsColor pantsColor;
	public SkirtColor skirtColor;

	public HairType hairType;
	public HairColor hairColor;
	public ShoesColor shoesColor;
	//public GameObject currentFace;

	// Use this for initialization
	void Start () {
		Transform pref = Instantiate (prefabObject, gameObject.transform.position, gameObject.transform.rotation);
		hairCol = (int)hairColor;
		eyeCol = (int)eyeColor;
		hairTyp = (int)hairType;
		faceTyp = (int)faceType;
		btmTyp = (int)bottomType;
		topTyp = (int)topType;
		skinTyp = (int)skinType;
		jacketCol = (int)jacketColor;
		shirtCol = (int)shirtColor;
		skirtCol = (int)skirtColor;
		pantsCol = (int)pantsColor;
		shoesCol = (int)shoesColor;
        glassesTyp = (int)glassesType;
        pref.gameObject.GetComponent<BWomanCustomise> ().charCustomize(faceTyp, eyeCol, topTyp, btmTyp, hairTyp, hairCol, skinTyp, jacketCol, shirtCol, skirtCol, pantsCol, shoesCol, glassesTyp);

	}

	// Update is called once per frame
	void Update () {

	}
}
