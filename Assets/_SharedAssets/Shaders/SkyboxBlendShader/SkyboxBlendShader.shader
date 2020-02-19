Shader "Custom/Skybox Blend"{

	Properties{

		[Header(Settings)]
		_BlendAmount("Blend Amount", Range(0, 1)) = 0.5
		_YRotationAmount("Y Rotation Amount", Range(0, 360)) = 0

		[Header(Skybox Day)]
		[NoScaleOffset]_Day_Skybox_Cubemap("Day Skybox (RGB)", Cube) = "white" {}
		_Day_Tint("Day Tint", Color) = (0,0,0,0)

		[Header(Skybox Night)]
		[NoScaleOffset]_Night_Skybox_Cubemap("Night Skybox (RGB)", Cube) = "grey" {}
		_Night_Tint("Night Tint", Color) = (0,0,0,0)

	}

	SubShader{
		Tags {
			"Queue"="Background"
			"RenderType"="Background"
			"PreviewType"="Skybox"
		}

		Cull Off
		ZWrite Off

		Pass{

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			//Blend Settings
			float _BlendAmount;
			float _YRotationAmount;

			// Day Values
			samplerCUBE _Day_Skybox_Cubemap;
			float4 _Day_Tint;

			// Night Values
			samplerCUBE _Night_Skybox_Cubemap;
			float4 _Night_Tint;

			float3 RotateAroundYInDegrees (float3 vertex, float degrees){
				float alpha = degrees * UNITY_PI / 180.0;
				float sina, cosa;
				sincos(alpha, sina, cosa);
				float2x2 m = float2x2(cosa, -sina, sina, cosa);
				return float3(mul(m, vertex.xz), vertex.y).xzy;
			}

			struct appdata{
				float4 vertex : POSITION;
			};

			struct v2f{
				float4 vertex : SV_POSITION;
				float3 texcoord0 : TEXCOORD0;
			};

			v2f vert (appdata IN){

				v2f OUT;
				float3 rotatedAmount = RotateAroundYInDegrees(IN.vertex, _YRotationAmount);
				OUT.vertex = UnityObjectToClipPos(rotatedAmount);
				OUT.texcoord0 = IN.vertex.xyz;
				return OUT;

			}

			fixed4 frag(v2f IN) : SV_Target{

				fixed4 dayTextureColor = texCUBE(_Day_Skybox_Cubemap, IN.texcoord0) * _Day_Tint;
				fixed4 nightTextureColor = texCUBE(_Night_Skybox_Cubemap, IN.texcoord0) * _Night_Tint;

				return lerp(dayTextureColor, nightTextureColor, _BlendAmount);

			}

			ENDCG

		}
	}
	
}
