Shader "Custom/GradientSpeedItem"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (0.776, 0.290, 0.290, 1.0) //198/255f,74/255f,74/255f,255/255f
        _Color2 ("Color 2", Color) = (0.824, 0.545, 0.867, 1.0) //210/255f,139/255f,221/255f,255/255f
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color1;
            fixed4 _Color2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return lerp(_Color1, _Color2, i.uv.y);
            }
            ENDCG
        }
    }
}
