// Compiled shader for PC, Mac & Linux Standalone, uncompressed size: 15.7KB

Shader "Transparent/Cutout/VertexLit" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecColor ("Spec Color", Color) = (1,1,1,0)
 _Emission ("Emissive Color", Color) = (0,0,0,0)
 _Shininess ("Shininess", Range(0.1,1)) = 0.7
 _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 LOD 100
 Tags { "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
 Pass {
  Tags { "LIGHTMODE"="Vertex" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  Lighting On
  AlphaToMask On
  SeparateSpecular On
  Material {
   Ambient [_Color]
   Diffuse [_Color]
   Emission [_Emission]
   Specular [_SpecColor]
   Shininess [_Shininess]
  }
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
  SetTexture [_MainTex] { combine texture * primary double, texture alpha * primary alpha }
 }
 Pass {
  Tags { "LIGHTMODE"="VertexLM" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "normal", Normal
   Bind "texcoord1", TexCoord0
   Bind "texcoord", TexCoord1
  }
  AlphaToMask On
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
  SetTexture [unity_Lightmap] { Matrix [unity_LightmapMatrix] ConstantColor [_Color] combine texture * constant }
  SetTexture [_MainTex] { combine texture * previous double, texture alpha * primary alpha }
 }
 Pass {
  Tags { "LIGHTMODE"="VertexLMRGBM" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "normal", Normal
   Bind "texcoord1", TexCoord0
   Bind "texcoord1", TexCoord1
   Bind "texcoord", TexCoord2
  }
  AlphaToMask On
  AlphaTest Greater [_Cutoff]
  ColorMask RGB
  SetTexture [unity_Lightmap] { Matrix [unity_LightmapMatrix] combine texture * texture alpha double }
  SetTexture [unity_Lightmap] { ConstantColor [_Color] combine previous * constant }
  SetTexture [_MainTex] { combine texture * previous quad, texture alpha * primary alpha }
 }
 Pass {
  Name "CASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "SHADOWSUPPORT"="true" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  Cull Off
  Fog { Mode Off }
  Offset 1, 1
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [unity_LightShadowBias]
Vector 6 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[7] = { program.local[0],
		state.matrix.mvp,
		program.local[5..6] };
TEMP R0;
DP4 R0.x, vertex.position, c[4];
DP4 R0.y, vertex.position, c[3];
ADD R0.y, R0, c[5].x;
MAX R0.z, R0.y, -R0.x;
ADD R0.z, R0, -R0.y;
MAD result.position.z, R0, c[5].y, R0.y;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MOV result.position.w, R0.x;
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 10 instructions, 1 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_LightPositionRange]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[0].xyz, R0, -c[9];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[10], c[10].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Float 0 [_Cutoff]
Vector 1 [_Color]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0 } };
TEMP R0;
TEX R0.w, fragment.texcoord[1], texture[0], 2D;
MUL R0.x, R0.w, c[1].w;
SLT R0.x, R0, c[0];
MOV result.color, c[2].x;
KIL -R0.x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
Float 1 [_Cutoff]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
PARAM c[5] = { program.local[0..2],
		{ 1, 255, 65025, 16581375 },
		{ 0.99900001, 0.0039215689 } };
