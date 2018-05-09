Shader "Unlit/Outline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (0,0,0,1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.01
	}

CGINCLUDE
	#include "UnityCG.cginc"

		struct appdata
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		}

		struct v2f
		{
			float4 position : POSITION;
			float3 normal : NORMAL;
		}

		float _OutlineWidth;
		float4 _OutlineColor;

		v2f vert(appdata v)
		{
			v.vertex.xyz *= _Outline;

			v2f o;
			o.position = UnityObjectToClipPos(v.vertex);
			return o;
		}

ENDCG

	SubShader
	{
		Pass
		{
			ZWrite off

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				half4 frag(v2f i) : COLOR
				{
					return _OutlineColor;
				}
			ENDCG
		}

		Pass
		{
			
		}
	}
}
