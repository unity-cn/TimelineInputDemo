// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ToonShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_SpecularPower("Specular Power", Range(0.0,1.0)) = 0.01
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecTex("Specular (B&W)", 2D) = "white" {}
		_Ramp("Toon Ramp", 2D) = "white" {}
		[Toggle(SPECULAR_ENABLE)] _SpecularEnable("Enable Specular", Int) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue"="Transparent+2"}
		LOD 200

		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma shader_feature SPECULAR_ENABLE
		#pragma surface surf Ramp fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _Ramp;

		half4 LightingRamp(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			half3 ramp = tex2D(_Ramp, float2(diff, diff)).rgb;
			half4 c;

#if SPECULAR_ENABLE
			half3 h = normalize(lightDir + viewDir);
			float nh = max(0, dot(s.Normal, h));
			float spec = pow(nh, s.Specular * 128.0);
			c.rgb = (s.Albedo * _LightColor0.rgb * ramp + spec * _LightColor0.rgb) * atten;
#else
			c.rgb = s.Albedo * _LightColor0.rgb * ramp * atten;
#endif
			c.a = s.Alpha;
			return c;
		}

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
		};


		sampler2D _MainTex;
		sampler2D _SpecTex;

		float _SpecularPower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Specular = _SpecularPower * tex2D(_SpecTex, IN.uv_MainTex);
		}
		ENDCG

		
	}
	FallBack "Diffuse"
}