TEMP R0;
TEX R0.w, fragment.texcoord[1], texture[0], 2D;
MUL R0.x, R0.w, c[2].w;
SLT R0.x, R0, c[1];
KIL -R0.x;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MIN R0.x, R0, c[4];
MUL R0, R0.x, c[3];
FRC R0, R0;
MAD result.color, -R0.yzww, c[4].y, R0;
END
# 12 instructions, 1 R-regs
"
}
}
 }
 Pass {
  Name "SHADOWCOLLECTOR"
  Tags { "LIGHTMODE"="SHADOWCOLLECTOR" "QUEUE"="AlphaTest" "IGNOREPROJECTOR"="true" "RenderType"="TransparentCutout" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[30] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..29] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[29], c[29].zwzw;
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[30] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..29] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[29], c[29].zwzw;
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[30] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..29] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[29], c[29].zwzw;
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
Vector 29 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[30] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..29] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[29], c[29].zwzw;
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
MUL R0.w, R0, c[5];
SLT R0.w, R0, c[4].x;
SLT R2, fragment.texcoord[4].w, c[2];
SGE R1, fragment.texcoord[4].w, c[1];
MUL R1, R1, R2;
MUL R0.xyz, R1.y, fragment.texcoord[1];
MAD R0.xyz, R1.x, fragment.texcoord[0], R0;
MAD R0.xyz, R1.z, fragment.texcoord[2], R0;
MAD R0.xyz, fragment.texcoord[3], R1.w, R0;
MAD_SAT R1.y, fragment.texcoord[4].w, c[3].z, c[3].w;
MOV result.color.y, c[6].x;
TEX R0.x, R0, texture[1], 2D;
KIL -R0.w;
ADD R0.z, R0.x, -R0;
MOV R0.x, c[6];
CMP R1.x, R0.z, c[3], R0;
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[6].x;
MUL R0.xy, R0.y, c[6];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[6].z, R0.z;
ADD_SAT result.color.x, R1, R1.y;
MOV result.color.zw, R0.xyxy;
END
# 25 instructions, 3 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[7] = { program.local[0..5],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
MUL R0.w, R0, c[5];
SLT R0.w, R0, c[4].x;
SLT R2, fragment.texcoord[4].w, c[2];
SGE R1, fragment.texcoord[4].w, c[1];
MUL R1, R1, R2;
MUL R0.xyz, R1.y, fragment.texcoord[1];
MAD R0.xyz, R1.x, fragment.texcoord[0], R0;
MAD R0.xyz, R1.z, fragment.texcoord[2], R0;
MAD R0.xyz, fragment.texcoord[3], R1.w, R0;
MAD_SAT R1.y, fragment.texcoord[4].w, c[3].z, c[3].w;
MOV result.color.y, c[6].x;
TEX R0.x, R0, texture[1], SHADOW2D;
KIL -R0.w;
MOV R0.y, c[6].x;
ADD R0.w, R0.y, -c[3].x;
MAD R1.x, R0, R0.w, c[3];
MUL R0.z, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0.z, c[6].x;
MUL R0.xy, R0.y, c[6];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[6].z, R0.z;
ADD_SAT result.color.x, R1, R1.y;
MOV result.color.zw, R0.xyxy;
END
# 25 instructions, 3 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"!!ARBfp1.0
PARAM c[11] = { program.local[0..9],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
ADD R1.xyz, fragment.texcoord[4], -c[1];
ADD R2.xyz, fragment.texcoord[4], -c[4];
MUL R0.w, R0, c[9];
SLT R0.w, R0, c[8].x;
DP3 R1.x, R1, R1;
ADD R0.xyz, fragment.texcoord[4], -c[2];
DP3 R1.y, R0, R0;
ADD R0.xyz, fragment.texcoord[4], -c[3];
DP3 R1.z, R0, R0;
DP3 R1.w, R2, R2;
SLT R2, R1, c[5];
ADD_SAT R0.xyz, R2.yzww, -R2;
MUL R1.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R2.x, fragment.texcoord[0], R1;
MAD R1.xyz, R0.y, fragment.texcoord[2], R1;
MAD R0.xyz, fragment.texcoord[3], R0.z, R1;
ADD R1.xyz, -fragment.texcoord[4], c[7];
MOV result.color.y, c[10].x;
TEX R0.x, R0, texture[1], 2D;
KIL -R0.w;
ADD R0.y, R0.x, -R0.z;
DP3 R0.z, R1, R1;
RSQ R0.z, R0.z;
MOV R0.x, c[10];
CMP R0.x, R0.y, c[6], R0;
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[10].x;
RCP R1.x, R0.z;
MUL R0.zw, R0.y, c[10].xyxy;
MAD_SAT R0.y, R1.x, c[6].z, c[6].w;
FRC R0.zw, R0;
ADD_SAT result.color.x, R0, R0.y;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[10].z, R0.z;
MOV result.color.zw, R0.xyxy;
END
# 36 instructions, 3 R-regs
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[11] = { program.local[0..9],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.w, fragment.texcoord[5], texture[0], 2D;
ADD R1.xyz, fragment.texcoord[4], -c[1];
ADD R2.xyz, fragment.texcoord[4], -c[4];
MUL R0.w, R0, c[9];
SLT R0.w, R0, c[8].x;
DP3 R1.x, R1, R1;
ADD R0.xyz, fragment.texcoord[4], -c[2];
DP3 R1.y, R0, R0;
ADD R0.xyz, fragment.texcoord[4], -c[3];
DP3 R1.z, R0, R0;
DP3 R1.w, R2, R2;
SLT R2, R1, c[5];
ADD_SAT R0.xyz, R2.yzww, -R2;
MUL R1.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R2.x, fragment.texcoord[0], R1;
MAD R1.xyz, R0.y, fragment.texcoord[2], R1;
MAD R0.xyz, fragment.texcoord[3], R0.z, R1;
ADD R1.xyz, -fragment.texcoord[4], c[7];
MOV result.color.y, c[10].x;
TEX R0.x, R0, texture[1], SHADOW2D;
KIL -R0.w;
DP3 R0.z, R1, R1;
RSQ R0.z, R0.z;
MOV R0.y, c[10].x;
ADD R0.y, R0, -c[6].x;
MAD R0.x, R0, R0.y, c[6];
MUL R0.y, -fragment.texcoord[4].w, c[0].w;
ADD R0.y, R0, c[10].x;
RCP R1.x, R0.z;
MUL R0.zw, R0.y, c[10].xyxy;
MAD_SAT R0.y, R1.x, c[6].z, c[6].w;
FRC R0.zw, R0;
ADD_SAT result.color.x, R0, R0.y;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[10].z, R0.z;
MOV result.color.zw, R0.xyxy;
END
# 36 instructions, 3 R-regs
"
}
}
 }
}
}