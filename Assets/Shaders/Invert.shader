Shader "ddShaders/dd_Invert_Mask_Compatible" {
    Properties 
    {
        _Color ("Tint Color", Color) = (1,1,1,1)
        [HideInInspector] _MainTex ("Texture", 2D) = "white" {}
        
        // --- REQUIRED FOR UI MASKING ---
        [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
        [HideInInspector] _Stencil ("Stencil ID", Float) = 0
        [HideInInspector] _StencilOp ("Stencil Operation", Float) = 0
        [HideInInspector] _StencilWriteMask ("Stencil Write Mask", Float) = 255
        [HideInInspector] _StencilReadMask ("Stencil Read Mask", Float) = 255
        [HideInInspector] _ColorMask ("Color Mask", Float) = 15
    }
    
    SubShader 
    {
        Tags 
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
        }

        // --- REQUIRED FOR UI MASKING ---
        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp] 
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }
        ColorMask [_ColorMask]

        Cull Off
        Lighting Off
        ZWrite Off          
        ZTest [unity_GUIZTestMode] 
        
        // Your inversion blending math
        Blend OneMinusDstColor OneMinusSrcAlpha 
        BlendOp Add
        
        Pass
        { 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag 
            #include "UnityCG.cginc"

            uniform float4 _Color;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float4 color  : COLOR;  
            };

            struct fragmentInput
            {
                float4 pos   : SV_POSITION;
                float4 color : COLOR0; 
            };

            fragmentInput vert(vertexInput i)
            {
                fragmentInput o;
                o.pos = UnityObjectToClipPos(i.vertex); 
                o.color = _Color;
                return o;
            }

            half4 frag(fragmentInput i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }
    }
}
