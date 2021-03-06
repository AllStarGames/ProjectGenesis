﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Outline_Diffuse"
{
	Properties
	{
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline Width", Range(0.0, 1.0)) = 1.0
	}

CGINCLUDE
	#include "UnityCG.cginc"

	struct appdata
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f
	{
		float4 position : POSITION;
		float4 colour	: COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;

	v2f vert(appdata v)
	{
		//just make a copy of incoming vertex data but scaled according to normal direction
		v2f o;
		o.position = UnityObjectToClipPos(v.vertex);

		float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
		float2 offset = TransformViewToProjection(norm.xy);

		o.position.xy += offset * o.position.z * _Outline;
		o.colour = _OutlineColor;
		return o;
	}
ENDCG

	SubShader
	{
		Tags { "Opaque"="Transparent" }
		
		Pass
		{
			Name "OUTLINE"
			Tags {"LightMode" = "Always"}
			Cull Off
			ZWrite Off
			ZTest Always
			ColorMask RGB

			Blend SrcAlpha OneMinusSrcAlpha

CGPROGRAM
#pragma vertex vert
#pragma fragment frag

			half4 frag(v2f i) : COLOR
			{
				return i.colour;
			}
ENDCG
		}

		Pass
		{
			Name "BASE"
			ZWrite On
			ZTest LEqual
			Blend SrcAlpha OneMinusSrcAlpha
			Material
			{
				Diffuse [_Color]
				Ambient [_Color]
			}
			Lighting On
			SetTexture [_MainTex]
			{
				ConstantColor [_Color]
				Combine texture * constant
			}
			SetTexture [_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}

	SubShader
	{
		Tags {"Queue" = "Transparent"}

		Pass
		{
			Name "OUTLINE"
			Tags {"LightMode" = "Always"}
			Cull Front
			ZWrite Off
			ZTest Always
			ColorMask RGB
			
			Blend SrcAlpha OneMinusSrcAlpha

CGPROGRAM
#pragma vertex vert
#pragma exclude_renderers gles xbox360 ps3
ENDCG

			SetTexture [_MainTex]
			{
				combine primary
			}
		}

		Pass
		{
			Name "BASE"
			ZWrite On
			ZTest LEqual
			Blend SrcAlpha OneMinusSrcAlpha
			Material
			{
				Diffuse [_Color]
				Ambient [_Color]
			}
			Lighting On
			SetTexture [_MainTex]
			{
				ConstantColor [_Color]
				Combine texture * constant
			}
			SetTexture [_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}

	FallBack "Diffuse"
}