# Extended flashlight range mod

The mod for the game flew a company that increases the radius and range of the flashlights (works on the yellow and green flashlits).

## Examples

**Flashlight before:**
![Flashlight_before_patch](https://github.com/PC-Principal/extended_flashlight_range/blob/master/images/before_patch.png)
![Pro Flashlight_before_patch](https://github.com/PC-Principal/extended_flashlight_range/blob/master/images/before_patch_pro.png)

**Flashlight after:**
![Flashlight_after_patch](https://github.com/PC-Principal/extended_flashlight_range/blob/master/images/patched.png)
![Pro Flashlight_after_patch](https://github.com/PC-Principal/extended_flashlight_range/blob/master/images/patched_pro.png)

## About Edit

If you want to edit something in this mode, dont forget to change path in csproj file:

`<Reference Include="Assembly-CSharp" HintPath="E:\Games\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed\Assembly-CSharp.dll" Publicize="true" />`

Here you need to change HintPath to your's file source with Assembly-CSharp.dll

The same things you need to do witch all strings, that seems like `E:\Games\Steam\...`


## Link on sources

If you are working with IDE Rider - after build you can find your mod dll file in directory: 

`\bin\Debug\netstandard2.1`

## Template repository

If you want create your mod, you can use this template for creating https://github.com/PC-Principal/LethalCompanyModesTemplate - that exists usefill links for moding in Lethal Company
