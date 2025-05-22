# Bézier Surface Renderer

## Description
This WinForms project renders a 3rd-degree Bézier surface with advanced lighting and texturing capabilities. 
The surface is loaded from a control points file, triangulated, and can be rotated around the Z and X axes. 
It implements Phong shading model with both diffuse and specular components, supporting texture mapping and normal mapping.

## Features
 - Bézier Surface Rendering:
   - Loads 16 control points from a text file
   - Adjustable triangulation precision via slider
   - Rotation around Z (alpha: -45° to 45°) and X (beta: 0° to 10°) axes

 - Rendering Options:
   - Toggle between wireframe and filled triangles
   - Bucket-sort edge algorithm for polygon filling

 - Lighting Model:
   - Lambertian diffuse component
   - Phong specular component
   - Adjustable coefficients (kd, ks, m) via sliders
   - Animated light source moving in a circle pattern
   - Light source height adjustable via slider

 - Texturing:
   - Solid color option
   - Texture mapping
   - Normal mapping (with optional modification of surface normals)
  
## File Format
Control points file should contain exactly 16 lines, each with 3 space-separated floating-point numbers (X Y Z coordinates): \
X00 Y00 Z00 \
X01 Y01 Z01 \
... \
X15 Y15 Z15
