Shader "Custom/ZoneWall" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader {
		Tags { "RenderType"="Transparent" }
		LOD 200
		
		Pass
		{
			
			AlphaTest Greater 0.0
			Cull Off
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
	
			struct v2f {
			    float4 pos : SV_POSITION;
			    float2 uv : TEXCOORD0;
			};
			
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			half4 _Color;
			
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord.xy, _MainTex);
				o.uv.y += _Time.z;
				return o;
			}
			
			half4 frag(v2f i) : COLOR
			{
				return tex2D(_MainTex, i.uv) * _Color;
			}
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
