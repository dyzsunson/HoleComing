Shader "Custom/test2" {
		Properties{
			_MainTex("Base (RGB)", 2D) = "white" {}
		}
		SubShader{
		Tags{ "RenderType" = "Opaque" "Queue" = "Transparent" }
		LOD 200

CGPROGRAM
#pragma surface surf Lambert alpha  

		sampler2D _MainTex;
		float _TransVal;

		uniform float _Points[600];
		int _width = 30;
		int _height = 20;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
	
			float x = (IN.worldPos.x + 0.75 - 0.025) * 20;
			float y = (1.0 - IN.worldPos.y) * 20;

			if (x >= 30 || x < 0 || y >= 20 || y < 0)
				o.Alpha = 1.0;
			else
				{
				int y1 = y;
				int x1 = x;
				float k = _Points[y1 * 30 + x1];
				if (k > 0.5)
					o.Alpha = 0.0;
				else
					o.Alpha = 1.0;
				// o.Alpha = 0.0;
			}

		}
		ENDCG
		}
			FallBack "Diffuse"
	}