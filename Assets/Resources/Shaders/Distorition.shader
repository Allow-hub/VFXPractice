Shader "Unlit/Distorition"
{Properties
    {
        _WaveSpeed ("Wave Speed", Float) = 1.0
        _WaveAmplitude ("Wave Amplitude", Float) = 0.1
        _WaveFrequency ("Wave Frequency", Float) = 2.0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 screenUV : TEXCOORD0;
            };
            
            float _WaveSpeed;
            float _WaveAmplitude;
            float _WaveFrequency;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                // スクリーン座標を計算
                float4 screenPos = ComputeScreenPos(o.vertex);
                o.screenUV = screenPos.xy / screenPos.w; // クリッピングスペースからスクリーンスペースへ
                
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // スクリーン座標を使用して波動する歪みを計算
                float2 distortedUV = i.screenUV;
                float time = _Time.y * _WaveSpeed;
                
                // 円形の波動を作成
                float dist = length(distortedUV - 0.5);
                float wave = sin(dist * _WaveFrequency + time) * _WaveAmplitude;
                
                distortedUV += normalize(distortedUV - 0.5) * wave;
                
                // スクリーンカラーを使用して描画
                fixed4 col = float4(1, 1, 1, 1); // デフォルトでは白色
                
                return col;
            }
            ENDCG
        }
    }
}
