Shader "Custom/LitGameObject"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _ShadowColor ("Shadow Color", Color) = (.3,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            float4 _Color;
            float4 _ShadowColor;
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float3 lightDir = float3(0, 1, -.4);
                float mix_factor = dot(lightDir, i.normal);

                // return float4(i.normal, 1);
                return lerp(_ShadowColor, _Color, mix_factor);
            }
            ENDCG
        }
    }
}
