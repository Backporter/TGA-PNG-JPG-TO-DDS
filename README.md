# TGA-PNG-JPG-TO DDS
 This Will Convert (*.TGA *.PNG *.JPG) to DDS(DirectDraw Surface)
 
***Setup:***

1: download and install [Nvidia GameWorks Legacy Texture Tool: DDS Utilities](https://developer.nvidia.com/legacy-texture-tools)

2: go to `C:\Program Files (x86)\NVIDIA Corporation\DDS Utilities` and grab `nvdxt.exe` and put it in the Data folder

3: profit

***NOTES:***

1: IF you are using this to make a PS4 Dynamic Theme, there is a limit on how big the "scene" can be, its 16MBs so this should be takken into account prior to starting work on any themes.

2: IF you are going to make a PS4 dynamic theme, pick a unused Title AND Content ID(UP0002-CUSAXXXXX_00-XXXXXXXXXXXXXXXX // CUSAXXXXX) to do this you edit the .sfo in sce_sys(sce_sys/param.sfo) you can do it with a hex-editor(i wouldn't recomend this method as it can new user to mess up and destory the sfo) or use orbis-pub-sfo.exe found in Fake_PKG_Generator the reason for this being if two different themes share the same ID's the last one installed will overwrite the one before it(most people don't want this to happen :D) if you don't know if a ID is taken, google it, it should show if anybody used it before.
